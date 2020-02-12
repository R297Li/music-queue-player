using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;
using YoutubeExplode;
using YoutubeExplode.Models.MediaStreams;
using System.Net;

namespace MusicApp
{
    public class MusicPlayer
    {
        /// <summary>
        /// Directory corresponding to temporary downloaded audio files
        /// </summary>
        private const string AUDIO_FILE_DIRECTORY = "F:\\windows_music_app\\MusicApp\\MusicApp\\temporary\\musicCache\\";

        /// <summary>
        /// Internal class used to organize song data
        /// </summary>
        internal class Song
        {
            public string Name { get; set; }
            public string Url { get; set; }
            public string FilePath { get; set; }
            public TimeSpan Duration { get; set; }
            public bool Repeat { get; set; }
        }

        private YoutubeApi _youtubeApi;
        private List<Song> _songQueue;
        private Song _currentSong;
        private Label _mainInfoDisplay;
        private Label _subInfoDisplay;
        private bool _isRepeat = false;
        private bool _isLoop = false;
        private YoutubeClient _youtubeClient;
        private WindowsMediaPlayer _windowsPlayer;
        private bool _isSongThreadRunning = false;
        private CancellationTokenSource _skipSongTokenSource;
        private CancellationToken _skipSongToken;

        public MusicPlayer(Label mainInfoDisplay, Label subInfoDisplay)
        {
            _youtubeApi = new YoutubeApi();
            _youtubeClient = new YoutubeClient();
            _songQueue = new List<Song>();
            _mainInfoDisplay = mainInfoDisplay;
            _subInfoDisplay = subInfoDisplay;
            _windowsPlayer = new WindowsMediaPlayer();

            _windowsPlayer.settings.autoStart = false;
            _windowsPlayer.PlayStateChange += new _WMPOCXEvents_PlayStateChangeEventHandler(PlayerStateEvent);
        }

        /// <summary>
        /// Triggered when music player changes state.
        /// Set song title when player state is 'playing'
        /// </summary>
        /// <param name="playerState"></param>
        private void PlayerStateEvent(int playerState)
        {
            if (_windowsPlayer.playState == WMPPlayState.wmppsPlaying)
            {
                Display(_mainInfoDisplay, _currentSong.Name, Color.LightSteelBlue);
            }
        }

        /// <summary>
        /// Asynchronus task to download requested song and execute play song task
        /// </summary>
        /// <param name="song"></param>
        /// <returns></returns>
        public async Task PlaySongAsync(string song)
        {
            await DownloadSongAsync(song);

            if (_isSongThreadRunning == false)
            {
                _ = Task.Run(() => PlayNextSong());
            }

            return;
        }

        /// <summary>
        /// Remove song from queue based on queue index/position
        /// </summary>
        /// <param name="queuePosition"></param>
        public void RemoveSongFromQueue(string queuePosition)
        {
            int position;

            // Tryparse to ensure input is an integer
            if (int.TryParse(queuePosition.Trim(), out position))
            {
                if (position > -1)
                {
                    _songQueue.RemoveAt(position);
                }
            }
            else
            {

            }
        }

        /// <summary>
        /// Skip current playing song
        /// </summary>
        public void SkipSong()
        {
            _skipSongTokenSource.Cancel();
        }

        /// <summary>
        /// Repeat current song
        /// </summary>
        public void Repeat()
        {
            if (_isLoop == false)
            {
                _isRepeat = (_isRepeat == true) ? false : true;
            }
            else
            {
                Display(_subInfoDisplay, "Please disable Loop functionality", Color.Red);
            }
        }

        /// <summary>
        /// Loop all songs in queue
        /// </summary>
        public void Loop()
        {
            if (_isRepeat == false)
            {
                _isLoop = (_isLoop == true) ? false : true;
            }
            else
            {
                Display(_subInfoDisplay, "Please disable Repeat functionality", Color.Red);
            }
        }

        /// <summary>
        /// Task to manage song in queue and play next song
        /// </summary>
        /// <returns></returns>
        private async Task PlayNextSong()
        {
            _isSongThreadRunning = true;

            while (true)
            {
                _currentSong = _songQueue[0];

                // Append current song to end of queue
                if (_isLoop == true)
                {
                    _songQueue.Add(_currentSong);
                }
                // Remove current song from queue
                if (_isRepeat == false)
                {
                    RemoveSongFromQueue("0");
                }

                _windowsPlayer.URL = _currentSong.FilePath;
                _windowsPlayer.controls.play();

                // Initialize cancellation token and await a delay task with duration identical to song duration.
                // This delay ensures entire song is played before next song is executed.
                try
                {
                    _skipSongTokenSource = new CancellationTokenSource();
                    _skipSongToken = _skipSongTokenSource.Token;
                    await Task.Delay(_currentSong.Duration, _skipSongToken);
                }
                catch (TaskCanceledException)
                {
                }

                // Dispose of current skip token
                _skipSongTokenSource.Dispose();

                _windowsPlayer.controls.stop();

                // Break out of loop if no songs left in queue
                if (!_songQueue.Any())
                {
                    break;
                }
            }

            _isSongThreadRunning = false;
            return;
        }

        /// <summary>
        /// Asynhronus task to download song
        /// </summary>
        /// <param name="song"></param>
        /// <returns></returns>
        private async Task DownloadSongAsync(string song)
        {
            // Obtain song name and url with youtube api
            _youtubeApi.SearchSong(song);

            string videoName = WebUtility.HtmlDecode(_youtubeApi.VideoName);
            string videoUrl = _youtubeApi.VideoUrl;

            if (videoName.Contains("Error"))
            {
                Display(_mainInfoDisplay, videoName, Color.Red);
                return;
            }

            //string fileExtension = audioStreamInfo.Container.GetFileExtension();
            string fileExtension = "mp3";

            string filePath = String.Format("{0}{1}.{2}", AUDIO_FILE_DIRECTORY, videoUrl, fileExtension);

            // Get video info
            var videoInfo = await _youtubeClient.GetVideoAsync(videoUrl);

            if (!File.Exists(filePath))
            {
                // Get video metadata from youtube url
                var videoStreamInfo = await _youtubeClient.GetVideoMediaStreamInfosAsync(videoUrl);

                // Extract audio from video metadata
                var audioStreamInfo = videoStreamInfo.Audio.WithHighestBitrate();

                // Download video to specified file path
                await _youtubeClient.DownloadMediaStreamAsync(audioStreamInfo, filePath);

                if (!File.Exists(filePath))
                {
                    Display(_mainInfoDisplay, "Cannot get song", Color.Red);
                    return;
                }
            }

            Song newSong = new Song()
            {
                Name = videoName,
                Url = videoUrl,
                FilePath = filePath,
                Duration = videoInfo.Duration,
                Repeat = false
            };

            _songQueue.Add(newSong);
            return;
        }

        private void Display(Label infoLabel, string displayText, Color color)
        {
            infoLabel.Text = displayText;
            infoLabel.ForeColor = color;
        }
    }
}

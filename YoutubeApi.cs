using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Upload;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3.Data;

namespace MusicApp
{
    public class YoutubeApi
    {
        public string VideoUrl { get; set; }
        public string VideoName { get; set; }

        public YoutubeApi()
        {
            VideoUrl = null;
            VideoName = null;
        }

        public void SearchSong(string songName)
        {
            GetYoutubeVideoUrl(songName);
        }

        private void GetYoutubeVideoUrl(string videoName)
        {
            try
            {
                Search search = new Search();
                search.VideoName = videoName;
                search.Run();
                VideoUrl = search.VideoUrl;
                VideoName = search.VideoName;
            }
            catch (AggregateException ex)
            {
                foreach (var e in ex.InnerExceptions)
                {
                    VideoName = string.Format("Error: %s", e.Message);
                }
            }
        }

        internal class Search
        {
            public string VideoName { get; set; }
            public string VideoUrl { get; set; }
            public void Run()
            {
                var youtubeService = new YouTubeService(new BaseClientService.Initializer()
                {
                    ApiKey = "AIzaSyCFdc1WGHzgXmNz9FGJbIL23BduAZe8Kno",
                    ApplicationName = this.GetType().ToString()
                });

                var searchListRequest = youtubeService.Search.List("snippet");
                searchListRequest.Q = VideoName;
                searchListRequest.MaxResults = 5;

                // Call the search.list method to retrieve results matching the specified query term.
                var searchListResponse = searchListRequest.Execute();

                List<Tuple<string,string>> videos = new List<Tuple<string, string>>();

                // Add each result to the appropriate list, and then display the lists of
                // matching videos, channels, and playlists.
                foreach (var searchResult in searchListResponse.Items)
                {
                    var contentDetailsRequest = youtubeService.Search.List("contentDetails");
                    contentDetailsRequest.Q = searchResult.Id.VideoId;
                    searchListRequest.MaxResults = 5;

                    switch (searchResult.Id.Kind)
                    {
                        case "youtube#video":
                            Tuple<string, string> video = new Tuple<string, string>(searchResult.Snippet.Title, searchResult.Id.VideoId);
                            videos.Add(video);
                            break;
                    }
                }

                VideoName = videos[0].Item1;
                VideoUrl = videos[0].Item2;
            }
        }

    }
}

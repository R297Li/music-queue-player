using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace MusicApp
{
    public partial class MusicPlayerForm : FormBase
    {
        private MusicPlayer _musicPlayer;

        public MusicPlayerForm() : base()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;

            _musicPlayer = new MusicPlayer(MainInfo, SubInfo);
        }

        /// <summary>
        /// Create the horizontal divider
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HorizontalDivider_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, HorizontalDivider.DisplayRectangle, Color.Black, ButtonBorderStyle.Solid);
        }

        /// <summary>
        /// Enable drag and drop of the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        /// <summary>
        /// Terminate the app
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Disable button highlight effect on mouse hover for the Close Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseButton_MouseEnter(object sender, EventArgs e)
        {
            ButtonMouseEnter(sender, e);
        }

        /// <summary>
        /// Recieve user input in search box upon 'Enter' 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Disable 'Ding' sound from textbox
                e.Handled = true;
                e.SuppressKeyPress = true;

                // Obtain corresponding enum to desired action
                ActionKeys desiredAction = FindDesiredAction(SearchBox.Text);

                // Set warning if no corresponding action is found
                if (desiredAction == ActionKeys.NoAction)
                {
                    Display(MainInfo, "Invalid action key. Please try again.", Color.Red);
                    SearchBox.Text = string.Empty;
                    return;
                }

                // Execute action
                MediaPlayerAction(desiredAction);
                return;
            }
        }

        /// <summary>
        /// Execute desired action
        /// </summary>
        /// <param name="desiredAction"></param>
        private void MediaPlayerAction(ActionKeys desiredAction)
        {
            string searchText = SearchBox.Text;
            SearchBox.Text = string.Empty;

            // Remove action indicators from string (ie. !p, !s, etc)
            if (desiredAction == ActionKeys.Play || desiredAction == ActionKeys.Remove)
            {
                int startIndexOfSong = searchText.IndexOf(" ") + 1;
                searchText = searchText.Substring(startIndexOfSong);
            }

            switch (desiredAction)
            {
                case ActionKeys.Play:
                    Task.Run(() => _musicPlayer.PlaySongAsync(searchText));
                    break;

                case ActionKeys.Remove:
                    _musicPlayer.RemoveSongFromQueue(searchText);
                    break;

                case ActionKeys.Skip:
                    _musicPlayer.SkipSong();
                    break;

                case ActionKeys.Repeat:
                    _musicPlayer.Repeat();
                    break;

                case ActionKeys.Loop:
                    _musicPlayer.Loop();
                    break;
            }

            return;
        }

        /// <summary>
        /// Obtain enum corresponding to desired action
        /// </summary>
        /// <param name="searchText"></param>
        /// <returns></returns>
        private ActionKeys FindDesiredAction(string searchText)
        {
            // Split search string by space
            string[] searchTexts = searchText.Split(new char[0]);
            string desiredAction = searchTexts[0].Trim().ToLower();

            ActionKeys actionKey;

            switch (desiredAction)
            {
                case "!p":
                    actionKey = ActionKeys.Play;
                    break;

                case "!play":
                    actionKey = ActionKeys.Play;
                    break;

                case "!r":
                    actionKey = ActionKeys.Remove;
                    break;

                case "!remove":
                    actionKey = ActionKeys.Remove;
                    break;

                case "!s":
                    actionKey = ActionKeys.Skip;
                    break;

                case "!skip":
                    actionKey = ActionKeys.Skip;
                    break;

                case "!repeat":
                    actionKey = ActionKeys.Repeat;
                    break;

                case "!loop":
                    actionKey = ActionKeys.Loop;
                    break;

                default:
                    actionKey = ActionKeys.NoAction;
                    break;
            }

            return actionKey;
        }

        /// <summary>
        /// Set passed in label with passed in text and color
        /// </summary>
        /// <param name="infoLabel"></param>
        /// <param name="displayText"></param>
        /// <param name="color"></param>
        private void Display(Label infoLabel, string displayText, Color color)
        {
            infoLabel.Text = displayText;
            infoLabel.ForeColor = color;
        }

        /// <summary>
        /// Disable button highlight effect on mouse hover for the Skip Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SkipButton_MouseEnter(object sender, EventArgs e)
        {
            ButtonMouseEnter(sender, e);
        }

        /// <summary>
        /// Execute skip action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SkipButton_Click(object sender, EventArgs e)
        {
            MediaPlayerAction(ActionKeys.Skip);
            return;
        }
    }
}

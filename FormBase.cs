using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicApp
{
    public class FormBase : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        public enum ActionKeys
        {
            Play,
            Pause,
            Skip,
            Remove,
            Repeat,
            Loop,
            NoAction
        }

        public FormBase()
        {
        }

        /// <summary>
        /// Base method for mouse enter action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonMouseEnter(object sender, EventArgs e)
        {
            RemoveButtonHighlight(sender, e);
        }

        /// <summary>
        /// Remove highlight when hovering over a button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveButtonHighlight(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            button.FlatAppearance.MouseOverBackColor = Color.Transparent;
        }
    }
}

namespace MusicApp
{
    partial class MusicPlayerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MusicPlayerForm));
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.BackPanel = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SubInfo = new System.Windows.Forms.Label();
            this.MainInfo = new System.Windows.Forms.Label();
            this.SearchBoxBorder = new System.Windows.Forms.Panel();
            this.SearchBoxContainer = new System.Windows.Forms.Panel();
            this.SearchBox = new System.Windows.Forms.TextBox();
            this.ListButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.HorizontalDivider = new System.Windows.Forms.Label();
            this.SkipButton = new System.Windows.Forms.Button();
            this.BackgroundBorder = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.BackPanel.SuspendLayout();
            this.SearchBoxBorder.SuspendLayout();
            this.SearchBoxContainer.SuspendLayout();
            this.BackgroundBorder.SuspendLayout();
            this.SuspendLayout();
            // 
            // BackPanel
            // 
            this.BackPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(56)))), ((int)(((byte)(57)))));
            this.BackPanel.Controls.Add(this.button2);
            this.BackPanel.Controls.Add(this.button1);
            this.BackPanel.Controls.Add(this.SubInfo);
            this.BackPanel.Controls.Add(this.MainInfo);
            this.BackPanel.Controls.Add(this.SearchBoxBorder);
            this.BackPanel.Controls.Add(this.ListButton);
            this.BackPanel.Controls.Add(this.CloseButton);
            this.BackPanel.Controls.Add(this.HorizontalDivider);
            this.BackPanel.Controls.Add(this.SkipButton);
            this.BackPanel.Location = new System.Drawing.Point(2, 2);
            this.BackPanel.Name = "BackPanel";
            this.BackPanel.Size = new System.Drawing.Size(502, 120);
            this.BackPanel.TabIndex = 7;
            this.BackPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BackPanel_MouseDown);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(56)))), ((int)(((byte)(57)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.Transparent;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(24, 45);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(25, 25);
            this.button2.TabIndex = 14;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(56)))), ((int)(((byte)(57)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.Transparent;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(24, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 25);
            this.button1.TabIndex = 13;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // SubInfo
            // 
            this.SubInfo.AutoEllipsis = true;
            this.SubInfo.AutoSize = true;
            this.SubInfo.Font = new System.Drawing.Font("Montserrat Light", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubInfo.ForeColor = System.Drawing.Color.Silver;
            this.SubInfo.Location = new System.Drawing.Point(131, 45);
            this.SubInfo.MaximumSize = new System.Drawing.Size(350, 25);
            this.SubInfo.Name = "SubInfo";
            this.SubInfo.Size = new System.Drawing.Size(140, 15);
            this.SubInfo.TabIndex = 12;
            this.SubInfo.Text = "Developed By Richard Li";
            // 
            // MainInfo
            // 
            this.MainInfo.AutoEllipsis = true;
            this.MainInfo.AutoSize = true;
            this.MainInfo.Font = new System.Drawing.Font("Montserrat Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainInfo.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.MainInfo.Location = new System.Drawing.Point(131, 19);
            this.MainInfo.MaximumSize = new System.Drawing.Size(400, 25);
            this.MainInfo.Name = "MainInfo";
            this.MainInfo.Size = new System.Drawing.Size(126, 17);
            this.MainInfo.TabIndex = 11;
            this.MainInfo.Text = "Music Queue Player";
            // 
            // SearchBoxBorder
            // 
            this.SearchBoxBorder.BackColor = System.Drawing.Color.Black;
            this.SearchBoxBorder.Controls.Add(this.SearchBoxContainer);
            this.SearchBoxBorder.Location = new System.Drawing.Point(21, 89);
            this.SearchBoxBorder.Name = "SearchBoxBorder";
            this.SearchBoxBorder.Size = new System.Drawing.Size(426, 28);
            this.SearchBoxBorder.TabIndex = 9;
            // 
            // SearchBoxContainer
            // 
            this.SearchBoxContainer.BackColor = System.Drawing.Color.Silver;
            this.SearchBoxContainer.Controls.Add(this.SearchBox);
            this.SearchBoxContainer.Location = new System.Drawing.Point(3, 2);
            this.SearchBoxContainer.Name = "SearchBoxContainer";
            this.SearchBoxContainer.Size = new System.Drawing.Size(420, 24);
            this.SearchBoxContainer.TabIndex = 7;
            // 
            // SearchBox
            // 
            this.SearchBox.AutoCompleteCustomSource.AddRange(new string[] {
            "!p",
            "!r",
            "!s",
            "!loop",
            "!repeat"});
            this.SearchBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.SearchBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.SearchBox.BackColor = System.Drawing.Color.Silver;
            this.SearchBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SearchBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.SearchBox.Font = new System.Drawing.Font("Metrophobic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchBox.Location = new System.Drawing.Point(30, 2);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(390, 19);
            this.SearchBox.TabIndex = 0;
            this.SearchBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SearchBox_KeyUp);
            // 
            // ListButton
            // 
            this.ListButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(56)))), ((int)(((byte)(57)))));
            this.ListButton.FlatAppearance.BorderSize = 0;
            this.ListButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ListButton.ForeColor = System.Drawing.Color.Transparent;
            this.ListButton.Image = ((System.Drawing.Image)(resources.GetObject("ListButton.Image")));
            this.ListButton.Location = new System.Drawing.Point(453, 84);
            this.ListButton.Name = "ListButton";
            this.ListButton.Size = new System.Drawing.Size(33, 33);
            this.ListButton.TabIndex = 5;
            this.ListButton.UseVisualStyleBackColor = false;
            // 
            // CloseButton
            // 
            this.CloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(56)))), ((int)(((byte)(57)))));
            this.CloseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CloseButton.FlatAppearance.BorderSize = 0;
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseButton.ForeColor = System.Drawing.Color.Transparent;
            this.CloseButton.Image = ((System.Drawing.Image)(resources.GetObject("CloseButton.Image")));
            this.CloseButton.Location = new System.Drawing.Point(474, 1);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(25, 25);
            this.CloseButton.TabIndex = 6;
            this.CloseButton.UseVisualStyleBackColor = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            this.CloseButton.MouseEnter += new System.EventHandler(this.CloseButton_MouseEnter);
            // 
            // HorizontalDivider
            // 
            this.HorizontalDivider.BackColor = System.Drawing.Color.Black;
            this.HorizontalDivider.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.HorizontalDivider.ForeColor = System.Drawing.Color.Black;
            this.HorizontalDivider.Location = new System.Drawing.Point(16, 78);
            this.HorizontalDivider.Name = "HorizontalDivider";
            this.HorizontalDivider.Size = new System.Drawing.Size(470, 4);
            this.HorizontalDivider.TabIndex = 3;
            this.HorizontalDivider.Paint += new System.Windows.Forms.PaintEventHandler(this.HorizontalDivider_Paint);
            // 
            // SkipButton
            // 
            this.SkipButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(56)))), ((int)(((byte)(57)))));
            this.SkipButton.FlatAppearance.BorderSize = 0;
            this.SkipButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SkipButton.ForeColor = System.Drawing.Color.Transparent;
            this.SkipButton.Image = ((System.Drawing.Image)(resources.GetObject("SkipButton.Image")));
            this.SkipButton.Location = new System.Drawing.Point(55, 14);
            this.SkipButton.Name = "SkipButton";
            this.SkipButton.Size = new System.Drawing.Size(53, 53);
            this.SkipButton.TabIndex = 1;
            this.SkipButton.UseVisualStyleBackColor = false;
            this.SkipButton.Click += new System.EventHandler(this.SkipButton_Click);
            this.SkipButton.MouseEnter += new System.EventHandler(this.SkipButton_MouseEnter);
            // 
            // BackgroundBorder
            // 
            this.BackgroundBorder.BackColor = System.Drawing.Color.Black;
            this.BackgroundBorder.Controls.Add(this.BackPanel);
            this.BackgroundBorder.Location = new System.Drawing.Point(0, 0);
            this.BackgroundBorder.Name = "BackgroundBorder";
            this.BackgroundBorder.Size = new System.Drawing.Size(506, 124);
            this.BackgroundBorder.TabIndex = 8;
            // 
            // MusicPlayerForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(506, 124);
            this.Controls.Add(this.BackgroundBorder);
            this.Font = new System.Drawing.Font("Metrophobic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MusicPlayerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MusicPlayerForm_FormClosed);
            this.BackPanel.ResumeLayout(false);
            this.BackPanel.PerformLayout();
            this.SearchBoxBorder.ResumeLayout(false);
            this.SearchBoxContainer.ResumeLayout(false);
            this.SearchBoxContainer.PerformLayout();
            this.BackgroundBorder.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button SkipButton;
        private System.Windows.Forms.Label HorizontalDivider;
        private System.Windows.Forms.Button ListButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Panel BackPanel;
        private System.Windows.Forms.Panel BackgroundBorder;
        private System.Windows.Forms.Panel SearchBoxBorder;
        private System.Windows.Forms.Panel SearchBoxContainer;
        private System.Windows.Forms.TextBox SearchBox;
        private System.Windows.Forms.Label SubInfo;
        private System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.Label MainInfo;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}


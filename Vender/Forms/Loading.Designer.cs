namespace Vender
{
    partial class Loading
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Loading));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ProgressBar = new Bunifu.UI.Winforms.BunifuProgressBar();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 30;
            this.bunifuElipse1.TargetControl = this;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ProgressBar
            // 
            this.ProgressBar.Animation = 0;
            this.ProgressBar.AnimationStep = 10;
            this.ProgressBar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ProgressBar.BackgroundImage")));
            this.ProgressBar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.ProgressBar.BorderRadius = 1;
            this.ProgressBar.BorderThickness = 1;
            this.ProgressBar.Location = new System.Drawing.Point(39, 287);
            this.ProgressBar.MaximumValue = 100;
            this.ProgressBar.MinimumValue = 0;
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.ProgressBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.ProgressBar.ProgressColorLeft = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(28)))), ((int)(((byte)(193)))));
            this.ProgressBar.ProgressColorRight = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(28)))), ((int)(((byte)(193)))));
            this.ProgressBar.Size = new System.Drawing.Size(279, 10);
            this.ProgressBar.TabIndex = 3;
            this.ProgressBar.Value = 0;
            // 
            // Loading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.BackgroundImage = global::Vender.Properties.Resources.about_page;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1054, 463);
            this.Controls.Add(this.ProgressBar);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Loading";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TransparencyKey = System.Drawing.SystemColors.Desktop;
            this.Load += new System.EventHandler(this.Loading_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Timer timer1;
        private Bunifu.UI.Winforms.BunifuProgressBar ProgressBar;
    }
}
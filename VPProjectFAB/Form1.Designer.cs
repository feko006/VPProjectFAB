namespace VPProjectFAB
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.pbBackground = new System.Windows.Forms.PictureBox();
            this.pbPlay = new System.Windows.Forms.PictureBox();
            this.pbQuit = new System.Windows.Forms.PictureBox();
            this.pbControls = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbBackground)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbQuit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbControls)).BeginInit();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Interval = 30;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // pbBackground
            // 
            this.pbBackground.Image = ((System.Drawing.Image)(resources.GetObject("pbBackground.Image")));
            this.pbBackground.Location = new System.Drawing.Point(-3, -5);
            this.pbBackground.Name = "pbBackground";
            this.pbBackground.Size = new System.Drawing.Size(676, 502);
            this.pbBackground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBackground.TabIndex = 0;
            this.pbBackground.TabStop = false;
            // 
            // pbPlay
            // 
            this.pbPlay.BackColor = System.Drawing.Color.Transparent;
            this.pbPlay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbPlay.Image = ((System.Drawing.Image)(resources.GetObject("pbPlay.Image")));
            this.pbPlay.Location = new System.Drawing.Point(251, 178);
            this.pbPlay.Name = "pbPlay";
            this.pbPlay.Size = new System.Drawing.Size(170, 76);
            this.pbPlay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPlay.TabIndex = 1;
            this.pbPlay.TabStop = false;
            this.pbPlay.Click += new System.EventHandler(this.pbPlay_Click);
            this.pbPlay.MouseEnter += new System.EventHandler(this.pbPlay_MouseEnter);
            this.pbPlay.MouseLeave += new System.EventHandler(this.pbPlay_MouseLeave);
            // 
            // pbQuit
            // 
            this.pbQuit.BackColor = System.Drawing.Color.Transparent;
            this.pbQuit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbQuit.Image = ((System.Drawing.Image)(resources.GetObject("pbQuit.Image")));
            this.pbQuit.Location = new System.Drawing.Point(249, 260);
            this.pbQuit.Name = "pbQuit";
            this.pbQuit.Size = new System.Drawing.Size(170, 76);
            this.pbQuit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbQuit.TabIndex = 2;
            this.pbQuit.TabStop = false;
            this.pbQuit.Click += new System.EventHandler(this.pbQuit_Click);
            this.pbQuit.MouseEnter += new System.EventHandler(this.pbQuit_MouseEnter);
            this.pbQuit.MouseLeave += new System.EventHandler(this.pbQuit_MouseLeave);
            // 
            // pbControls
            // 
            this.pbControls.BackColor = System.Drawing.Color.Transparent;
            this.pbControls.Image = ((System.Drawing.Image)(resources.GetObject("pbControls.Image")));
            this.pbControls.Location = new System.Drawing.Point(-3, 40);
            this.pbControls.Name = "pbControls";
            this.pbControls.Size = new System.Drawing.Size(676, 173);
            this.pbControls.TabIndex = 3;
            this.pbControls.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 490);
            this.Controls.Add(this.pbQuit);
            this.Controls.Add(this.pbPlay);
            this.Controls.Add(this.pbControls);
            this.Controls.Add(this.pbBackground);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "VPProjectFAB";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pbBackground)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbQuit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbControls)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.PictureBox pbBackground;
        private System.Windows.Forms.PictureBox pbControls;
        private System.Windows.Forms.PictureBox pbPlay;
        private System.Windows.Forms.PictureBox pbQuit;
    }
}


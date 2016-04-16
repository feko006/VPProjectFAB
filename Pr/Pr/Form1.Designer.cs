namespace Pr
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pb_Background = new System.Windows.Forms.PictureBox();
            this.pb_Play = new System.Windows.Forms.PictureBox();
            this.pb_Quit = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Background)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Play)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Quit)).BeginInit();
            this.SuspendLayout();
            // 
            // pb_Background
            // 
            this.pb_Background.Image = ((System.Drawing.Image)(resources.GetObject("pb_Background.Image")));
            this.pb_Background.Location = new System.Drawing.Point(-3, -13);
            this.pb_Background.Name = "pb_Background";
            this.pb_Background.Size = new System.Drawing.Size(625, 846);
            this.pb_Background.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pb_Background.TabIndex = 0;
            this.pb_Background.TabStop = false;
            // 
            // pb_Play
            // 
            this.pb_Play.Image = ((System.Drawing.Image)(resources.GetObject("pb_Play.Image")));
            this.pb_Play.Location = new System.Drawing.Point(252, 69);
            this.pb_Play.Name = "pb_Play";
            this.pb_Play.Size = new System.Drawing.Size(100, 50);
            this.pb_Play.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_Play.TabIndex = 1;
            this.pb_Play.TabStop = false;
            this.pb_Play.Click += new System.EventHandler(this.pb_Play_Click);
            this.pb_Play.MouseEnter += new System.EventHandler(this.pb_Play_MouseEnter);
            this.pb_Play.MouseLeave += new System.EventHandler(this.pb_Play_MouseLeave);
            // 
            // pb_Quit
            // 
            this.pb_Quit.Image = ((System.Drawing.Image)(resources.GetObject("pb_Quit.Image")));
            this.pb_Quit.Location = new System.Drawing.Point(252, 156);
            this.pb_Quit.Name = "pb_Quit";
            this.pb_Quit.Size = new System.Drawing.Size(100, 50);
            this.pb_Quit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_Quit.TabIndex = 2;
            this.pb_Quit.TabStop = false;
            this.pb_Quit.Click += new System.EventHandler(this.pb_Quit_Click);
            this.pb_Quit.MouseEnter += new System.EventHandler(this.pb_Quit_MouseEnter);
            this.pb_Quit.MouseLeave += new System.EventHandler(this.pb_Quit_MouseLeave);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 471);
            this.Controls.Add(this.pb_Quit);
            this.Controls.Add(this.pb_Play);
            this.Controls.Add(this.pb_Background);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pb_Background)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Play)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Quit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_Background;
        private System.Windows.Forms.PictureBox pb_Play;
        private System.Windows.Forms.PictureBox pb_Quit;
    }
}


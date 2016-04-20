using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pr
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pb_Quit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pb_Play_Click(object sender, EventArgs e)
        {

        }

        private void pb_Play_MouseEnter(object sender, EventArgs e)
        {
            pb_Play.Height += 10;
            pb_Play.Width += 10;
            pb_Play.Left -= 5;
            pb_Play.Top -= 5;
        }

        private void pb_Quit_MouseEnter(object sender, EventArgs e)
        {
            pb_Quit.Height += 5;
            pb_Quit.Width += 5;
        }

        private void pb_Play_MouseLeave(object sender, EventArgs e)
        {
            pb_Play.Height -= 5;
            pb_Play.Width -= 5;
        }

        private void pb_Quit_MouseLeave(object sender, EventArgs e)
        {
            pb_Quit.Height -= 5;
            pb_Quit.Width -= 5;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Size size = new Size(this.Size.Width, this.Size.Height);
            pb_Background.Size = size;
        }

        
    }
}

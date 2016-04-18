using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPProjectFAB
{
    public partial class Form1 : Form
    {
        private Game game;

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            game = new Game(this);
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            game.update();
            game.draw(CreateGraphics());
        }
    }
}

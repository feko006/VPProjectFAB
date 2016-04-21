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
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            game.update();
            game.draw(CreateGraphics());
        }  

        public void goToMenu()
        { 
            pbBackground.Visible = true;
            pbPlay.Visible = true;
            pbQuit.Visible = true;
            timer.Stop();
        }

        private void pbPlay_Click(object sender, EventArgs e)
        {
            pbBackground.Visible = false;
            pbPlay.Visible = false;
            pbQuit.Visible = false;
            timer.Start();
            game.startGame();
        }

        private void pbPlay_MouseEnter(object sender, EventArgs e)
        {
            pbPlay.Height += 10;
            pbPlay.Width += 10;
            pbPlay.Left -= 5;
            pbPlay.Top -= 5;
        }

        private void pbPlay_MouseLeave(object sender, EventArgs e)
        {
            pbPlay.Height -= 10;
            pbPlay.Width -= 10;
            pbPlay.Left += 5;
            pbPlay.Top += 5;
        }

        private void pbQuit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pbQuit_MouseEnter(object sender, EventArgs e)
        {
            pbQuit.Height += 10;
            pbQuit.Width += 10;
            pbQuit.Left -= 5;
            pbQuit.Top -= 5;
        }

        private void pbQuit_MouseLeave(object sender, EventArgs e)
        {
            pbQuit.Height -= 10;
            pbQuit.Width -= 10;
            pbQuit.Left += 5;
            pbQuit.Top += 5;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
                game.player1Up();
            if (e.KeyCode == Keys.S)
                game.player1Down();
        }
    }
}

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
        bool handled;

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
            handled = false;
            if (e.KeyCode == Keys.W)
            {
                Game.p1up = true;
                handled = true;
            }
            else if (e.KeyCode == Keys.S)
            {
                Game.p1down = true;
                handled = true;
            }
            else if (e.KeyCode == Keys.Space)
            {
                Game.p1shoot = true;
                handled = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                Game.p2up = true;
                handled = true;
            }
            else if (e.KeyCode == Keys.Down)
            {
                Game.p2down = true;
                handled = true;
            }
            else if (e.KeyCode == Keys.NumPad0)
            {
                Game.p2shoot = true;
                handled = true;
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (handled)
                e.Handled = true;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
                Game.p1up = false;
            else if (e.KeyCode == Keys.S)
                Game.p1down = false;
            else if (e.KeyCode == Keys.Space)
                Game.p1shoot = false;
            else if (e.KeyCode == Keys.Up)
                Game.p2up = false;
            else if (e.KeyCode == Keys.Down)
                Game.p2down = false;
            else if (e.KeyCode == Keys.NumPad0)
                Game.p2shoot = false;
        }
    }
}

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
        public bool pressedUp;
        public bool pressedDown;
        public bool shooting1;
        public int firerate1;

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            game = new Game(this);
            firerate1 = 15;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (firerate1 >= 15)
            {
                if (shooting1)
                {
                    game.player1.fireRight();
                    firerate1 = 0;
                }
                firerate1--;
            }
            else
                firerate1++;
            if (pressedUp)
                game.player1.moveUp();
            if (pressedDown)
                game.player1.moveDown();
           // if (shooting1)
              //  game.player1.fireRight();
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
            if (e.KeyCode == Keys.W)
                pressedUp = true;
            //game.player1.moveUp();
            if (e.KeyCode == Keys.S)
                pressedDown = true;
            // game.player1.moveDown();
            if (e.KeyCode == Keys.H)
                shooting1 = true;
                //game.player1.fireRight();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
                pressedUp = false;
            //game.player1.moveUp();
            if (e.KeyCode == Keys.S)
                pressedDown = false;
            // game.player1.moveDown();
            if (e.KeyCode == Keys.H)
                shooting1 = false;
        }
    }
}

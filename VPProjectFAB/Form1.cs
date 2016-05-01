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

        public bool p1Up { get; set; }
        public bool p1Down { get; set; }
        public bool p1Shoot { get; set; }
        public int p1firerate { get; set; }

        public bool p2Up { get; set; }
        public bool p2Down { get; set; }
        public bool p2Shoot { get; set; }
        public int p2firerate { get; set; }

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            game = new Game(this);
            p1firerate = 10;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (p1firerate >= 15)
            {
                if (p1Shoot)
                {
                    game.player1.fireRight();
                    p1firerate = 0;
                }
                p1firerate--;
            }
            else
                p1firerate++;
            if (p1Up)
                game.player1.moveUp();
            if (p1Down)
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
                p1Up = true;
            //game.player1.moveUp();
            if (e.KeyCode == Keys.S)
                p1Down = true;
            // game.player1.moveDown();
            if (e.KeyCode == Keys.H)
                p1Shoot = true;
                //game.player1.fireRight();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
                p1Up = false;
            //game.player1.moveUp();
            if (e.KeyCode == Keys.S)
                p1Down = false;
            // game.player1.moveDown();
            if (e.KeyCode == Keys.H)
                p1Shoot = false;
        }
    }
}

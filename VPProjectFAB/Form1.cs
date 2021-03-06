﻿using System;
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
        public bool shouldUpdate { get; set; }   


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
            p1firerate = 15;
            p2firerate = 15;
        }

        /// <summary>
        /// Timer function that happens once a frame
        /// </summary>
        private void timer_Tick(object sender, EventArgs e)
        {
            if (!shouldUpdate)
                return;
            if (p1firerate >= 15)
            {
                if (p1Shoot)
                {
                    game.player1.fire();
                    p1firerate = 0;
                }
                p1firerate--;
            }
            else
                p1firerate++;
            if (p1Up && !p1Down)
                game.player1.moveUp();
            if (p1Down && !p1Up)
                game.player1.moveDown();
            if (p2firerate >= 15)
            {
                if (p2Shoot)
                {
                    game.player2.fire();
                    p2firerate = 0;
                }
                p2firerate--;
            }
            else
                p2firerate++;
            if (p2Up)
                game.player2.moveUp();
            if (p2Down)
                game.player2.moveDown();
            game.update();
            Invalidate();
        }

        /// <summary>
        /// Ends the game and starts the menu screen
        /// </summary>
        public void goToMenu()
        {
            pbBackground.Visible = true;
            pbPlay.Visible = true;
            pbQuit.Visible = true;
            pbControls.Visible = true;
            game = new Game(this);
            p1Up = false;
            p1Down = false;
            p1Shoot = false;
            p2Up = false;
            p2Down = false;
            p2Shoot = false;
            timer.Stop();
        }

        /// <summary>
        /// Event handler for click on the play button - starts game
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Arguments</param>
        private void pbPlay_Click(object sender, EventArgs e)
        {
            pbBackground.Visible = false;
            pbPlay.Visible = false;
            pbQuit.Visible = false;
            pbControls.Visible = false;
            shouldUpdate = true;
            timer.Start();
        }

        /// <summary>
        /// Event handler for mouseenter animations on play button
        /// </summary>
        private void pbPlay_MouseEnter(object sender, EventArgs e)
        {
            pbPlay.BackColor = Color.Transparent;
            pbPlay.Height += 10;
            pbPlay.Width += 10;
            pbPlay.Left -= 5;
            pbPlay.Top -= 5;
        }

        /// <summary>
        /// Event handler for mouseleave animations on play button
        /// </summary>
        private void pbPlay_MouseLeave(object sender, EventArgs e)
        {
            pbPlay.Height -= 10;
            pbPlay.Width -= 10;
            pbPlay.Left += 5;
            pbPlay.Top += 5;
        }

        /// <summary>
        /// Event handler for click on Quit
        /// </summary>
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

        /// <summary>
        /// Keydown handler for controls
        /// </summary>
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
                p1Up = true;
            if (e.KeyCode == Keys.S)
                p1Down = true;
            if (e.KeyCode == Keys.F)
                p1Shoot = true;
            if (e.KeyCode == Keys.Up)
                p2Up = true;
            if (e.KeyCode == Keys.Down)
                p2Down = true;
            if (e.KeyCode == Keys.NumPad0)
                p2Shoot = true;

            if (e.KeyCode == Keys.G)
                game.player1.activateShield();
            if (e.KeyCode == Keys.NumPad1)
                game.player2.activateShield();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
                p1Up = false;
            if (e.KeyCode == Keys.S)
                p1Down = false;
            if (e.KeyCode == Keys.F)
                p1Shoot = false;
            if (e.KeyCode == Keys.Up)
                p2Up = false;
            if (e.KeyCode == Keys.Down)
                p2Down = false;
            if (e.KeyCode == Keys.NumPad0)
                p2Shoot = false;
            if (e.KeyCode == Keys.Escape)
                goToMenu();
        }

        /// <summary>
        /// Paint handler
        /// </summary>
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            game.draw(e.Graphics);
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPProjectFAB
{
    class Game
    {
        public Player player1 { get; set; }
        public Player player2 { get; set; }

        Image image = Image.FromFile("..\\..\\img\\gamebg.jpg");

        Form1 form1;

        /// <summary>
        /// Creates new game
        /// </summary>
        /// <param name="f">Form reference</param>
        public Game(Form1 f)
        {
            form1 = f; // radi detali za ekranot (dolzhina, shirina), najverojatno kje sakame i na resizeend da napravime
                       // funkcija koja kje ja apdejtira ovaa promenliva neli
                       //startGame(); // za testiranje na iscrtuvanje
            player1 = new Player("Player 1", 0, form1.Height / 2 - 50, 50, 50, form1, 5, 10, 3);
            player2 = new Player("Player 2", form1.Width - 65, form1.Height / 2 - 50, 50, 50, form1, 5, -10, 3);
        }

        /// <summary>
        /// Updates the players before drawing them
        /// </summary>
        public void update()
        {
            checkCollisions();
            player1.update();
            player2.update();
        }

        /// <summary>
        /// Draw the players
        /// </summary>
        /// <param name="g">Graphics reference</param>
        public void draw(Graphics g)
        {
            g.DrawImage(image, 0, 0, 676, 502);
            //g.Clear(Color.Black);
            player1.draw(g);
            player2.draw(g);
            
        }
        
        /// <summary>
        /// Checks collision for player and bullet box models
        /// </summary>
        public void checkCollisions()
        {
            HashSet<Bullet> enemyBullets = player2.Bullets;
            foreach (Bullet bullet in enemyBullets)
            { // checks enemy bullets
                if (player1.checkCollision(player2, bullet))
                { // there is hit
                    //form1.shouldUpdate = false;
                    player1.getHit(1);
                    return;
                }
            }

            // now player1 bullets
            enemyBullets = player1.Bullets;
            foreach (Bullet bullet in enemyBullets)
            { // check every bullet
                if (player2.checkCollision(player1, bullet))
                { // we hit him
                    //form1.shouldUpdate = false;
                    player2.getHit(1);
                    return;
                }
            }

        }
    }
}

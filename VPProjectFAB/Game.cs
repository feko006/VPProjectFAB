using System;
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
        Form1 form1;

        public Game(Form1 f)
        {
            form1 = f; // radi detali za ekranot (dolzhina, shirina), najverojatno kje sakame i na resizeend da napravime
                       // funkcija koja kje ja apdejtira ovaa promenliva neli
                       //startGame(); // za testiranje na iscrtuvanje
            player1 = new Player("Player 1", 0, form1.Height / 2 - 50, 50, 50, form1, 5, 10);
            player2 = new Player("Player 2", form1.Width - 75, form1.Height / 2 - 50, 50, 50, form1, 5, 10);
        }

        public void update()
        {
            checkCollisions();
            player1.update();
            player2.update();
        }

        public void draw(Graphics g)
        {
            g.Clear(Color.Black);
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
                if (player1.checkCollision(bullet))
                { // there is hit
                    form1.shouldUpdate = false;
                    player1.getHit();
                    return;
                }
            }

            // now player1 bullets
            enemyBullets = player1.Bullets;
            foreach (Bullet bullet in enemyBullets)
            { // check every bullet
                if (player2.checkCollision(bullet))
                { // we hit him
                    form1.shouldUpdate = false;
                    player2.getHit();
                    return;
                }
            }

        }
    }
}

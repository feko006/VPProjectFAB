using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPProjectFAB
{
    class GameScene : Scene
    {
        public Player player1 { get; set; }
        public Player player2 { get; set; }
        Form1 form1;

        public GameScene(Form1 f)
        {
            form1 = f;
            player1 = new Player(0, form1.Height / 2 - 50, 50, 50, 5);
            player2 = new Player(form1.Width - 75, form1.Height / 2 - 50, 50, 50, 5);
        }

        public void draw(Graphics g)
        {
            g.Clear(Color.Black);
            player1.draw(g);
            player2.draw(g);
        }

        public void update()
        {
            checkCollisions();
            player1.update();
            player2.update();
        }
        /// <summary>
        /// Checks collision for player and bullet box models
        /// </summary>
        public void checkCollisions()
        {
            List<Bullet> enemyBullets = player2.Bullets;
            foreach (Bullet bullet in enemyBullets)
            { // checks enemy bullets
                if (player1.checkCollision(bullet))
                { // there is hit
                    player1.getHit();
                }
            }

            // now player1 bullets
            enemyBullets = player1.Bullets;
            foreach (Bullet bullet in enemyBullets)
            { // check every bullet
                if (player2.checkCollision(bullet))
                { // we hit him
                    player2.getHit();
                }
            }

        }
    }
}

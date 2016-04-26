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
        public const int BULLET_MAX_DISTANCE = 800; // od tepka staiv treba da se nashtima ova
                                                    // ova kje odluchi koga kje se unishti buletot
        public static bool p1up { get; set; }
        public static bool p1down { get; set; }
        public static bool p1shoot { get; set; }
        public static bool p2up { get; set; }
        public static bool p2down { get; set; }
        public static bool p2shoot { get; set; }


        public Game(Form1 f)
        {
            form1 = f; // radi detali za ekranot (dolzhina, shirina), najverojatno kje sakame i na resizeend da napravime
                       // funkcija koja kje ja apdejtira ovaa promenliva neli
                       //startGame(); // za testiranje na iscrtuvanje
            player1 = new Player(0, form1.Height / 2 - 50, 50, 50, 5, form1);
            player2 = new Player(form1.Width - 75, form1.Height / 2 - 50, 50, 50, 5, form1);
            p1up = false;
            p1down = false;
            p1shoot = false;
            p2up = false;
            p2down = false;
            p2shoot = false;
        }

        public void update()
        {
            checkCollisions();
            player1.update();
            if (p1up && !p1down)
                player1.moveUp();
            if (p1down && !p1up)
                player1.moveDown();
            if (p1shoot)
                player1.fireRight();
            player2.update();
            if (p2up && !p2down)
                player2.moveUp();
            if (p2down && !p2up)
                player2.moveDown();
            if (p2shoot)
                player2.fireLeft();
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

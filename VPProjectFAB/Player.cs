using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPProjectFAB
{
    class Player
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }

        public int Speed { get; set; } // player speed

        public List<Bullet> Bullets { get; set; }
        public int BulletSpeed { get; set; } // da ja dobiva kako argument + ili - od kaj puka

        public Player(int x, int y, int height, int width, int speed)
        {
            X = x;
            Y = y;
            Height = height;
            Width = width;
            Speed = speed;
            Bullets = new List<Bullet>(3);
            BulletSpeed = 5;
        }

        public void moveUp()
        {
            Y -= Speed;
        }

        public void moveDown()
        {
            Y += Speed;
        }

        public void shoot()
        {

        }

        public void getHit()
        {

        }

        /// <summary>
        /// Checks collisions with bullet
        /// </summary>
        /// <param name="b">bullet fired from the opponent</param>
        /// <returns>true if the bullet hits this player</returns>
        public bool checkCollision(Bullet b)
        {
            // If the bullets top left and top right points coordinates are between the Player top
            if ((X < b.X && b.X < X + Width) || (X < b.X + b.Width && b.X + b.Width < X + Width))
            {
                // check if there is really overlap
                if ((Y < b.Y && b.Y < Y + Height) || (Y < b.Y + b.Height && b.Y + b.Height < Y + Height))
                {
                    return true;
                }
            }

            return false; // there is no overlap if this is reached
        }

        public void draw(Graphics g)
        {
            // draw the player
            

            // then bullets

            foreach (Bullet bullet in Bullets)
            {
                bullet.draw(g);
            }
        }

        public void update()
        {
            foreach (Bullet bullet in Bullets)
            {
                bullet.X += BulletSpeed; // moves the bullet forward
                if (bullet.X > Game.BULLET_MAX_DISTANCE)
                {
                    // destroy the bullet, maybe List is not perfect?
                }
            }
        }
    }
}

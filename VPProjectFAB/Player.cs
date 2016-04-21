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
        Form1 form;

        public int X { get; set; }
        public int Y { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }

        public int Speed { get; set; } // player speed

        public List<Bullet> Bullets { get; set; }
        public int BulletSpeed { get; set; } // da ja dobiva kako argument + ili - od kaj puka
        //ja prenesuva formata
        public Player(int x, int y, int height, int width, int speed, Form1 form)
        {
            this.form = form;
            X = x;
            Y = y;
            Height = height;
            Width = width;
            Speed = speed;
            Bullets = new List<Bullet>(3);
            BulletSpeed = 5;
        }
        //staven limit; MOVE DOWN NE RABOTE SO HEIGHT
        public void moveUp()
        {
            if (Y >= 0)
                Y -= Speed;
        }

        public void moveDown()
        {
            //height not working right fix dis sniz
            //fixt
            if (Y + Height <= form.Height - 45)
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

            g.FillRectangle(Brushes.White, X, Y, Width, Height);

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
                bullet.move();
                // bullet knows when to commit suicide Kappa
                // najverojatno kje se predava nekoj argument za dolzhina na ekran preku nekoi funkcii
                // pa kje znae ako x > that suicide() xD
                // ili da merime kolku rastojanie ima pominato i da ima max rastojanie
                // shto kje se predava od samata forma pa nataka
                // DA SE RAZMISLI DALI BULLETS DA SE CHUVAAT VO SET
            }
        }
    }
}

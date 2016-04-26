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

        public int Speed { get; set; }
        
        public HashSet<Bullet> Bullets { get; set; }

        //ja prenesuva formata iskreno mnoogu pofino bi bilo width height da se chuvaat vo player
        //prenesuva samo referenca, podobro e referenca bidejki formata mozhe da se menuva dur se igra
        //taka sekogash kje se vadi height pravilen od formata ako e brojche kje treba rachno da se menuva
        public Player(int x, int y, int height, int width, int speed, Form1 form)
        { // za form i game da ne se zamaraat so tie brojki voopshto
            this.form = form;
            X = x;
            Y = y;
            Height = height;
            Width = width;
            Speed = speed;
            Bullets = new HashSet<Bullet>();
        }
        //staven limit; MOVE DOWN NE RABOTE SO HEIGHT
        public void moveUp()
        {
            if (Y >= 0)
                Y -= Speed;
        }

        public void moveDown()
        {
            if (Y + Height <= form.Height - 45)
                Y += Speed;
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

        public void fireRight()
        {
            Bullets.Add(new Bullet(X + 20, Y + 20, true));
        }

        public void fireLeft()
        {
            Bullets.Add(new Bullet(X, Y + 20, false));
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
            HashSet<Bullet> deadList = new HashSet<Bullet>();
            if (Bullets.Count > 0)
                foreach (Bullet bullet in Bullets)
                {
                    bullet.move();
                    if (bullet.Distance >= form.Width)
                        deadList.Add(bullet);
                    //if (bullet.X > form.Width) // ovde go nishtam treba da se smisli so iterator namesto vaka
                    //    Bullets.Remove(bullet); // mislam deka taka kje go pretupime bulet deka ne treba
                    // samo da zgine tuku da se izbrishe od playerot
                    // bullet knows when to commit suicide Kappa
                    // najverojatno kje se predava nekoj argument za dolzhina na ekran preku nekoi funkcii
                    // pa kje znae ako x > that suicide() xD
                    // ili da merime kolku rastojanie ima pominato i da ima max rastojanie
                    // shto kje se predava od samata forma pa nataka
                    // DA SE RAZMISLI DALI BULLETS DA SE CHUVAAT VO SET
                    // vaka mi se vide najdobro da se reshi ova
                }
            if (deadList.Count > 0) 
                foreach (Bullet bullet in deadList)
                {
                    Bullets.Remove(bullet);
                }
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPProjectFAB
{
    class Player
    {
        Form1 form;
        public string Name { get; set; }

        public int X { get; set; }
        public int Y { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }

        public int Speed { get; set; }// player speed
        public int BulletSpeed { get; set; }//bullet speed

        //public List<Bullet> Bullets { get; set; } lista e malku nz
        public HashSet<Bullet> Bullets { get; set; }

        //ja prenesuva formata iskreno mnoogu pofino bi bilo width height da se chuvaat vo player
        public Player(string name, int x, int y, int height, int width, Form1 form, int speed, int bulletSpeed)
        { // za form i game da ne se zamaraat so tie brojki voopshto
            this.form = form;
            Name = name;
            X = x;
            Y = y;
            Height = height;
            Width = width;
            Speed = speed;
            BulletSpeed = bulletSpeed;
            Bullets = new HashSet<Bullet>();
        }

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
            DialogResult dr = MessageBox.Show(string.Format("{0} lost...", Name), "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            if (dr == DialogResult.OK)
            {
                form.goToMenu();
            }
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
            Bullets.Add(new Bullet(X + 20, Y + 20, 5, 50, BulletSpeed));
        }
        
        public void fireLeft()
        {
            Bullets.Add(new Bullet(X, Y + 20, 5, 50, -BulletSpeed));
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
            if (Bullets.Count > 0)
                foreach (Bullet bullet in Bullets)
                {
                    bullet.move();
                    //if (bullet.X > form.Width) // ovde go nishtam treba da se smisli so iterator namesto vaka
                    //    Bullets.Remove(bullet); // mislam deka taka kje go pretupime bulet deka ne treba
                    // samo da zgine tuku da se izbrishe od playerot
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

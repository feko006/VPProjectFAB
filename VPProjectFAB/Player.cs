using System;
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
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }

        public int Speed { get; set; }// player speed
        public int BulletSpeed { get; set; }//bullet speed

        //public List<Bullet> Bullets { get; set; } lista e malku nz
        public HashSet<Bullet> Bullets { get; set; }

        public bool stahp { get; set; }

        public bool SpecialPower { get; set; }
        private int specialPowerCounter;

        private const int SPECIAL_POWER_TIME = 200;
        private bool blinkGreen;

        //ja prenesuva formata iskreno mnoogu pofino bi bilo width height da se chuvaat vo player
        public Player(string name, int x, int y, int height, int width, Form1 form, int speed, int bulletSpeed, int maxHealth)
        { // za form i game da ne se zamaraat so tie brojki voopshto
            this.form = form;
            Name = name;
            X = x;
            Y = y;
            Height = height;
            Width = width;
            Speed = speed;
            BulletSpeed = bulletSpeed;
            CurrentHealth = MaxHealth = maxHealth;
            Bullets = new HashSet<Bullet>();
            stahp = false;

            SpecialPower = false;
            specialPowerCounter = 0;
            blinkGreen = false;
        }

        public void moveUp()
        {
            if (Y >= 60)
                Y -= Speed;
        }

        public void moveDown()
        {
            if (Y + Height <= form.Height - 45)
                Y += Speed;
        }

        public void getHit(int damage)
        {
            if (SpecialPower)
            { // ako ima hit ama ima shild
                SpecialPower = false;
                return; // Izbegnuva hit zaradi shildot xD
            }
            CurrentHealth = CurrentHealth - damage;
            if(CurrentHealth <= 0)
            {
                stahp = true;
                DialogResult dr = MessageBox.Show(string.Format("{0} lost...", Name), "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                if (dr == DialogResult.OK)
                {
                    form.goToMenu();
                }
            }
        }

        public void activateShield()
        {
            if (specialPowerCounter <= 0 && !SpecialPower)
            {
                SpecialPower = true;
                specialPowerCounter = SPECIAL_POWER_TIME;
            }
        }

        public void removeBullet(Bullet b)
        {
            Bullets.Remove(b);
        }

        /// <summary>
        /// Checks collisions with bullet
        /// </summary>
        /// <param name="b">bullet fired from the opponent</param>
        /// <returns>true if the bullet hits this player</returns>
        public bool checkCollision(Player p, Bullet b)
        {
            // If the bullets top left and top right points coordinates are between the Player top
            if ((X < b.X && b.X < X + Width) || (X < b.X + b.Width && b.X + b.Width < X + Width))
            {
                // check if there is really overlap
                if ((Y < b.Y && b.Y < Y + Height) || (Y < b.Y + b.Height && b.Y + b.Height < Y + Height))
                {
                    p.removeBullet(b);
                    return true; // there is overlap
                }
            }

            return false; // there is no overlap if this is reached
        }
        
        public void fire()
        {
            Bullets.Add(new Bullet(X, Y + 20, 5, 50, BulletSpeed));
        }

        public void draw(Graphics g)
        {
            Pen p = new Pen(Color.White, 1);

            // draw the player
            Brush playerColor = Brushes.White; // belo default
            if (blinkGreen)
            {
                playerColor = Brushes.Green; // da svetne zeleno
            }
            if (SpecialPower) // ako e aktiviran shild
            {
                playerColor = Brushes.Blue; // blu
            }

            g.FillRectangle(playerColor, X, Y, Width, Height);

            // then bullets

            foreach (Bullet bullet in Bullets)
            {
                bullet.draw(g);
            }

            // draw the healthbar
            Brush hpColor = Brushes.White;
            if (CurrentHealth <= 1)
                hpColor = Brushes.Red;
            int oneBar = 225 / MaxHealth;
            if (BulletSpeed > 0) // if its the left player (player1)
            {
                
                g.FillRectangle(hpColor, 75, 10, oneBar * CurrentHealth, 20);
                g.DrawRectangle(p, 75 + oneBar * CurrentHealth, 10, oneBar * (MaxHealth - CurrentHealth), 20);
            }
            if(BulletSpeed < 0) // the other player
            {
                g.FillRectangle(hpColor, form.Width - 325, 10, oneBar * CurrentHealth, 20);
                g.DrawRectangle(p, form.Width - 325 + oneBar * CurrentHealth, 10, oneBar * (MaxHealth - CurrentHealth), 20);
            }

            p.Dispose();

            if (stahp)
                form.shouldUpdate = false;
        }

        public void update()
        {
            if (specialPowerCounter > 0 && !SpecialPower)
            specialPowerCounter--; // se namaluva tajmerot neli
            if (specialPowerCounter == 1 || specialPowerCounter == 2) // koga kje stane 0 aka slobodno
                blinkGreen = true;//kje blinkne zeleno
            else
                blinkGreen = false;

            Console.Write(" '" + specialPowerCounter + "' ");
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

                    // si napravivme diskusija ovde mislam deka mozheme da go izbrisheme 
                    // celovo so komentarive deka it just works
                }
        }
    }
}

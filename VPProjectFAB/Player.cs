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
        public int Speed { get; set; }
        public List<Bullet> Bullets { get; set; }

        public Player(int x, int y , int height, int width, int speed)
        {
            X = x;
            Y = y;
            Height = height;
            Width = width;
            Speed = speed;
            Bullets = new List<Bullet>(3);
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

        public bool checkCollision(Bullet b)
        {
            return false;
        }

        public void draw(Graphics g)
        {

        }
    }
}

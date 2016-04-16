using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPProjectFAB
{
    class Bullet
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int Speed { get; set; }

        public Bullet(int x, int y, int height, int width, int speed)
        {
            X = x;
            Y = y;
            Height = height;
            Width = width;
            Speed = speed;
        }

        public void move()
        {
            X += Speed;
        }

        public void draw(Graphics g)
        {

        }
    }
}

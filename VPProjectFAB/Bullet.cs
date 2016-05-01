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

        public int Height { get; set; } = 5;
        public int Width { get; set; } = 50;
        public int Speed { get; set; } = 30;

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
            g.FillRectangle(Brushes.White, X, Y, Width, Height);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPProjectFAB
{
    /// <summary>
    /// Bullets that are fired by the player
    /// Holds information about the bullet, drawing it and movement
    /// </summary>
    class Bullet
    {
        public int X { get; set; }
        public int Y { get; set; }

        public int Height { get; set; } = 5;
        public int Width { get; set; } = 50;
        public int Speed { get; set; } = 30;

        /// <summary>
        /// Creates new bullet
        /// </summary>
        /// <param name="x">Starting X coordinate of the bullet</param>
        /// <param name="y">Starting Y coordinate of the bullet</param>
        /// <param name="height">Height of the bullet</param>
        /// <param name="width">Width of the bullet</param>
        /// <param name="speed">Speed of the bullet</param>
        public Bullet(int x, int y, int height, int width, int speed)
        {
            X = x;
            Y = y;
            Height = height;
            Width = width;
            Speed = speed;
        }
        
        /// <summary>
        /// Move the bullet
        /// </summary>
        public void move()
        {
            X += Speed;
        }

        /// <summary>
        /// Draw the bullet
        /// </summary>
        /// <param name="g">Graphics reference</param>
        public void draw(Graphics g)
        {
            g.FillRectangle(Brushes.White, X, Y, Width, Height);
        }
    }
}

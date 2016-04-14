using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPProjectFAB
{
    class Bullet
    {
        //public int XCoord { get; set; }
        //public int YCoord { get; set; }
        public Position pos { get; set; } // vaka valjda poez bi bilo pr: bullet.pos.x mozhebi namesto bullet.XCoord?
                                          // ali predlog e ofc
        public int Velocity { get; set; }

        public Bullet()
        {
            
        }

        public void move()
        {
            
        }

        public class Position
        {
            public int X { get; set; }
            public int Y { get; set; }

            public Position()
            {
                X = 0;
                Y = 0;
            }

            public Position(int posX, int posY)
            {
                X = posX;
                Y = posY;
            }
        }


    }
}

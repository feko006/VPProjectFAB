using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPProjectFAB
{
    class Game
    {
        Scene scene;

        public Game()
        {

        }

        public void update()
        {
            scene.update();
        }

        public void draw(Graphics g)
        {
            scene.draw(g);
        }
    }
}

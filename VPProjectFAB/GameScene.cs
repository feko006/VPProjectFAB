using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPProjectFAB
{
    class GameScene : Scene
    {
        public Player player1 { get; set; }
        public Player player2 { get; set; }

        public GameScene()
        {
            //player1 = new Player();
        }

        public void draw(Graphics g)
        {
            player1.draw(g);
            player2.draw(g);
        }

        public void update()
        {
            throw new NotImplementedException();
        }

        public void checkCollisions()
        {

        }
    }
}

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
        public const int BULLET_MAX_DISTANCE = 800; // od tepka staiv treba da se nashtima ova
                                                    // ova kje odluchi koga kje se unishti buletot
        Scene scene;


        public Game()
        {
            goToMenu();
        }

        public void startGame()
        {
            scene = new GameScene();
        }

        public void goToMenu()
        {
            scene = new MenuScene();
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

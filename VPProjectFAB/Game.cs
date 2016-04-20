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
        public Scene scene;
        Form1 form1;


        public Game(Form1 f)
        {
            form1 = f; // radi detali za ekranot (dolzhina, shirina), najverojatno kje sakame i na resizeend da napravime
                       // funkcija koja kje ja apdejtira ovaa promenliva neli
            //startGame(); // za testiranje na iscrtuvanje
            goToMenu();
        }

        public void startGame()
        {
            scene = new GameScene(form1);
        }
        
        public void goToMenu()
        {
            scene = new MenuScene(form1);
        }

        public void update()
        {
            scene.update();
        }

        public void draw(Graphics g)
        {
            scene.draw(g);
        }
        
        //Key down event gi povikuva, ako ne e vo gamescene togas nema da se desi nisho xd
        public void player1Up()
        {
            Player p = scene.getPlayer(1);
            if (p != null)
                p.moveUp();
        }

        public void player1Down()
        {
            Player p = scene.getPlayer(1);
            if (p != null)
                p.moveDown();
        }
    }
}

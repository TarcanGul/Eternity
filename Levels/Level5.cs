using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eternity.Levels
{
    class Level5 : WallLevel
    {
        public Level5() : base()
        {
            Level = new int[,]
            {
                { 1,0,1,1,1,1,1,1,0,2 },
                { 0,0,0,0,0,0,0,0,0,1 },
                { 1,0,1,1,0,1,1,1,1,1 },
                { 1,0,1,0,1,1,0,1,0,1 },
                { 0,0,1,1,1,0,1,0,1,0 },
                { 0,0,0,0,0,0,0,1,1,1 },
                { 1,0,1,1,1,1,0,1,1,1 },
                { 1,1,1,1,1,0,0,1,1,1 },
                { 0,0,0,0,0,0,1,1,0,1 },
                { 3,1,1,1,0,0,0,1,0,1 }
            };
            createLevel();
            KillerGreen enemy1 = new KillerGreen(50, 50, 50, true, false, 5);
            enemy1.Threshold_x_left = 10;
            enemy1.Threshold_x_right = 400;
            AddEnemy(enemy1);
            
            KillerGreen enemy2 = new KillerGreen(250, 250, 30, false, true, 35);
            enemy2.Threshold_y_up = 100;
            enemy2.Threshold_y_down = 350;
            AddEnemy(enemy2);

            KillerGreen enemy4 = new KillerGreen(250, 250, 30, true, true, 20);
            AddEnemy(enemy4);

            RedSquare enemy3 = new RedSquare(80, 80, 40);
            AddEnemy(enemy3);

            RedSquare enemy5 = new RedSquare(520, 600, 50);
            AddEnemy(enemy5);

            RedSquare enemy6 = new RedSquare(480, 520, 20);
            AddEnemy(enemy6);

            Enemy enemy7 = new KillerGreen(250, 200, 30, true, true, 30);
            AddEnemy(enemy7);
        }
    }
}

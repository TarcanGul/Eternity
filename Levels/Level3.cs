using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eternity.Levels
{
    class Level3 : WallLevel
    {
        public Level3() : base()
        {
            Level = new int[,]
            {
                { 1,1,1,1,1,1,1,1,0,1 },
                { 0,0,0,0,0,0,0,1,0,1 },
                { 1,0,1,0,0,1,1,1,0,1 },
                { 1,0,1,0,0,1,0,0,0,1 },
                { 0,0,1,0,0,0,0,0,1,0 },
                { 0,0,1,1,1,0,0,0,0,0 },
                { 1,0,1,1,1,0,0,1,1,1 },
                { 3,0,1,0,0,0,0,0,0,1 },
                { 0,0,1,0,1,1,1,1,0,1 },
                { 0,1,1,1,0,0,0,1,0,2 }
            };
            createLevel();

            Enemy enemy1 = new RedSquare(90, 90, 40);
            AddEnemy(enemy1);

            Enemy enemy2 = new RedSquare(300, 90, 50);
            AddEnemy(enemy2);

            Enemy enemy3 = new RedSquare(300, 180, 60);
            AddEnemy(enemy3);

            Enemy enemy4 = new RedSquare(400, 250, 80);
            AddEnemy(enemy4);

            Enemy enemy5 = new RedSquare(480, 400, 80);
            AddEnemy(enemy5);

            Enemy enemy6 = new RedSquare(480, 480, 80);
            AddEnemy(enemy6);

            Enemy enemy7 = new KillerGreen(20, 750, 40, true, false, 50);
            AddEnemy(enemy7);

            Enemy enemy8 = new KillerGreen(20, 400, 40, true, false, 30);
            AddEnemy(enemy8);

            Enemy enemy9 = new KillerGreen(580, 50, 40, false, true, 30);
            AddEnemy(enemy9);

            Enemy enemy10 = new KillerGreen(20, 140, 30, true, false, 20);
            AddEnemy(enemy10);
        }
    }
}

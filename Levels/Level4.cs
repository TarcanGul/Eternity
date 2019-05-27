using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eternity.Levels
{
    class Level4 : WallLevel
    {
        public Level4() : base()
        {
            Level = new int[,]
            {
                { 1,2,1,1,1,1,1,1,0,1 },
                { 0,0,0,0,0,0,0,1,0,1 },
                { 1,0,1,0,0,1,1,1,1,1 },
                { 1,0,1,0,0,1,0,1,0,1 },
                { 0,0,1,0,0,0,0,0,1,0 },
                { 0,0,1,1,1,0,0,0,0,0 },
                { 1,0,1,1,1,0,0,1,1,1 },
                { 0,0,1,0,0,0,0,0,0,1 },
                { 0,0,1,1,0,1,1,1,0,1 },
                { 0,1,1,1,3,0,0,1,0,1 }
            };
            createLevel();
            KillerGreen enemy1 = new KillerGreen(200, 200, 50, true, false, 10);
            AddEnemy(enemy1);

            Enemy enemy2 = new KillerGreen(200, 400, 50, true, false, 20);
            AddEnemy(enemy2);

            Enemy enemy3 = new KillerGreen(200, 500, 40, true, false, 30);
            AddEnemy(enemy3);

            Enemy enemy4 = new RedSquare(100, 100, 20);
            AddEnemy(enemy4);

            Enemy enemy5 = new RedSquare(500, 560, 50);
            AddEnemy(enemy5);

        }
        
    }
}

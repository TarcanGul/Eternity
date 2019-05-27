using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eternity.Levels
{
    class Level2 : WallLevel
    {
        public Level2() : base()
        {
            Level = new int[,]
            {
                { 1,1,1,1,1,1,1,1,2,1 },
                { 0,0,0,0,0,0,0,1,0,1 },
                { 1,1,1,0,0,1,1,1,0,1 },
                { 1,0,1,0,0,1,0,0,0,1 },
                { 0,0,1,0,0,1,0,0,1,0 },
                { 0,0,1,1,1,0,0,0,0,0 },
                { 1,0,0,1,1,0,0,1,1,1 },
                { 1,1,1,0,0,0,0,0,0,1 },
                { 0,0,0,0,0,0,1,0,0,1 },
                { 3,1,1,1,0,0,0,0,0,1 }
            };
            createLevel();

            RedSquare square1 = new RedSquare(350, 700, 90);
            AddEnemy(square1);

            RedSquare square2 = new RedSquare(400, 400, 50);
            AddEnemy(square2);

            RedSquare square3 = new RedSquare(500, 350, 50);
            AddEnemy(square3);

            KillerGreen killer1 = new KillerGreen(400, 300, 50, true, false, 6);
            killer1.Threshold_x_left = 350;
            AddEnemy(killer1);

            KillerGreen killer2 = new KillerGreen(400, 200, 50, true, false, 8);
            killer2.Threshold_x_left = 350;
            AddEnemy(killer2);

            KillerGreen killer3 = new KillerGreen(400, 100, 50, true, false, 15);
            killer3.Threshold_x_left = 300;
            AddEnemy(killer3);
        }
    }
}

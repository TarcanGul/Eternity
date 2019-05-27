using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eternity.Levels
{
    class Level1 : WallLevel
    {
        
        public Level1() : base()
        {
            Level = new int[,]
            {
                { 2,0,1,1,1,1,1,1,1,1 },
                { 0,0,0,0,0,0,0,0,0,1 },
                { 1,1,1,0,0,1,0,0,0,1 },
                { 1,0,1,0,0,1,0,0,0,0 },
                { 1,0,1,0,0,1,0,0,0,0 },
                { 0,0,1,1,1,0,0,0,0,0 },
                { 1,0,0,0,1,0,0,1,1,1 },
                { 0,0,0,0,0,0,0,0,0,1 },
                { 0,0,0,0,0,0,1,0,0,1 },
                { 3,0,0,0,0,0,0,0,0,1 }
            };
            createLevel();

            RedSquare redSquare1 = new RedSquare(80, 640, 80);
            AddEnemy(redSquare1);

            RedSquare redSquare2 = new RedSquare(300, 100, 40);
            AddEnemy(redSquare2);

            RedSquare redSquare3 = new RedSquare(580, 240, 220);
            AddEnemy(redSquare3);
        }
    }
}

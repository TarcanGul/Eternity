using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eternity
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
        }
    }
}

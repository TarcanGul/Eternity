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
            KillerGreen enemy1 = new KillerGreen(200, 200, 50);
            AddEnemy(enemy1);
        }
        
    }
}

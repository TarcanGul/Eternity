using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eternity
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
        }
    }
}

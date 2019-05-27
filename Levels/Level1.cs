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
        }
    }
}

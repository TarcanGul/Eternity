using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;

namespace Eternity
{
    class Wall
    {
        int pos_x;
        int pos_y;
        public int size = 80;
        public Color color = Color.Black;

        public Wall(int pos_x, int pos_y)
        {
            this.pos_x = pos_x;
            this.pos_y = pos_y;
        }

        public int x
        {
            get
            {
                return pos_x;
            }
            set
            {
                pos_x = value;
            }
        }

        public int y
        {
            get
            {
                return pos_y;
            }
            set
            {
                pos_y = value;
            }
        }
    }

    class SuccessWall : Wall
    {
        public SuccessWall(int pos_x, int pos_y) : base(pos_x, pos_y)
        {
            this.color = Color.GreenYellow;
        }
    }

    class SpawnWall : Wall
    {
        public SpawnWall(int pos_x, int pos_y) : base(pos_x, pos_y)
        {
            this.color = Color.Magenta;
        }
    }
    abstract class WallLevel
    {
        const int X_OFFSET = 0;
        const int Y_OFFSET = 0;
        Wall spawnWall = null;
        //The level design.
        /**
         * 0: Available for walking.
         * 1: Wall
         * 2: Ending point
         * 3: Starting point
         * 
         * */
        int[,] level;
        

        List<Wall> allWalls;

        int wall_size = 80;
        int character_size = 30;

        public WallLevel()
        {
            allWalls = new List<Wall>();
            
        }

        public int[,] Level
        {
            get
            {
                return level;
            }
            set
            {
                level = value;
            }
        }

        public void createLevel()
        {
            if (level == null) return;
            for (int r = 0; r < level.GetLength(0); r++)
            {
                for (int c = 0; c < level.GetLength(1); c++)
                {
                    Wall wall = null;
                    if (level[r, c] == 1)
                    {
                        wall = new Wall(X_OFFSET + wall_size * c, Y_OFFSET + wall_size * r);
                        allWalls.Add(wall);
                    }
                    else if (level[r, c] == 2)
                    {
                        wall = new SuccessWall(X_OFFSET + wall_size * c, Y_OFFSET + wall_size * r);
                        allWalls.Add(wall);
                    }
                    else if (level[r, c] == 3)
                    {
                        wall = new SpawnWall(X_OFFSET + wall_size * c, Y_OFFSET + wall_size * r);
                        spawnWall = wall;
                    }
                    else continue;

                    allWalls.Add(wall);
                }
            }
        }

        public List<Wall> AllWalls
        {
            get
            {
                return allWalls;
            }
        }

        public Wall GetSpawnPoint()
        {
            //if(spawnWall == null) throw exception. 
            return spawnWall;
        }

        public bool InWallBoundaries(int player_x, int player_y)
        {
            const int FINE_TUNE = 10;
            int n = level.GetLength(0);
            int index_x = player_x / wall_size;
            int index_y = player_y / wall_size;
            int index_rt_x = (player_x + character_size - FINE_TUNE) / wall_size;
            int index_ld_y = (player_y + character_size - FINE_TUNE) / wall_size;
            int index_rd_x = (player_x + character_size - FINE_TUNE) / wall_size;
            int index_rd_y = (player_y + character_size - FINE_TUNE) / wall_size;

            Debug.WriteLine("Player is in row {0}, col {1})", index_x, index_y);
            return index_y < n && index_x < n && level[index_y, index_x] == 1 
                || index_y < n && index_rt_x < n && level[index_y, index_rt_x] == 1 
                || index_ld_y < n && index_x < n && level[index_ld_y, index_x] == 1 
                || index_rd_y < n && index_rd_x < n && level[index_rd_y, index_rd_x] == 1;
        }

        public bool DestinationReached(int player_x, int player_y)
        {
            const int FINE_TUNE = 10;
            int n = level.GetLength(0);
            int index_x = player_x / wall_size;
            int index_y = player_y / wall_size;
            int index_rt_x = (player_x + character_size - FINE_TUNE) / wall_size;
            int index_ld_y = (player_y + character_size - FINE_TUNE) / wall_size;
            int index_rd_x = (player_x + character_size - FINE_TUNE) / wall_size;
            int index_rd_y = (player_y + character_size - FINE_TUNE) / wall_size;

            Debug.WriteLine("Player is in row {0}, col {1})", index_x, index_y);
            return index_y < n && index_x < n && level[index_y, index_x] == 2
                || index_y < n && index_rt_x < n && level[index_y, index_rt_x] == 2
                || index_ld_y < n && index_x < n && level[index_ld_y, index_x] == 2
                || index_rd_y < n && index_rd_x < n && level[index_rd_y, index_rd_x] == 2;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;


namespace Eternity
{
    class GameCharacter
    {
        const int DEF_SIZE = 30;
        static Color DEF_COLOR = Color.Blue;
        Graphics callingGraphics;

        
        int pos_x;
        int pos_y;
        int size = DEF_SIZE;
        Color c = DEF_COLOR;

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

        public int Size
        {
            get
            {
                return size;
            }
            set
            {
                size = value;
            }
        }

        public Color color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
            }
        }

        public GameCharacter(int x, int y, Graphics g, SolidBrush brush)
        {
            pos_x = x;
            pos_y = y;
            callingGraphics = g;
            g.FillEllipse(brush, pos_x, pos_y, size, size);
        }


        
    }
}

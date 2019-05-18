using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Eternity
{
    public abstract class Enemy
    {
        int x_pos;
        int y_pos;
        int size;
        public int x { get { return x_pos; } set { x_pos = value; } }
        public int y { get { return y_pos; } set { y_pos = value; } }
        public int Size { get { return size; } set { size = value; } }

        protected Color color { get; set; }

        protected Enemy(int x_pos, int y_pos, int size)
        {
            this.x_pos = x_pos;
            this.y_pos = y_pos;
            this.size = size;
        }

        public abstract void DrawEnemy(Graphics g, SolidBrush b);
    }

    public class RedSquare : Enemy
    {
        public RedSquare(int x_pos, int y_pos, int size) : base(x_pos, y_pos, size)
        {
            this.color = Color.Red;
        }

        override
        public void DrawEnemy(Graphics g, SolidBrush b)
        {
            b.Color = color;
            g.FillRectangle(b, this.x, this.y, this.Size, this.Size);
        }
    }
}

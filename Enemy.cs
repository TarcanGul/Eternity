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
        public int x { get; set; }
        public int y { get; set; }
        public int Size { get; set; }
        protected Color Color { get; set; }

        protected Enemy(int x_pos, int y_pos, int size)
        {
            this.x = x_pos;
            this.y = y_pos;
            this.Size = size;
        }

        public abstract void DrawEnemy(Graphics g, SolidBrush b);
    }

    public abstract class MovingEnemy : Enemy
    {
        protected MovingEnemy(int x_pos, int y_pos, int size) : base(x_pos, y_pos, size)
        {
            this.x = x_pos;
            this.y = y_pos;
            this.Size = size;
        }

        public abstract void RedrawEnemy(Graphics g, SolidBrush b);
    }

    public class RedSquare : Enemy
    {
        public RedSquare(int x_pos, int y_pos, int size) : base(x_pos, y_pos, size)
        {
            this.Color = Color.Red;
        }

        override
        public void DrawEnemy(Graphics g, SolidBrush b)
        {
            b.Color = Color;
            g.FillRectangle(b, this.x, this.y, this.Size, this.Size);
        }
    }

    public class KillerGreen : MovingEnemy
    {
        int Threshold_x_right { get; set; } = MainFrame.FORM_WIDTH;
        int Threshold_x_left { get; set; } = 0;
        int Threshold_y_up { get; set; } = 0;
        int Threshold_y_down { get; set; } = MainFrame.FORM_HEIGHT;
        bool goingRight = true;
        public KillerGreen(int x_pos, int y_pos, int size) : base(x_pos, y_pos, size)
        {
            this.Color = Color.Green;
        }

        override
        public void DrawEnemy(Graphics g, SolidBrush b)
        {
            b.Color = Color;
            g.FillRectangle(b, this.x, this.y, this.Size, this.Size);
        }

        override
        public void RedrawEnemy(Graphics g, SolidBrush b)
        {


            if (goingRight && this.x < Threshold_x_right - 100)
            {
                this.x += 5;
            }
            else if (this.x > Threshold_x_left + 100)
            {
                goingRight = false;
                this.x -= 5;
            }
            else if (!goingRight && this.x <= Threshold_x_left + 100)
                goingRight = true;
        }
    }
}

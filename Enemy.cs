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
        

        protected Enemy(int x_pos, int y_pos, int size)
        {
            this.x = x_pos;
            this.y = y_pos;
            this.Size = size;
        }

        public abstract void DrawEnemy(Graphics g);
    }

    public abstract class MovingEnemy : Enemy
    {
        public int Threshold_x_right { get; set; } = MainFrame.FORM_WIDTH -100;
        public int Threshold_x_left { get; set; } = 0;
        public int Threshold_y_up { get; set; } = 0;
        public int Threshold_y_down { get; set; } = MainFrame.FORM_HEIGHT - 100;


        protected MovingEnemy(int x_pos, int y_pos, int size) : base(x_pos, y_pos, size)
        {
            this.x = x_pos;
            this.y = y_pos;
            this.Size = size;
        }

        public abstract void MoveEnemy();
    }

    public class RedSquare : Enemy
    {
        Image WallImage = Image.FromFile("../../Images/RedSquare.png");
        public RedSquare(int x_pos, int y_pos, int size) : base(x_pos, y_pos, size)
        {
        }

        override
        public void DrawEnemy(Graphics g)
        {
            g.DrawImage(WallImage, this.x, this.y, this.Size, this.Size);
        }
    }

    public class KillerGreen : MovingEnemy
    {
        Image WallImage = Image.FromFile("../../Images/GreenKiller.png");
        bool goingRight = true;
        bool goingDown = true;
        bool moveHorizontal;
        bool moveVertical;
        int speed;
        public KillerGreen(int x_pos, int y_pos, int size, bool moveHorizontal, bool moveVertical, int speed) : base(x_pos, y_pos, size)
        {
            this.moveHorizontal = moveHorizontal;
            this.moveVertical = moveVertical;
            this.speed = speed;
        }

        override
        public void DrawEnemy(Graphics g)
        {
            g.DrawImage(WallImage, this.x, this.y, this.Size, this.Size);
        }

        override
        public void MoveEnemy()
        {
            if (moveHorizontal)
            {
                if (goingRight && this.x < Threshold_x_right)
                {
                    this.x += speed;
                }
                else if (this.x > Threshold_x_left)
                {
                    goingRight = false;
                    this.x -= speed;
                }
                else if (!goingRight && this.x <= Threshold_x_left)
                    goingRight = true;
            }
            if (moveVertical)
            {
                if (goingDown && this.y < Threshold_y_down)
                {
                    this.y += speed;
                }
                else if (this.y > Threshold_y_up)
                {
                    goingDown = false;
                    this.y -= speed;
                }
                else if (!goingDown && this.y <= Threshold_y_up)
                    goingDown = true;
            }
            

        }
    }
}

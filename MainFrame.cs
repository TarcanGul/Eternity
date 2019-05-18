using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Diagnostics;

namespace Eternity
{
    public partial class MainFrame : Form
    {
        //Menu controls.
        Label titleLabel;
        Button startButton;
        Button helpButton;

        const int FORM_WIDTH = 800;
        const int FORM_HEIGHT = 800;
        const int DEF_BUTTON_WIDTH = FORM_WIDTH / 8;
        const int DEF_BUTTON_HEIGHT = FORM_HEIGHT / 16;
        const int FINAL_LEVEL = 3;

        Font greetingFont;
    
        private Bitmap DrawingArea;
        Pen pen;
        SolidBrush brush;
        Graphics g;

        GameCharacter player;
        Wall spawnPoint;
        WallLevel level;

        int currentLevel = 1;

        bool keyboardHandlerEnabled = true;

     
        public MainFrame()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(this.OpenPaintEvent);
            DrawingArea = new Bitmap(FORM_WIDTH, FORM_HEIGHT, PixelFormat.Format24bppRgb);
            g = Graphics.FromImage(DrawingArea);
            pen = new Pen(Color.Green);
            brush = new SolidBrush(Color.Red);
            this.Text = @"Tarcan's Room";
            this.ClientSize = new Size(FORM_WIDTH, FORM_HEIGHT);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            this.HelpButton = true;
            this.ControlBox = true;
            this.BackColor = Color.AntiqueWhite;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(this.KeyBoardPressed);
            this.DoubleBuffered = true;
        }

        private void MainFrame_Load(object sender, EventArgs e)
        {
            ShowMenu();
        }

        private void ShowMenu()
        {
            keyboardHandlerEnabled = false;
            this.Text = "Eternity Menu";
            AddMenuLabels();
            AddMenuButtons();
            AddDecorations();

        }

        private void AddMenuLabels()
        {

            titleLabel = new Label();
            titleLabel.Size = new Size(FORM_WIDTH, FORM_HEIGHT / 4);
            titleLabel.Left = 0;
            titleLabel.Top = 0;
            greetingFont = new Font(titleLabel.Font.Name, titleLabel.Width / 10, titleLabel.Font.Style);
            titleLabel.Font = greetingFont;
            titleLabel.BorderStyle = BorderStyle.Fixed3D;
            titleLabel.TextAlign = ContentAlignment.TopCenter;
            titleLabel.Padding = new Padding(50);
            titleLabel.UseMnemonic = true;
            titleLabel.Text = "Welcome...";
            titleLabel.BackColor = Color.Maroon;
            titleLabel.ForeColor = Color.White;
            this.Closed += new EventHandler(this.GraphicsClosed);
            this.Controls.Add(titleLabel);
        }

        private void AddMenuButtons()
        {
            startButton = new Button();
            startButton.Left = FORM_WIDTH / 2 - DEF_BUTTON_WIDTH/2;
            startButton.Top = FORM_HEIGHT / 2 - DEF_BUTTON_HEIGHT/2;
            startButton.Size = new Size(DEF_BUTTON_WIDTH, DEF_BUTTON_HEIGHT); 
            startButton.Text = "Start";
            startButton.TextAlign = ContentAlignment.MiddleCenter;
            startButton.BackColor = Color.Aqua;
            startButton.Click += new System.EventHandler(this.StartButtonClick);
            this.Controls.Add(startButton);

            helpButton = new Button();
            helpButton.Left = FORM_WIDTH / 2 - DEF_BUTTON_WIDTH / 2;
            helpButton.Top = FORM_HEIGHT / 2 - (DEF_BUTTON_HEIGHT / 2 - 50);
            helpButton.Size = new Size(DEF_BUTTON_WIDTH, DEF_BUTTON_HEIGHT);
            helpButton.Text = "Help";
            helpButton.TextAlign = ContentAlignment.MiddleCenter;
            helpButton.BackColor = Color.Aqua;
            helpButton.Click += new System.EventHandler(this.HelpButtonClick);
            this.Controls.Add(helpButton);
        }

        private void AddDecorations()
        {
            g.FillRectangle(brush, FORM_WIDTH-50, FORM_HEIGHT-50, 50, 50);
            g.FillRectangle(brush, 0, FORM_HEIGHT - 50, 50, 50);
            g.DrawLine(pen, 50, FORM_HEIGHT - 10, FORM_WIDTH - 20, FORM_HEIGHT - 10);
            Font creditsFont = new Font(FontFamily.GenericSerif.Name, 40f, FontStyle.Bold);
            brush.Color = Color.Bisque;
            g.DrawString("Eternity", greetingFont, brush, new PointF(FORM_WIDTH / 4, 500));
            g.DrawString("By Tarcan Gul", creditsFont, brush, new PointF(FORM_WIDTH/4+20, 700));
            
        }

        private void GraphicsClosed(object sender, EventArgs e)
        {
            DrawingArea.Dispose();
        }

        private void OpenPaintEvent(object sender, PaintEventArgs e)
        {
            Graphics oGraphics = e.Graphics;
            oGraphics.DrawImage(DrawingArea, 0, 0, DrawingArea.Width, DrawingArea.Height);
        }

        private void StartButtonClick(object sender, EventArgs e)
        {
            ClearScreen();
            startGame();            
        }

        private void HelpButtonClick(object sender, EventArgs e)
        {
            MessageBox.Show("Move with the arrow keys or WASD keys. Try to finish the maze!");
        }

        private void ClearScreen()
        {
            g.Clear(Color.Azure);
            this.Invalidate();
            this.Controls.Clear();
        }

        private void refreshView()
        {
            brush.Color = Color.Red;
            g.Clear(Color.Azure);
            this.Invalidate();
            g.FillEllipse(brush, player.x, player.y, player.Size, player.Size);
            createLevel();
        }

        private void startGame()
        {
            keyboardHandlerEnabled = true;
            createLevel();
            
            brush.Color = Color.Red;
            player = new GameCharacter(spawnPoint.x, spawnPoint.y, g, brush);
            
        }

        private void createLevel()
        {

            switch (currentLevel)
            {
                case 1: level = new Level1();
                    this.Text = "Level 1";
                    break;
                case 2: level = new Level2(); 
                        this.Text = "Level 2";
                        break;
                case 3: level = new Level3();
                    this.Text = "Level 3"; break;
                default: GoBackToMenu(); break;
                //Default throw exception.
            }
            spawnPoint = level.GetSpawnPoint();
            foreach(Wall w in level.AllWalls)
            {
                if (brush.Color != w.color) brush.Color = w.color;


                if (w.GetType() == typeof(SpawnWall))
                {
                    pen.Color = w.color;
                    g.DrawRectangle(pen, w.x, w.y, w.size, w.size);
                }
                else
                    g.FillRectangle(brush, w.x, w.y, w.size, w.size);
            }

            if (level.AllEnemies.Count != 0)
            {
                foreach(Enemy e in level.AllEnemies)
                {
                    e.DrawEnemy(g, brush);
                }
            }
        }

        private void ShowPlayerSuccessScreen()
        {
            keyboardHandlerEnabled = false;
            this.Text = "Congrats!";
            ClearScreen();
            PutSuccessScreen();
        }

        private void ShowPlayerFailureScreen()
        {
            keyboardHandlerEnabled = false;
            this.Text = "Oops!";
            ClearScreen();
            PutFailureScreen();
        }

        private void PutFailureScreen()
        {
            Button yesButton = new Button();
            yesButton.Text = "Back To Menu";
            yesButton.Left = FORM_WIDTH / 4;
            yesButton.Top = FORM_HEIGHT / 4 + 8 * DEF_BUTTON_HEIGHT;
            yesButton.Size = new Size(DEF_BUTTON_WIDTH, DEF_BUTTON_HEIGHT);
            currentLevel = 1;
            yesButton.Click += new EventHandler(this.BackToMenu_Click);
            this.Controls.Add(yesButton);

            Font successFont = new Font(FontFamily.GenericSerif.Name, 24f, FontStyle.Bold);
            //TODO: Add lives.
            pen.Color = Color.Black;

            g.DrawString("Oops!", successFont, brush, new PointF(FORM_WIDTH / 4, FORM_HEIGHT / 4 + DEF_BUTTON_HEIGHT * 2));
            g.DrawString("Game Over!", successFont, brush, new PointF(FORM_WIDTH / 4, FORM_HEIGHT / 2));
            
        }
        private void PutSuccessScreen()
        {
            Button yesButton = new Button();
            yesButton.Text = "Back To Menu";
            yesButton.Left = FORM_WIDTH / 4;
            yesButton.Top = FORM_HEIGHT / 4 + 8*DEF_BUTTON_HEIGHT;
            yesButton.Size = new Size(DEF_BUTTON_WIDTH, DEF_BUTTON_HEIGHT);
            yesButton.Click += new EventHandler(this.BackToMenu_Click);
            this.Controls.Add(yesButton);

            Font successFont = new Font(FontFamily.GenericSerif.Name, 24f, FontStyle.Bold);
            if (currentLevel == FINAL_LEVEL)
            {
                pen.Color = Color.Black;
                g.DrawString("Congrats, you finished Eternity!", successFont, brush, new PointF(FORM_WIDTH / 4, FORM_HEIGHT / 4 + DEF_BUTTON_HEIGHT * 2));
                g.DrawString("THANK YOU FOR PLAYING!", successFont, brush, new PointF(FORM_WIDTH / 4, FORM_HEIGHT / 2));
            }
            else
            {
                pen.Color = Color.Black;
               
                g.DrawString("Congrats, you beat level " + currentLevel++ + " !", successFont, brush, new PointF(FORM_WIDTH / 4, FORM_HEIGHT / 4 + DEF_BUTTON_HEIGHT * 2));
                g.DrawString("READY FOR NEW CHALLENGES?", successFont, brush, new PointF(FORM_WIDTH / 4, FORM_HEIGHT / 2));

                Button nextLevelButton = new Button();
                nextLevelButton.Text = "Next Level";
                nextLevelButton.Left = FORM_WIDTH / 4;
                nextLevelButton.Top = FORM_HEIGHT / 4 + 6 * DEF_BUTTON_HEIGHT;
                nextLevelButton.Size = new Size(DEF_BUTTON_WIDTH, DEF_BUTTON_HEIGHT);
                nextLevelButton.Click += new EventHandler(this.NextLevel_Click);
                this.Controls.Add(nextLevelButton);
            }
            

           
        }

        private void BackToMenu_Click(object sender, EventArgs e)
        {
            currentLevel = 1;
            GoBackToMenu();
        }

        private void NextLevel_Click(object sender, EventArgs e)
        {
            ClearScreen();
            startGame();
        }

        private void GoBackToMenu()
        {
            ClearScreen();
            DrawingArea = new Bitmap(FORM_WIDTH, FORM_HEIGHT, PixelFormat.Format24bppRgb);
            g = Graphics.FromImage(DrawingArea);
            pen = new Pen(Color.Green);
            brush = new SolidBrush(Color.Red);
            keyboardHandlerEnabled = true;
            ShowMenu();
        }

        public void KeyBoardPressed(object sender, KeyEventArgs ke)
        {
            if (!keyboardHandlerEnabled) return;
            if (player != null)
            {
                switch (ke.KeyCode)
                {
                    case Keys.Up:
                    case Keys.W:
                        player.y -= 10;
                        if (player.y < 0) player.y = 0;
                        else if (level != null && level.InWallBoundaries(player.x, player.y)) player.y += 10; //Undo change.
                        else if (level != null && level.DestinationReached(player.x, player.y)) ShowPlayerSuccessScreen();
                        else if (level != null && level.TouchedEnemy(player.x, player.y)) ShowPlayerFailureScreen();
                        else refreshView();
                        break;
                    case Keys.Left:
                    case Keys.A :
                        player.x -= 10;
                        if (player.x < 0) player.x = 0;
                        else if (level != null && level.InWallBoundaries(player.x, player.y)) player.x += 10; //Undo change.
                        else if (level != null && level.DestinationReached(player.x, player.y)) ShowPlayerSuccessScreen();
                        else if (level != null && level.TouchedEnemy(player.x, player.y)) ShowPlayerFailureScreen();
                        else refreshView();
                        break;
                    case Keys.Down:
                    case Keys.S :
                        player.y += 10;
                        if (player.y > FORM_HEIGHT - 30) player.y = FORM_HEIGHT - 30;
                        else if (level != null && level.InWallBoundaries(player.x, player.y)) player.y -= 10; //Undo change.
                        else if (level != null && level.DestinationReached(player.x, player.y)) ShowPlayerSuccessScreen();
                        else if (level != null && level.TouchedEnemy(player.x, player.y)) ShowPlayerFailureScreen();
                        else refreshView();
                        break;
                    case Keys.Right:
                    case Keys.D :
                        player.x += 10;
                        if (player.x > FORM_WIDTH - 30) player.x = FORM_WIDTH - 30;
                        else if (level != null && level.InWallBoundaries(player.x, player.y)) player.x -= 10; //Undo change.
                        else if (level != null && level.DestinationReached(player.x, player.y)) ShowPlayerSuccessScreen();
                        else if (level != null && level.TouchedEnemy(player.x, player.y)) ShowPlayerFailureScreen();
                        else refreshView();
                        break;
                }

                Debug.WriteLine("Key Event {0}", ke.KeyCode);



            }
            
        }
    }
}

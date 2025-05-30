/*
 * Author: Evan Perez
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KSU.CIS300.Snake
{
    /// <summary>
    /// user interface
    /// </summary>
    public partial class UserInterface : Form
    {
        /// <summary>
        /// width of square
        /// </summary>
        private int _squareWidth;
        /// <summary>
        /// size
        /// </summary>
        private int _size;
        /// <summary>
        /// game
        /// </summary>
        private Game _game;
        /// <summary>
        /// snake color
        /// </summary>
        private SolidBrush _bodyBrush = new SolidBrush(Color.Green); // Snake color
        /// <summary>
        /// food color
        /// </summary>
        private SolidBrush _foodBrush = new SolidBrush(Color.Red);   // Food color
        /// <summary>
        /// food color
        /// </summary>
        private Pen _pen = new Pen(Color.Black, 2);    
        /// <summary>
        /// outline color
        /// </summary>
        private CancellationTokenSource _cancelSource;

        public UserInterface()
        {
            InitializeComponent();
        }


        /// <summary>
        /// new game click
        /// </summary>
        /// <param name="size">size</param>
        /// <param name="speed">speed</param>
        private void NewGame(int size, int speed)
        {
            // Cancel any previous game
            _cancelSource?.Cancel();

            // Scale the speed to slow down the snake
            int adjustedSpeed = speed * 2; // Multiply the speed by 2 to slow it down

            // Initialize a new game
            _size = size;
            _game = new Game(size, adjustedSpeed, uxIsAI.Checked); // Pass the adjusted speed
            _cancelSource = new CancellationTokenSource();

            // Set up the picture box and form size
            uxPictureBox.Width = 600;
            uxPictureBox.Height = 600;
            this.Size = new Size(uxPictureBox.Width + 20, uxPictureBox.Height + uxMenuStrip.Height + 40);

            // Calculate the square width
            _squareWidth = uxPictureBox.Width / size;

            // Set up data binding for the score label
            uxScore.DataBindings.Clear();
            uxScore.DataBindings.Add("Text", _game, "Score");

            // Create a progress object to handle game updates
            var progress = new Progress<SnakeStatus>();
            progress.ProgressChanged += new EventHandler<SnakeStatus>(CheckProgress);

            // Start the game loop
            Task gameTask = _game.StartMoving(progress, _cancelSource.Token);
        }

        /// <summary>
        /// check progress
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="status">status</param>
        private void CheckProgress(object sender, SnakeStatus status)
        {
            // Redraw the UI
            Refresh();

            // Handle game status
            if (status == SnakeStatus.Collision)
            {
                MessageBox.Show("Game over!");
            }
            else if (status == SnakeStatus.Win)
            {
                MessageBox.Show("Game Completed!");
            }
        }




        /// <summary>
        /// picture box painting
        /// </summary>
        /// <param name="sender">s</param>
        /// <param name="e">e</param>
        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            if (_game != null && _game.GetSnakePath() != null)
            {
                foreach (var node in _game.GetSnakePath())
                {
                    Rectangle rect = new Rectangle(node.X * _squareWidth, node.Y * _squareWidth, _squareWidth, _squareWidth);
                    g.FillRectangle(_bodyBrush, rect);
                    g.DrawRectangle(_pen, rect);
                }
            }

            // Draw the snake


            // Draw the food
            if (_game != null)
            {
                var food = _game.GetFood();
                if (food != null)
                {
                    Rectangle rect = new Rectangle(food.X * _squareWidth, food.Y * _squareWidth, _squareWidth, _squareWidth);
                    g.FillEllipse(_foodBrush, rect);
                }
            }
        }

        /// <summary>
        /// user interface key down
        /// </summary>
        /// <param name="sender">s</param>
        /// <param name="e">e</param>
        private void UserInterface_KeyDown(object sender, KeyEventArgs e)
        {
            if (_game.Play)
            {
                switch (e.KeyCode)
                {
                    case Keys.Up:
                        _game.MoveUp();
                        break;
                    case Keys.Down:
                        _game.MoveDown();
                        break;
                    case Keys.Left:
                        _game.MoveLeft();
                        break;
                    case Keys.Right:
                        _game.MoveRight();
                        break;
                }

                // Redraw the picture box
                uxPictureBox.Refresh();
            }
        }

        /// <summary>
        /// easy game click
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void EasyGame_Click(object sender, EventArgs e)
        {
            NewGame(10, 5);
        }

        /// <summary>
        /// normal game
        /// </summary>
        /// <param name="sender">s</param>
        /// <param name="e">e</param>
        private void NormalGame_Click(object sender, EventArgs e)
        {
            NewGame(20, 10);
        }
        /// <summary>
        /// hardgame
        /// </summary>
        /// <param name="sender">s</param>
        /// <param name="e">e</param>
        private void HardGame_Click(object sender, EventArgs e)
        {
            NewGame(30, 15);
        }

        /// <summary>
        /// preview
        /// </summary>
        /// <param name="sender">s</param>
        /// <param name="e">e</param>
        private void UserInterface_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            e.IsInputKey = true; // Allow arrow keys to be processed
        }
    }
}

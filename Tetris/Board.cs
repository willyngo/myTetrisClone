using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Tetris
{
    /// <authors>
    /// Seaim Khan and William Ngo
    /// </authors>
    public class Board : IBoard
    {
        private Color[,] board;
        private IShape shape;
        private IShapeFactory shapeFactory;
        private bool isGameOver = true;

        public event GameOverHandler GameOver;
        public event LinesClearedHandler LinesCleared;

        /// <summary>
        /// Constructor that creates the Board object.
        /// </summary>
        public Board()
        {
            this.board = new Color[20, 10];
            ShapeProxy shapeProxy = new ShapeProxy(this);
            this.shape = shapeProxy;
            this.shapeFactory = shapeProxy;
            shape.JoinPile += joinPileHandler;

        }

        //Indexer
        public Color this[int i, int j]
        {
            get { return board[i, j]; }
            private set { board[i, j] = value; }
        }

        //Properties
        public IShape Shape
        {
            get { return shape; }
        }

        //Methods
        /// <summary>
        /// Gets the length of a specified dimension.
        /// </summary>
        /// <param name="rank">The specific dimension</param>
        /// <returns>Length of a dimension</returns>
        public int GetLength(int rank)
        {
            if (rank < 0 || rank > 1)
                throw new ArgumentOutOfRangeException("There are only two" +
                    "dimensions in Tetris. Input cannot be under 0 or over 1");

            return board.GetLength(rank);
        }

        /// <summary>
        /// Fires the GameOver event when the current game is done.
        /// </summary>
        protected void OnGameOver()
        {
            if (GameOver != null)
                GameOver();
        }

        /// <summary>
        /// Fires the LinesCleared event when one or more lines are cleared.
        /// </summary>
        /// <param name="lines">The amount of lines to be cleared.</param>
        protected void OnLinesCleared(int lines)
        {
            if (LinesCleared != null)
                LinesCleared(lines);
        }

        //Private methods
        /// <summary>
        /// Adds a shape to the pile and checks for game over.
        /// </summary>
        /// <param name="shape">The shape to be added.</param>
        private void addToPile(IShape shape)
        {
            for (int i = 0; i < shape.Length; i++)
                board[shape[i].Position.Y, shape[i].Position.X] = shape[i].Colour;

            lineCheck();

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (board[i, j] != Color.Transparent)
                    {
                        OnGameOver();
                        isGameOver = true;
                        resetBoard();

                    }
                }
            }
        }

        /// <summary>
        /// Manipulates a row by first removing a row, then copying it on top
        /// of it onto the cleared line and repeats until it reaches the top.
        /// Repeats at the next full line, if any.
        /// </summary>
        /// <param name="linelist">A list containing lines</param>
        private void clear(List<int> linelist)
        {
            for (int n = 0; n < linelist.Count; n++)
            {
                for (int i = linelist.ElementAt(n); i >= 2; i--)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (board[i, j] != Color.Transparent)
                            board[i, j] = Color.Transparent;

                        if (board[i - 1, j] != Color.Transparent)
                            board[i, j] = board[i - 1, j];
                    }
                }
            }
        }
        /// <summary>
        /// Event handler for a fired JoinPile event. Adds a shape to the board
        /// and deploys a new shape.
        /// </summary>
        private void joinPileHandler()
        {
            addToPile(shape);
            shapeFactory.DeployNewShape();
        }

        /// <summary>
        /// Checks whether or not the line is full.
        /// </summary>
        private void lineCheck()
        {
            int lines = 0;
            bool clearedLines = true;
            List<int> linelist = new List<int>(shape.Length);

            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 10; j++)
                    if (board[i, j] == new Color())
                        clearedLines = false;

                if (clearedLines)
                {
                    lines++;
                    linelist.Add(i);
                }
                else
                    clearedLines = true;
            }

            if (lines > 0)
            {
                clear(linelist);
                OnLinesCleared(lines);
            }
        }

        /// <summary>
        /// Resets the board.
        /// </summary>
        private void resetBoard()
        {
            this.board = new Color[20, 10];
        }
    }
}

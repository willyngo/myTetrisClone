using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Tetris;

namespace TetrisTests
{
    class TestBoard : IBoard
    {
        private Color[,] board;
        private IShape shape;
        private IShapeFactory shapeFactory;

        public event GameOverHandler GameOver;
        public event LinesClearedHandler LinesCleared;

        public TestBoard()
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
            set { board[i, j] = value; }
        }

        //Properties
        public IShape Shape
        {
            get { return shape; }
        }

        //Methods
        public int GetLength(int rank)
        {
            if (rank < 0 || rank > 1)
                throw new ArgumentOutOfRangeException("There are only two" +
                    "dimensions in Tetris. Input cannot be under 0 or over 1");

            return board.GetLength(rank);
        }

        public void OnGameOver()
        {
            if (GameOver != null)
                GameOver();
        }

        public void OnLinesCleared(int lines)
        {
            if (LinesCleared != null)
                LinesCleared(lines);
        }

        //Private methods
        public void addToPile(IShape shape)
        {
            for (int i = 0; i < shape.Length; i++)
                board[shape[i].Position.X, shape[i].Position.Y] = shape[i].Colour;

            lineCheck();

            for (int i = 0; i < shape.Length; i++)
                if (shape[i].Position.X <= 1)
                    OnGameOver();
        }

        public void clear(List<int> linelist)
        {
            for (int n = 0; n < linelist.Count; n++)
            {
                for (int i = linelist.ElementAt(n); i >= 2; i--)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (board[i, j] != new Color())
                            board[i, j] = new Color();

                        if (board[i - 1, j] != new Color())
                            board[i, j] = board[i - 1, j];
                    }
                }
            }
        }

        public void joinPileHandler()
        {
            addToPile(shape);
            shapeFactory.DeployNewShape();
        }

        public int lineCheck()
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
                return lines;
            }

            return 0;
        }
    }
}


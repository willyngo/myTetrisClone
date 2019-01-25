using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetris;
using Microsoft.Xna.Framework;

namespace TetrisTests
{
    [TestClass]
    public class BoardTest
    {
        [TestMethod]
        public void Indexer()
        {
            TestBoard board = new TestBoard();
            board[0, 0] = Color.Blue;

            Color color = board[0, 0];

            Console.WriteLine();
            Assert.AreEqual(color, Color.Blue);
        }

        [TestMethod]
        public void GetLength()
        {
            Board board = new Board();

            int firstLength = board.GetLength(0);
            Console.WriteLine(" Length: " + firstLength);

            Console.WriteLine();
            Assert.AreEqual(firstLength, 20);
        }

        [TestMethod]
        public void AddToPile()
        {
            TestBoard board = new TestBoard();
            IShape shape = new ShapeO(board);

            board.addToPile(shape);

            TestBoard board2 = new TestBoard();
            bool same = true;

            for (int i = 0; i < 2; i++)
            {
                board2[i, 5] = Color.Transparent;
                board2[i, 4] = Color.Transparent;
            }

            for (int i = 0; i < 2; i++)
            {
                if (board[i, 5] != board2[i, 5])
                    same = false;
                if (board[i, 4] != board2[i, 4])
                    same = false;
            }
            Assert.AreEqual(true, same);
        }

        [TestMethod]
        public void LineCheck()
        {
            TestBoard board = new TestBoard();

            int lines = 4;

            for (int i = 0; i < lines; i++)
                for (int j = 0; j < 10; j++)
                    board[i + 2, j] = Color.Blue;

            int clearedLines = board.lineCheck();

            Console.WriteLine();
            Assert.AreEqual(clearedLines, lines);
        }

        [TestMethod]
        public void ClearV1()
        {
            TestBoard board = new TestBoard();

            for (int i = 0; i < 10; i++)
            {
                board[19, i] = Color.Transparent;
                board[18, i] = Color.Transparent;
                if (i % 2 == 0)
                    board[17, i] = Color.Transparent;
                else
                    board[16, i] = Color.Transparent;
            }

            TestBoard afterBoard = new TestBoard();

            for (int i = 0; i < 10; i++)
            {
                if (i % 2 == 0)
                    afterBoard[19, i] = Color.Transparent;
                else
                    afterBoard[18, i] = Color.Transparent;
            }


            board.lineCheck();

            var same = true;

            for (int x = 0; x < 20; x++)
                for (int y = 0; y < 10; y++)
                    if (board[x, y] != afterBoard[x, y])
                        same = false;

            Console.WriteLine();
            Assert.AreEqual(true, same);
        }

        [TestMethod]
        public void ClearV2()
        {
            TestBoard board = new TestBoard();
            for (int i = 0; i < 10; i++)
            {
                board[19, i] = Color.Transparent;
                board[18, i] = Color.Transparent;
                board[15, i] = Color.Transparent;
                board[13, i] = Color.Transparent;
                if (i % 2 == 0)
                {
                    board[17, i] = Color.Transparent;
                    board[14, i] = Color.Transparent;
                }
                else
                {
                    board[16, i] = Color.Transparent;
                    board[12, i] = Color.Transparent;
                }
            }

            TestBoard afterBoard = new TestBoard();

            for (int i = 0; i < 10; i++)
            {
                if (i % 2 == 0)
                {
                    afterBoard[19, i] = Color.Transparent;
                    afterBoard[17, i] = Color.Transparent;
                }
                else
                {
                    afterBoard[16, i] = Color.Transparent;
                    afterBoard[18, i] = Color.Transparent;
                }
            }

           

            board.lineCheck();

            var same = true;

            for (int x = 0; x < 20; x++)
                for (int y = 0; y < 10; y++)
                    if (board[x, y] != afterBoard[x, y])
                        same = false;

            Console.WriteLine();
            Assert.AreEqual(true, same);
        }

        [TestMethod]
        public void OnLinesCleared()
        {
            Board board = new Board();

            board.LinesCleared += (x) => { Console.WriteLine("LinesCleared event fired"); };
        }
    }
}

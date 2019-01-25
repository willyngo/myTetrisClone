using System;
using Tetris;
using Microsoft.Xna.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TetrisTests
{
    [TestClass]
    public class BlockTests
    {
        [TestMethod]
        public void MoveLeft_EnoughSpace()
        {
            //Arrange
            Color aColor = new Color();
            aColor = Color.Magenta;
            Point aPoint = new Point(1,0);
            Point expected = new Point(0, 0);
            Board board = new Board();
            Block aBlock = new Block(board, aColor, aPoint);
            Block expectedBlock = new Block(board, aColor, expected);
            
            //Act
            aBlock.MoveLeft();
            
            //Assess
            Assert.AreEqual(expectedBlock.position, aBlock.position);
        }

        [TestMethod]
        public void MoveLeft_NoSpace()
        {
            Color aColor = new Color();
            aColor = Color.Magenta;
            Point aPoint = new Point(0, 0);
            Point expected = new Point(0, 0);
            Board board = new Board();
            Block aBlock = new Block(board, aColor, aPoint);
            Block expectedBlock = new Block(board, aColor, expected);
            
            //
            aBlock.MoveLeft();

            //Assess
            Assert.AreEqual(expectedBlock.position, aBlock.position);
        }

        [TestMethod]
        public void MoveRight_EnoughSpace()
        {
            //Arrange
            Color aColor = new Color();
            aColor = Color.Magenta;
            Point aPoint = new Point(1, 0);
            Point expected = new Point(2, 0);
            Board board = new Board();
            Block aBlock = new Block(board, aColor, aPoint);
            Block expectedBlock = new Block(board, aColor, expected);

            //Act
            aBlock.MoveRight();

            //Assess
            Assert.AreEqual(expectedBlock.position, aBlock.position);
        }

        [TestMethod]
        public void MoveRight_NoSpace()
        {
            Color aColor = new Color();
            aColor = Color.Magenta;
            Point aPoint = new Point(10, 0);
            Point expected = new Point(10, 0);
            Point notExpected = new Point(11, 0);
            Board board = new Board();
            Block aBlock = new Block(board, aColor, aPoint);
            Block expectedBlock = new Block(board, aColor, expected);
            Block notExpectedBlock = new Block(board, aColor, notExpected);

            //Act
            aBlock.MoveRight();

            //Assess
            Assert.AreEqual(expectedBlock.position, aBlock.position);
            Assert.AreNotEqual(notExpectedBlock.position, aBlock.position);

        }

        [TestMethod]
        public void MoveDown_EnoughSpace()
        {
            //Arrange
            Board downBoard = new Board();
            Color aColor = new Color();
            aColor = Color.Magenta;
            Point aPoint = new Point(0, 5);
            Point expected = new Point(0, 6);
            Board board = new Board();
            Block aBlock = new Block(board, aColor, aPoint);
            Block expectedBlock = new Block(board, aColor, expected);

            //Act
            aBlock.MoveDown();

            //Assess
            Assert.AreEqual(expectedBlock.position, aBlock.position);
        }

        [TestMethod]
        public void MoveDown_NoSpace()
        {
            //Arrange
            Color aColor = new Color();
            aColor = Color.Magenta;
            Point aPoint = new Point(0, 20);
            Point expected = new Point(0, 20);
            Board board = new Board();
            Block aBlock = new Block(board, aColor, aPoint);
            Block expectedBlock = new Block(board, aColor, expected);

            //Check for block moving out of the borders of boards.
            Point border = new Point(0, -1);

            //Act
            aBlock.MoveDown();

            //Assess
            Assert.AreEqual(expectedBlock.position, aBlock.position);
            Assert.AreNotEqual(border.Y, aBlock.position.Y);
        }

        [TestMethod]
        public void rotate_enoughSpace()
        {
            Board board = new Board();
            Color aColor = new Color();
            aColor = Color.Magenta;

            Point aPoint = new Point(5, 5);
            Point expected = new Point(7, 9);

            Block aBlock = new Block(board, aColor, aPoint);
            Block expectedBlock = new Block(board, aColor, expected);

            Point offset = new Point(2, 4);

            //Act
            aBlock.Rotate(offset);

            //Assert
            Assert.AreEqual(expectedBlock.position, aBlock.position);
        }

        [TestMethod]
        public void rotate_noSpace()
        {
            Board board = new Board();
            Color aColor = new Color();
            aColor = Color.Magenta;

            Point aPoint = new Point(20, 6);
            Point notExpected = new Point(22, 10);

            Block aBlock = new Block(board, aColor, aPoint);
            Block notExpectedBlock = new Block(board, aColor, notExpected);

            Point offset = new Point(2, 4);

            //Act
            aBlock.Rotate(offset);

            //Assert
            Assert.AreNotEqual(notExpectedBlock.position, aBlock.position);
        }
    }
}

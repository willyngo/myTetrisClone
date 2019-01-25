using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetris;

namespace TetrisTests
{
    [TestClass]
    public class ShapeTest_L
    {
        [TestMethod]
        public void ShapeL_Rotate1_EnoughSpace()
        {
            //Initial position = a(5,0)b(6,0)c(4,0)d(4,1)
            //Move down = a(5,1)b(6,1)c(4,1)d(4,2)
            Board board = new Board();
            ShapeL shapeTest = new ShapeL(board);
            ShapeL shapeTest_expected = new ShapeL(board);
            String expected = "(5, 1)(5, 0)(5, 2)(6, 2)";

            //Act
            shapeTest.MoveDown();


            shapeTest.Rotate();

            //Assert
            Assert.AreEqual(expected, shapeTest.getPositionOfBlocks());
        }


        [TestMethod]
        public void ShapeL_Rotate2_EnoughSpace()
        {
            //a(5, 1)b(5, 2)c(5, 0)d(4, 0)

            Board board = new Board();
            ShapeL shapeTest = new ShapeL(board);
            ShapeL shapeTest_expected = new ShapeL(board);
            String expected = "(5, 1)(4, 1)(6, 1)(6, 0)";


            //Act
            shapeTest.MoveDown();
            shapeTest.Rotate();
            shapeTest.Rotate();


            //Assert
            Assert.AreEqual(expected, shapeTest.getPositionOfBlocks());
        }

        [TestMethod]
        public void ShapeL_Rotate3_EnoughSpace()
        {
            //a(5, 1)b(4, 1)c(6, 1)d(6, 0)

            Board board = new Board();
            ShapeL shapeTest = new ShapeL(board);
            ShapeL shapeTest_expected = new ShapeL(board);
            String expected = "(5, 1)(5, 2)(5, 0)(4, 0)";


            //Act
            shapeTest.MoveDown();
            shapeTest.Rotate();
            shapeTest.Rotate();
            shapeTest.Rotate();


            //Assert
            Assert.AreEqual(expected, shapeTest.getPositionOfBlocks());
        }

        [TestMethod]
        public void ShapeL_Rotate4_EnoughSpace()
        {
            //a(5, 1)b(5, 0)c(5, 2)d(6, 2)

            Board board = new Board();
            ShapeL shapeTest = new ShapeL(board);
            ShapeL shapeTest_expected = new ShapeL(board);
            String expected = "(5, 1)(6, 1)(4, 1)(4, 2)";


            //Act
            shapeTest.MoveDown();
            shapeTest.Rotate();
            shapeTest.Rotate();
            shapeTest.Rotate();
            shapeTest.Rotate();


            //Assert
            Assert.AreEqual(expected, shapeTest.getPositionOfBlocks());
        }

        [TestMethod]
        public void ShapeL_Rotate_NoSpace()
        {
            //Initial position = a(5,0)b(6,0)c(4,0)d(4,1)
            Board board = new Board();
            ShapeL shapeTest = new ShapeL(board);
            ShapeL shapeTest_expected = new ShapeL(board);
            String expected = "(5, 0)(6, 0)(4, 0)(4, 1)";

            //Act

            shapeTest.Rotate();


            //Assert
            Assert.AreEqual(expected, shapeTest.getPositionOfBlocks());
        }

        [TestMethod]
        public void ShapeI_Reset()
        {
            Board board = new Board();
            ShapeL shapeTest = new ShapeL(board);
            ShapeL shapeTest_expected = new ShapeL(board);
            String expected = "(5, 0)(6, 0)(4, 0)(4, 1)";

            //Act

            shapeTest.MoveDown();
            shapeTest.MoveDown();
            shapeTest.MoveLeft();
            shapeTest.MoveLeft();
            shapeTest.MoveLeft();
            shapeTest.Rotate();

            shapeTest.Reset();


            //Assert
            Assert.AreEqual(expected, shapeTest.getPositionOfBlocks());
        }
    }
}
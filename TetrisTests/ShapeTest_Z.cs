using System;
using Tetris;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TetrisTests
{
    [TestClass]
    public class ShapeTest_Z
    {
        [TestMethod]
        public void ShapeZ_rotate1_EnoughSpace()
        {
            IBoard board = new Board();
            ShapeZ shapeTest = new ShapeZ(board);
            ShapeZ shapeTest_expected = new ShapeZ(board);
            String expected = "(5, 1)(5, 0)(4, 1)(4, 2)";

            /*      first row of the board
                        Initial position
                        
            [ ][ ][ ][ ][b][a][ ][ ][ ][ ]
            [ ][ ][ ][ ][ ][c][d][ ][ ][ ]
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
            */

            shapeTest.MoveDown();

            shapeTest.Rotate();

            /*      Should look like this after rotating once
                        
            [ ][ ][ ][ ][ ][b][ ][ ][ ][ ]
            [ ][ ][ ][ ][c][a][ ][ ][ ][ ]
            [ ][ ][ ][ ][d][ ][ ][ ][ ][ ]
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
            */
            Assert.AreEqual(expected, shapeTest.getPositionOfBlocks());
        }

        [TestMethod]
        public void ShapeZ_rotate2_EnoughSpace()
        {
            IBoard board = new Board();
            ShapeZ shapeTest = new ShapeZ(board);
            ShapeZ shapeTest_expected = new ShapeZ(board);
            String expected = "(5, 1)(4, 1)(5, 2)(6, 2)";

            /*      first row of the board
                        Initial position
                        
            [ ][ ][ ][ ][b][a][ ][ ][ ][ ]
            [ ][ ][ ][ ][ ][c][d][ ][ ][ ]
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
            */

            shapeTest.MoveDown();

            shapeTest.Rotate();
            shapeTest.Rotate();

            /*      Should look like this after rotating once
            
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]            
            [ ][ ][ ][ ][b][a][ ][ ][ ][ ]
            [ ][ ][ ][ ][ ][c][d][ ][ ][ ]
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
            
            */
            Assert.AreEqual(expected, shapeTest.getPositionOfBlocks());
        }

        [TestMethod]
        public void ShapeZ_Rotate_NoSpace()
        {
            IBoard board = new Board();
            ShapeZ shapeTest = new ShapeZ(board);
            ShapeZ shapeTest_expected = new ShapeZ(board);
            String expected = "(5, 0)(4, 0)(5, 1)(6, 1)";


            /*      first row of the board
                        Initial position
                        
            [ ][ ][ ][ ][b][a][ ][ ][ ][ ]
            [ ][ ][ ][ ][ ][c][d][ ][ ][ ]
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
            */

            //Act
            shapeTest.Rotate();

            /*      Should look like this after attempting to rotate
        
            [ ][ ][ ][ ][b][a][ ][ ][ ][ ]
            [ ][ ][ ][ ][ ][c][d][ ][ ][ ]
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
            */

            Assert.AreEqual(expected, shapeTest.getPositionOfBlocks());
        }

        [TestMethod]
        public void ShapeZ_Reset()
        {
            IBoard board = new Board();
            ShapeZ shapeTest = new ShapeZ(board);
            ShapeZ shapeTest_expected = new ShapeZ(board);
            String expected = "(5, 0)(4, 0)(5, 1)(6, 1)";

            /*      first row of the board
                        Initial position

            [ ][ ][ ][ ][b][a][ ][ ][ ][ ]
            [ ][ ][ ][ ][ ][c][d][ ][ ][ ]
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
            */

            //Act

            shapeTest.MoveDown();
            shapeTest.MoveDown();
            shapeTest.MoveLeft();
            shapeTest.MoveLeft();
            shapeTest.MoveLeft();
            shapeTest.Rotate();

            /*     Should look like this after reset.
            [ ][ ][ ][ ][b][a][ ][ ][ ][ ]
            [ ][ ][ ][ ][ ][c][d][ ][ ][ ]
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
            */

            shapeTest.Reset();
            //Assert
            Assert.AreEqual(expected, shapeTest.getPositionOfBlocks());
        }
    }
}
using System;
using Tetris;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TetrisTests
{
    [TestClass]
    public class ShapeTest_S
    {
        [TestMethod]
        public void ShapeS_Rotate1_EnoughSpace()
        {
            IBoard board = new Board();
            ShapeS shapeTest = new ShapeS(board);
            ShapeS shapeTest_expected = new ShapeS(board);
            String expected = "(5, 1)(5, 0)(6, 2)(6, 1)";


            /*      first row of the board
                        Initial position
                        
            [ ][ ][ ][ ][ ][a][b][ ][ ][ ]
            [ ][ ][ ][ ][c][d][ ][ ][ ][ ]
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
            */

            //Act
            shapeTest.MoveDown();

            shapeTest.Rotate();

            /*      Should look like this after rotating once
                        
            [ ][ ][ ][ ][ ][b][ ][ ][ ][ ]
            [ ][ ][ ][ ][ ][a][d][ ][ ][ ]
            [ ][ ][ ][ ][ ][ ][c][ ][ ][ ]
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
            */

            Assert.AreEqual(expected, shapeTest.getPositionOfBlocks());
        }

        [TestMethod]
        public void ShapeS_Rotate2_EnoughSpace()
        {
            IBoard board = new Board();
            ShapeS shapeTest = new ShapeS(board);
            ShapeS shapeTest_expected = new ShapeS(board);
            String expected = "(5, 1)(6, 1)(4, 2)(5, 2)";


            /*      first row of the board
                        Initial position
                        
            [ ][ ][ ][ ][ ][a][b][ ][ ][ ]
            [ ][ ][ ][ ][c][d][ ][ ][ ][ ]
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
            */

            //Act
            shapeTest.MoveDown();

            shapeTest.Rotate();
            shapeTest.Rotate();

            /*      Should look like this after rotating once
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]          
            [ ][ ][ ][ ][ ][a][b][ ][ ][ ]
            [ ][ ][ ][ ][c][d][ ][ ][ ][ ]
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
            */

            Assert.AreEqual(expected, shapeTest.getPositionOfBlocks());
        }

        [TestMethod]
        public void ShapeS_Rotate_NoSpace()
        {
            IBoard board = new Board();
            ShapeS shapeTest = new ShapeS(board);
            ShapeS shapeTest_expected = new ShapeS(board);
            String expected = "(5, 0)(6, 0)(4, 1)(5, 1)";


            /*      first row of the board
                        Initial position
                        
            [ ][ ][ ][ ][ ][a][b][ ][ ][ ]
            [ ][ ][ ][ ][c][d][ ][ ][ ][ ]
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
            */

            //Act
            shapeTest.Rotate();

            /*      Should look like this after attempting to rotate
        
            [ ][ ][ ][ ][ ][a][b][ ][ ][ ]
            [ ][ ][ ][ ][c][d][ ][ ][ ][ ]
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
            */

            Assert.AreEqual(expected, shapeTest.getPositionOfBlocks());
        }

        [TestMethod]
        public void ShapeS_Reset()
        {
            IBoard board = new Board();
            ShapeS shapeTest = new ShapeS(board);
            ShapeS shapeTest_expected = new ShapeS(board);
            String expected = "(5, 0)(6, 0)(4, 1)(5, 1)";

            /*      first row of the board
                        Initial position

            [ ][ ][ ][ ][ ][a][b][ ][ ][ ]
            [ ][ ][ ][ ][c][d][ ][ ][ ][ ]
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
            [ ][ ][ ][ ][ ][a][b][ ][ ][ ]
            [ ][ ][ ][ ][c][d][ ][ ][ ][ ]
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
                
            */

            shapeTest.Reset();
            //Assert
            Assert.AreEqual(expected, shapeTest.getPositionOfBlocks());
        }
    }
}

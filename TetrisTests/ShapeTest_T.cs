using System;
using Tetris;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TetrisTests
{
    [TestClass]
    public class ShapeTest_T
    {
        [TestMethod]
        public void ShapeT_MoveLeft_EnoughSpace()
        {
            IBoard board = new Board();
            ShapeT shapeTest = new ShapeT(board);
            ShapeT shapeTest_expected = new ShapeT(board);
            String expected = "(4, 0)(5, 0)(3, 0)(4, 1)";

            /*      First row of the board
                         Initial position

             [ ][ ][ ][ ][c][a][b][ ][ ][ ]
             [ ][ ][ ][ ][ ][d][ ][ ][ ][ ]

             */

            shapeTest.MoveLeft();


            /*      First row of the board
                         Initial position
             [ ][ ][ ][c][a][b][ ][ ][ ][ ]
             [ ][ ][ ][ ][d][ ][ ][ ][ ][ ]

             */

            Assert.AreEqual(expected, shapeTest.getPositionOfBlocks());
        }

        [TestMethod]
        public void ShapeT_MoveLeft_NoSpace()
        {
            IBoard board = new Board();
            ShapeT shapeTest = new ShapeT(board);
            ShapeT shapeTest_expected = new ShapeT(board);
            String expected = "(1, 0)(2, 0)(0, 0)(1, 1)";

            /*      First row of the board
                         Initial position

             [ ][ ][ ][ ][c][a][b][ ][ ][ ]
             [ ][ ][ ][ ][ ][d][ ][ ][ ][ ]

             */

            shapeTest.MoveLeft();
            shapeTest.MoveLeft();
            shapeTest.MoveLeft();
            shapeTest.MoveLeft();

            /*    Moved to the border.
             
             [c][a][b][ ][ ][ ][ ][ ][ ][ ]
             [ ][d][ ][ ][ ][ ][ ][ ][ ][ ]

             */

            //Now move once more to check if it goes outside the board
            shapeTest.MoveLeft();

            Assert.AreEqual(expected, shapeTest.getPositionOfBlocks());
        }

        [TestMethod]
        public void ShapeT_MoveRight_EnoughSpace()
        {
            IBoard board = new Board();
            ShapeT shapeTest = new ShapeT(board);
            ShapeT shapeTest_expected = new ShapeT(board);
            String expected = "(6, 0)(7, 0)(5, 0)(6, 1)";

            /*      First row of the board
                         Initial position

             [ ][ ][ ][ ][c][a][b][ ][ ][ ]
             [ ][ ][ ][ ][ ][d][ ][ ][ ][ ]

             */

            shapeTest.MoveRight();


            /*      
             [ ][ ][ ][ ][ ][c][a][b][ ][ ]
             [ ][ ][ ][ ][ ][ ][d][ ][ ][ ]

             */

            Assert.AreEqual(expected, shapeTest.getPositionOfBlocks());
        }

        [TestMethod]
        public void ShapeT_MoveRight_NoSpace()
        {
            IBoard board = new Board();
            ShapeT shapeTest = new ShapeT(board);
            ShapeT shapeTest_expected = new ShapeT(board);
            String expected = "(8, 0)(9, 0)(7, 0)(8, 1)";

            /*      First row of the board
                         Initial position

             [ ][ ][ ][ ][c][a][b][ ][ ][ ]
             [ ][ ][ ][ ][ ][d][ ][ ][ ][ ]

             */

            shapeTest.MoveRight();
            shapeTest.MoveRight();
            shapeTest.MoveRight();
            shapeTest.MoveRight();

            /*    Moved to the border.
             
             [ ][ ][ ][ ][ ][ ][ ][c][a][b]
             [ ][ ][ ][ ][ ][ ][ ][ ][d][ ]

             */

            //Now move once more to check if it goes outside the board
            shapeTest.MoveRight();

            Assert.AreEqual(expected, shapeTest.getPositionOfBlocks());
        }

        [TestMethod]
        public void ShapeT_MoveDown_EnoughSpace()
        {
            IBoard board = new Board();
            ShapeT shapeTest = new ShapeT(board);
            ShapeT shapeTest_expected = new ShapeT(board);
            String expected = "(5, 1)(6, 1)(4, 1)(5, 2)";

            /*      First row of the board
                         Initial position

             [ ][ ][ ][ ][c][a][b][ ][ ][ ]
             [ ][ ][ ][ ][ ][d][ ][ ][ ][ ]

             */

            shapeTest.MoveDown();


            /*      
             [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
             [ ][ ][ ][ ][c][a][b][ ][ ][ ]
             [ ][ ][ ][ ][ ][d][ ][ ][ ][ ]

             */

            Assert.AreEqual(expected, shapeTest.getPositionOfBlocks());
        }

        [TestMethod]
        public void ShapeT_MoveDown_NoSpace()
        {
            IBoard board = new Board();
            ShapeT shapeTest = new ShapeT(board);
            ShapeT shapeTest_expected = new ShapeT(board);
            String expected = "(5, 18)(6, 18)(4, 18)(5, 19)";

            /*      First row of the board
                         Initial position

             [ ][ ][ ][ ][c][a][b][ ][ ][ ]
             [ ][ ][ ][ ][ ][d][ ][ ][ ][ ]

             */


            //Act - Move the piece to the bottom of board
            for (int i = 0; i < 20; i++)
                shapeTest.MoveDown();

            /*
                Now in the last row of the board
             [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
             [ ][ ][ ][ ][c][a][b][ ][ ][ ]
             [ ][ ][ ][ ][ ][d][ ][ ][ ][ ]
            
            */

            //Now move once more to check if it goes outside the board
            shapeTest.MoveDown();


            //Assert
            Assert.AreEqual(expected, shapeTest.getPositionOfBlocks());
        }

        [TestMethod]
        public void ShapeT_Rotate1_EnoughSpace()
        {
            IBoard board = new Board();
            ShapeT shapeTest = new ShapeT(board);
            ShapeT shapeTest_expected = new ShapeT(board);
            String expected = "(5, 1)(5, 0)(5, 2)(6, 1)";

            /*      first row of the board
                        Initial position

            [ ][ ][ ][ ][c][a][b][ ][ ][ ]
            [ ][ ][ ][ ][ ][d][ ][ ][ ][ ]
            */

            //Act
            shapeTest.MoveDown();


            /*      AFter moving down to allow space to rotate
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
            [ ][ ][ ][ ][c][a][b][ ][ ][ ]
            [ ][ ][ ][ ][ ][d][ ][ ][ ][ ]
            */

            shapeTest.Rotate();

            /*     Should look like this after rotating once.
            [ ][ ][ ][ ][ ][b][ ][ ][ ][ ]
            [ ][ ][ ][ ][ ][a][d][ ][ ][ ]
            [ ][ ][ ][ ][ ][c][ ][ ][ ][ ]
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
                
            */


            //Assert
            Assert.AreEqual(expected, shapeTest.getPositionOfBlocks());
        }

        [TestMethod]
        public void ShapeT_Rotate2_EnoughSpace()
        {
            IBoard board = new Board();
            ShapeT shapeTest = new ShapeT(board);
            ShapeT shapeTest_expected = new ShapeT(board);
            String expected = "(5, 1)(4, 1)(6, 1)(5, 0)";

            /*      first row of the board
                        Initial position

            [ ][ ][ ][ ][c][a][b][ ][ ][ ]
            [ ][ ][ ][ ][ ][d][ ][ ][ ][ ]
            */

            //Act
            shapeTest.MoveDown();


            /*      AFter moving down to allow space to rotate
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
            [ ][ ][ ][ ][c][a][b][ ][ ][ ]
            [ ][ ][ ][ ][ ][d][ ][ ][ ][ ]
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
            */

            shapeTest.Rotate();
            shapeTest.Rotate();

            /*     Should look like this after rotating twice.
            [ ][ ][ ][ ][ ][d][ ][ ][ ][ ]
            [ ][ ][ ][ ][b][a][c][ ][ ][ ]
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
                
            */


            //Assert
            Assert.AreEqual(expected, shapeTest.getPositionOfBlocks());
        }

        [TestMethod]
        public void ShapeT_Rotate3_EnoughSpace()
        {
            IBoard board = new Board();
            ShapeT shapeTest = new ShapeT(board);
            ShapeT shapeTest_expected = new ShapeT(board);
            String expected = "(5, 1)(5, 2)(5, 0)(4, 1)";

            /*      first row of the board
                        Initial position

            [ ][ ][ ][ ][c][a][b][ ][ ][ ]
            [ ][ ][ ][ ][ ][d][ ][ ][ ][ ]
            */

            //Act
            shapeTest.MoveDown();


            /*      AFter moving down to allow space to rotate
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
            [ ][ ][ ][ ][c][a][b][ ][ ][ ]
            [ ][ ][ ][ ][ ][d][ ][ ][ ][ ]
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
            */

            shapeTest.Rotate();
            shapeTest.Rotate();
            shapeTest.Rotate();

            /*     Should look like this after rotating twice.
            [ ][ ][ ][ ][ ][c][ ][ ][ ][ ]
            [ ][ ][ ][ ][d][a][ ][ ][ ][ ]
            [ ][ ][ ][ ][ ][b][ ][ ][ ][ ]
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
                
            */


            //Assert
            Assert.AreEqual(expected, shapeTest.getPositionOfBlocks());
        }

        [TestMethod]
        public void ShapeT_Rotate4_EnoughSpace()
        {
            IBoard board = new Board();
            ShapeT shapeTest = new ShapeT(board);
            ShapeT shapeTest_expected = new ShapeT(board);
            String expected = "(5, 1)(6, 1)(4, 1)(5, 2)";

            /*      first row of the board
                        Initial position

            [ ][ ][ ][ ][c][a][b][ ][ ][ ]
            [ ][ ][ ][ ][ ][d][ ][ ][ ][ ]
            */

            //Act
            shapeTest.MoveDown();


            /*      AFter moving down to allow space to rotate
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
            [ ][ ][ ][ ][c][a][b][ ][ ][ ]
            [ ][ ][ ][ ][ ][d][ ][ ][ ][ ]
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
            */

            shapeTest.Rotate();
            shapeTest.Rotate();
            shapeTest.Rotate();
            shapeTest.Rotate();

            /*     Should look like this after rotating twice.
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
            [ ][ ][ ][ ][c][a][b][ ][ ][ ]
            [ ][ ][ ][ ][ ][d][ ][ ][ ][ ]
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
                
            */


            //Assert
            Assert.AreEqual(expected, shapeTest.getPositionOfBlocks());
        }

        [TestMethod]
        public void ShapeT_Rotate_NoSpace()
        {
            IBoard board = new Board();
            ShapeT shapeTest = new ShapeT(board);
            ShapeT shapeTest_expected = new ShapeT(board);
            String expected = "(5, 0)(6, 0)(4, 0)(5, 1)";

            /*      first row of the board
                        Initial position

            [ ][ ][ ][ ][c][a][b][ ][ ][ ]
            [ ][ ][ ][ ][ ][d][ ][ ][ ][ ]
            */

            //act


            shapeTest.Rotate();


            /*     Should look like this after attempting to rotate
            [ ][ ][ ][ ][c][a][b][ ][ ][ ]
            [ ][ ][ ][ ][ ][d][ ][ ][ ][ ]
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
                
            */


            //Assert
            Assert.AreEqual(expected, shapeTest.getPositionOfBlocks());
        }

        [TestMethod]
        public void ShapeT_Reset()
        {
            IBoard board = new Board();
            ShapeT shapeTest = new ShapeT(board);
            ShapeT shapeTest_expected = new ShapeT(board);
            String expected = "(5, 0)(6, 0)(4, 0)(5, 1)";

            /*      first row of the board
                        Initial position

            [ ][ ][ ][ ][c][a][b][ ][ ][ ]
            [ ][ ][ ][ ][ ][d][ ][ ][ ][ ]
            */

            //Act

            shapeTest.MoveDown();
            shapeTest.MoveDown();
            shapeTest.MoveLeft();
            shapeTest.MoveLeft();
            shapeTest.MoveLeft();
            shapeTest.Rotate();

            /*     Should look like this after reset.
            [ ][ ][ ][ ][c][a][b][ ][ ][ ]
            [ ][ ][ ][ ][ ][d][ ][ ][ ][ ]
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
                
            */

            shapeTest.Reset();
            //Assert
            Assert.AreEqual(expected, shapeTest.getPositionOfBlocks());
        }
    }
}

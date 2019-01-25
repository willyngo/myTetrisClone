using System;
using Tetris;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TetrisTests
{
    [TestClass]
    public class ShapeTest_O
    {
        [TestMethod]
        public void ShapeO_MoveLeft_EnoughSpace()
        {
            IBoard board = new Board();
            ShapeO shapeTest = new ShapeO(board);
            ShapeO shapeTest_expected = new ShapeO(board);
            String expected = "(4, 0)(3, 0)(3, 1)(4, 1)";

            /*      First row of the board
                        Initial position
                        
            [ ][ ][ ][ ][b][a][ ][ ][ ][ ]
            [ ][ ][ ][ ][c][d][ ][ ][ ][ ]
                
            */

            //Act
            shapeTest.MoveLeft();

            /*      AFter moving one to the left
            [ ][ ][ ][b][a][ ][ ][ ][ ][ ]
            [ ][ ][ ][c][d][ ][ ][ ][ ][ ]
                
            */
            //Assert
            Assert.AreEqual(expected, shapeTest.getPositionOfBlocks());
        }

        [TestMethod]
        public void ShapeO_MoveLeft_NoSpace()
        {
            IBoard board = new Board();
            ShapeO shapeTest = new ShapeO(board);
            ShapeO shapeTest_expected = new ShapeO(board);
            String expected = "(1, 0)(0, 0)(0, 1)(1, 1)";

            /*      First row of the board
                        Initial position
                        
            [ ][ ][ ][ ][b][a][ ][ ][ ][ ]
            [ ][ ][ ][ ][c][d][ ][ ][ ][ ]
                
            */

            //Act
            shapeTest.MoveLeft();
            shapeTest.MoveLeft();
            shapeTest.MoveLeft();
            shapeTest.MoveLeft();

            /*     Moved to the border.
            [b][a][ ][ ][ ][ ][ ][ ][ ][ ]
            [c][d][ ][ ][ ][ ][ ][ ][ ][ ]
                
            */

            //Now move once more to check if it goes outside the board
            shapeTest.MoveLeft();

            //Assert
            Assert.AreEqual(expected, shapeTest.getPositionOfBlocks());
        }

        [TestMethod]
        public void ShapeO_MoveRight_EnoughSpace()
        {
            IBoard board = new Board();
            ShapeO shapeTest = new ShapeO(board);
            ShapeO shapeTest_expected = new ShapeO(board);
            String expected = "(6, 0)(5, 0)(5, 1)(6, 1)";

            /*      First row of the board
                        Initial position
                        
            [ ][ ][ ][ ][b][a][ ][ ][ ][ ]
            [ ][ ][ ][ ][c][d][ ][ ][ ][ ]
                
            */

            //Act
            shapeTest.MoveRight();

            /*      AFter moving one to the right
            [ ][ ][ ][ ][ ][b][a][ ][ ][ ]
            [ ][ ][ ][ ][ ][c][d][ ][ ][ ]
                
            */
            //Assert
            Assert.AreEqual(expected, shapeTest.getPositionOfBlocks());
        }

        [TestMethod]
        public void ShapeO_MoveRight_NoSpace()
        {
            IBoard board = new Board();
            ShapeO shapeTest = new ShapeO(board);
            ShapeO shapeTest_expected = new ShapeO(board);
            String expected = "(9, 0)(8, 0)(8, 1)(9, 1)";

            /*      First row of the board
                        Initial position
                        
            [ ][ ][ ][ ][b][a][ ][ ][ ][ ]
            [ ][ ][ ][ ][c][d][ ][ ][ ][ ]
                
            */

            //Act
            shapeTest.MoveRight();
            shapeTest.MoveRight();
            shapeTest.MoveRight();
            shapeTest.MoveRight();

            /*     Moved to the border.
            [ ][ ][ ][ ][ ][ ][ ][ ][b][a]
            [ ][ ][ ][ ][ ][ ][ ][ ][c][d]
                
            */

            //Now move once more to check if it goes outside the board
            shapeTest.MoveRight();

            //Assert
            Assert.AreEqual(expected, shapeTest.getPositionOfBlocks());
        }

        [TestMethod]
        public void ShapeO_MoveDown_EnoughSpace()
        {
            IBoard board = new Board();
            ShapeO shapeTest = new ShapeO(board);
            ShapeO shapeTest_expected = new ShapeO(board);
            String expected = "(5, 1)(4, 1)(4, 2)(5, 2)";

            /*      First row of the board
                        Initial position
                        
            [ ][ ][ ][ ][b][a][ ][ ][ ][ ]
            [ ][ ][ ][ ][c][d][ ][ ][ ][ ]
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
                
            */

            //Act
            shapeTest.MoveDown();

            /*      AFter moving one down
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
            [ ][ ][ ][ ][b][a][ ][ ][ ][ ]
            [ ][ ][ ][ ][c][d][ ][ ][ ][ ]
                
            */
            //Assert
            Assert.AreEqual(expected, shapeTest.getPositionOfBlocks());
        }

        [TestMethod]
        public void ShapeO_MoveDown_NoSpace()
        {
            IBoard board = new Board();
            ShapeO shapeTest = new ShapeO(board);
            ShapeO shapeTest_expected = new ShapeO(board);
            String expected = "(5, 18)(4, 18)(4, 19)(5, 19)";

            /*      First row of the board
                        Initial position
                        
            [ ][ ][ ][ ][b][a][ ][ ][ ][ ]
            [ ][ ][ ][ ][c][d][ ][ ][ ][ ]
                
            */

            //Act - Move the piece to the bottom of board
            for (int i = 0; i < 20; i++)
                shapeTest.MoveDown();

            /*     Moved to the border.
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
            [ ][ ][ ][ ][b][a][ ][ ][ ][ ]
            [ ][ ][ ][ ][c][d][ ][ ][ ][ ]
                
            */

            //Now move once more to check if it goes outside the board
            shapeTest.MoveDown();

            //Assert
            Assert.AreEqual(expected, shapeTest.getPositionOfBlocks());
        }

        [TestMethod]
        public void ShapeO_Rotate1_EnoughSpace()
        {
            IBoard board = new Board();
            ShapeO shapeTest = new ShapeO(board);
            ShapeO shapeTest_expected = new ShapeO(board);
            String expected = "(5, 0)(4, 0)(4, 1)(5, 1)";

            /*      first row of the board
                        Initial position
                        
            [ ][ ][ ][ ][b][a][ ][ ][ ][ ]
            [ ][ ][ ][ ][c][d][ ][ ][ ][ ]
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
            */

            shapeTest.Rotate();

            /*     O Shape stays the same
            [ ][ ][ ][ ][b][a][ ][ ][ ][ ]
            [ ][ ][ ][ ][c][d][ ][ ][ ][ ]
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
                
            */

            //Assert
            Assert.AreEqual(expected, shapeTest.getPositionOfBlocks());
        }

        [TestMethod]
        public void ShapeO_Reset()
        {
            IBoard board = new Board();
            ShapeO shapeTest = new ShapeO(board);
            ShapeO shapeTest_expected = new ShapeO(board);
            String expected = "(5, 0)(4, 0)(4, 1)(5, 1)";

            /*      first row of the board
                        Initial position
                        
            [ ][ ][ ][ ][b][a][ ][ ][ ][ ]
            [ ][ ][ ][ ][c][d][ ][ ][ ][ ]
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
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

            /*     Position after moving
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
            [ ][b][a][ ][ ][ ][ ][ ][ ][ ]
            [ ][c][d][ ][ ][ ][ ][ ][ ][ ]
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]

            */

            shapeTest.Reset();


            /*     Should be back to original position
                        
            [ ][ ][ ][ ][b][a][ ][ ][ ][ ]
            [ ][ ][ ][ ][c][d][ ][ ][ ][ ]
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]

            */

            //Assert
            Assert.AreEqual(expected, shapeTest.getPositionOfBlocks());
        }
    }
}

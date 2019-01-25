using System;
using Tetris;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace TetrisTests
{
    //Note: Shape class tested in this test class, along with ShapeI.
    [TestClass]
    public class ShapeTest_I
    {
        [TestMethod]
        public void ShapeI_MoveLeft_EnoughSpace()
        {
            Board board = new Board();
            ShapeI shapeTest = new ShapeI(board);
            ShapeI shapeTest_expected = new ShapeI(board);
            String expected = "(4, 0)(5, 0)(3, 0)(2, 0)";

            /*      First row of the board
                        Initial position
                        
            [ ][ ][ ][d][c][a][b][ ][ ][ ]
                
            */

            //Act
            shapeTest.MoveLeft();

            /*      AFter moving one to the left
            [ ][ ][d][c][a][b][ ][ ][ ][ ]
                
            */
            //Assert
            Assert.AreEqual(expected, shapeTest.getPositionOfBlocks());
        }

        
        [TestMethod]
        public void ShapeI_MoveLeft_NoSpace()
        {
            Board board = new Board();
            ShapeI shapeTest = new ShapeI(board);
            ShapeI shapeTest_expected = new ShapeI(board);
            String expected = "(2, 0)(3, 0)(1, 0)(0, 0)";


            /*      First row of the board
                    Initial position
                [ ][ ][ ][d][c][a][b][ ][ ][ ]
                
            */
            

            //Act
            shapeTest.MoveLeft();
            shapeTest.MoveLeft();
            shapeTest.MoveLeft();

            /*
                Move the piece three times to the left to put it near the left border
                [d][c][a][b][ ][ ][ ][ ][ ][ ]
            
            */

            //Now move once more to check if it goes outside the board
            shapeTest.MoveLeft();


            //Assert
            Assert.AreEqual(expected, shapeTest.getPositionOfBlocks());
        }

        [TestMethod]
        public void ShapeI_MoveRight_EnoughSpace()
        {
            Board board = new Board();
            ShapeI shapeTest = new ShapeI(board);
            ShapeI shapeTest_expected = new ShapeI(board);
            String expected = "(6, 0)(7, 0)(5, 0)(4, 0)";

            /*      First row of the board
                        Initial position
                        
            [ ][ ][ ][d][c][a][b][ ][ ][ ]
                
            */

            //Act
            shapeTest.MoveRight();

            /*      AFter moving one to the right
            [ ][ ][ ][ ][d][c][a][b][ ][ ]
                
            */
            //Assert
            Assert.AreEqual(expected, shapeTest.getPositionOfBlocks());
        }


        [TestMethod]
        public void ShapeI_MoveRight_NoSpace()
        {
            Board board = new Board();
            ShapeI shapeTest = new ShapeI(board);
            ShapeI shapeTest_expected = new ShapeI(board);
            String expected = "(8, 0)(9, 0)(7, 0)(6, 0)";


            /*      First row of the board
                    Initial position
                [ ][ ][ ][d][c][a][b][ ][ ][ ]
                
            */


            //Act
            shapeTest.MoveRight();
            shapeTest.MoveRight();
            shapeTest.MoveRight();

            /*
                Move the piece three times to the Right to put it near the Right border
                [ ][ ][ ][ ][ ][ ][d][c][a][b]
            
            */

            //Now move once more to check if it goes outside the board
            shapeTest.MoveRight();


            //Assert
            Assert.AreEqual(expected, shapeTest.getPositionOfBlocks());
        }

        [TestMethod]
        public void ShapeI_MoveDown_EnoughSpace()
        {
            Board board = new Board();
            ShapeI shapeTest = new ShapeI(board);
            ShapeI shapeTest_expected = new ShapeI(board);
            String expected = "(5, 1)(6, 1)(4, 1)(3, 1)";

            /*      first row of the board
                        Initial position
                        
            [ ][ ][ ][d][c][a][b][ ][ ][ ]
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
            */

            //Act
            shapeTest.MoveDown();

            /*      AFter moving one down
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
            [ ][ ][ ][ ][d][c][a][b][ ][ ]
                
            */
            //Assert
            Assert.AreEqual(expected, shapeTest.getPositionOfBlocks());
        }


        [TestMethod]
        public void ShapeI_MoveDown_NoSpace()
        {
            Board board = new Board();
            ShapeI shapeTest = new ShapeI(board);
            ShapeI shapeTest_expected = new ShapeI(board);
            String expected = "(5, 19)(6, 19)(4, 19)(3, 19)";


            /*      last row of the board
                    Initial position
                [ ][ ][ ][d][c][a][b][ ][ ][ ]
                
            */


            //Act - Move the piece to the bottom of board
            for (int i = 0; i < 20; i++)
                shapeTest.MoveDown();

            /*
                Now in the last row of the board
                [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
                [ ][ ][ ][d][c][a][b][ ][ ][ ]
            
            */

            //Now move once more to check if it goes outside the board
            shapeTest.MoveDown();


            //Assert
            Assert.AreEqual(expected, shapeTest.getPositionOfBlocks());
        }

        [TestMethod]
        public void ShapeI_Rotate1_EnoughSpace()
        {
            Board board = new Board();
            ShapeI shapeTest = new ShapeI(board);
            ShapeI shapeTest_expected = new ShapeI(board);
            String expected = "(5, 1)(5, 0)(5, 2)(5, 3)";

            /*      first row of the board
                        Initial position
                        
            [ ][ ][ ][d][c][a][b][ ][ ][ ]
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
            */

            //Act
            shapeTest.MoveDown();
           

            /*      AFter moving down to allow space to rotate
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
            [ ][ ][ ][d][c][a][b][ ][ ][ ]
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
                
            */

            shapeTest.Rotate();

            /*     Should look like this after rotating once.
            [ ][ ][ ][ ][ ][b][ ][ ][ ][ ]
            [ ][ ][ ][ ][ ][a][ ][ ][ ][ ]
            [ ][ ][ ][ ][ ][c][ ][ ][ ][ ]
            [ ][ ][ ][ ][ ][d][ ][ ][ ][ ]
                
            */


            //Assert
            Assert.AreEqual(expected, shapeTest.getPositionOfBlocks());
        }


        [TestMethod]
        public void ShapeI_Rotate2_EnoughSpace()
        {
            Board board = new Board();
            ShapeI shapeTest = new ShapeI(board);
            ShapeI shapeTest_expected = new ShapeI(board);
            String expected = "(5, 1)(6, 1)(4, 1)(3, 1)";

            /*      first row of the board
                        Initial position
                        
            [ ][ ][ ][d][c][a][b][ ][ ][ ]
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
            */

            //Act
            shapeTest.MoveDown();


            /*      AFter moving down to allow space to rotate
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
            [ ][ ][ ][d][c][a][b][ ][ ][ ]
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
                
            */

            shapeTest.Rotate();
            shapeTest.Rotate();

            /*     Should keep original position after rotating twice.
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
            [ ][ ][ ][d][c][a][b][ ][ ][ ]
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
                
            */


            //Assert
            Assert.AreEqual(expected, shapeTest.getPositionOfBlocks());
        }

        [TestMethod]
        public void ShapeI_Rotate_NoSpace()
        {
            Board board = new Board();
            ShapeI shapeTest = new ShapeI(board);
            ShapeI shapeTest_expected = new ShapeI(board);
            String expected = "(5, 0)(6, 0)(4, 0)(3, 0)";

            /*      first row of the board
                        Initial position
                        
            [ ][ ][ ][d][c][a][b][ ][ ][ ]
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
            */

            //Act

            shapeTest.Rotate();

            /*     Should keep original position if unable to rotate
            
            [ ][ ][ ][d][c][a][b][ ][ ][ ]
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
            */


            //Assert
            Assert.AreEqual(expected, shapeTest.getPositionOfBlocks());
        }

        [TestMethod]
        public void ShapeI_Reset()
        {
            Board board = new Board();
            ShapeI shapeTest = new ShapeI(board);
            ShapeI shapeTest_expected = new ShapeI(board);
            String expected = "(5, 0)(6, 0)(4, 0)(3, 0)";

            /*      first row of the board
                        Initial position
                        
            [ ][ ][ ][d][c][a][b][ ][ ][ ]
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
            [ ][ ][b][ ][ ][ ][ ][ ][ ][ ]
            [ ][ ][a][ ][ ][ ][ ][ ][ ][ ]
            [ ][ ][c][ ][ ][ ][ ][ ][ ][ ]
            [ ][ ][d][ ][ ][ ][ ][ ][ ][ ]
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]

            */

            shapeTest.Reset();


            /*     Should be back to original position
                        
            [ ][ ][ ][d][c][a][b][ ][ ][ ]
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]

            */

            //Assert
            Assert.AreEqual(expected, shapeTest.getPositionOfBlocks());
        }
    }
}

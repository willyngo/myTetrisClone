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
    public class ShapeL : Shape
    {
        /// <summary>
        /// Constructs a specific L Shape object.
        /// </summary>
        /// <param name="board">The game board.</param>
        public ShapeL(IBoard board) : base(board)
        {
            currentRotation = 0;
            rotationOffset = setOffsets();
            int center = (board.GetLength(1) / 2);

            Point a = new Point(center, 0);
            Point b = new Point(center + 1, 0);
            Point c = new Point(center - 1, 0);
            Point d = new Point(center - 1, 1);

            Block[] gamePiece =
            {
                new Block(board, Color.Magenta, a),
                new Block(board, Color.Magenta, b),
                new Block(board, Color.Magenta, c),
                new Block(board, Color.Magenta, d)
            };

            /*
            Initial position 
            [ ][ ][ ][ ]
            [ ][c][a][b]
            [ ][d][ ][ ]
            [ ][ ][ ][ ]
            */

            blocks = gamePiece;
        }

        public Point[][] setOffsets()
        {
            /*
            Set 1 puts the shape in its vertical position

            [ ][ ][ ][ ]            [ ][ ][b][ ]
            [ ][c][a][b]            [ ][ ][a][ ]
            [ ][d][ ][ ]    ==>     [ ][ ][c][d]
            [ ][ ][ ][ ]            [ ][ ][ ][ ]
            
            */

            Point[] set1 =
            {
                new Point(0, 0),
                new Point(-1, -1),
                new Point(1, 1),
                new Point(2, 0)
            };

            /*
           Set 1 puts the shape in its vertical position

           [ ][ ][b][ ]            [ ][ ][ ][d]
           [ ][ ][a][ ]            [ ][b][a][c]
           [ ][ ][c][d]    ==>     [ ][ ][ ][ ]
           [ ][ ][ ][ ]            [ ][ ][ ][ ]

           */

            Point[] set2 =
            {
                new Point(0, 0),
                new Point(-1, 1),
                new Point(1, -1),
                new Point(0, -2)
            };

            /*
           Set 1 puts the shape in its vertical position

           [ ][ ][ ][d]            [ ][d][c][ ]
           [ ][b][a][c]            [ ][ ][a][ ]
           [ ][ ][ ][ ]    ==>     [ ][ ][b][ ]
           [ ][ ][ ][ ]            [ ][ ][ ][ ]

           */

            Point[] set3 =
            {
                new Point(0, 0),
                new Point(1, 1),
                new Point(-1, -1),
                new Point(-2, 0)
            };

            /*
           Set 1 puts the shape in its vertical position

           [ ][d][c][ ]            [ ][ ][ ][ ]
           [ ][ ][a][ ]            [ ][c][a][b]
           [ ][ ][b][ ]    ==>     [ ][d][ ][ ]
           [ ][ ][ ][ ]            [ ][ ][ ][ ]

           */

            Point[] set4 =
            {
                new Point(0, 0),
                new Point(1, -1),
                new Point(-1, 1),
                new Point(0, 2)
            };

            Point[][] offset = { set2, set1, set4, set3 };
            return offset;
        }

        /// <summary>
        /// L Shape-specific rotate.
        /// </summary>
        public override void Rotate()
        {
            
            int set = currentRotation % 4;
            int blockCtr = 0;
            bool canRotate = true;

            foreach (Block aBlock in blocks)
            {
                if (!aBlock.TryRotate(rotationOffset[set][blockCtr]))
                {
                    canRotate = false;
                }

                blockCtr++;
            }

            blockCtr = 0;

            if (canRotate)
            {
                //If the rotation was successful, Increment the current rotation to go to the next offset
                currentRotation++;
                foreach (Block aBlock in blocks)
                {
                    aBlock.Rotate(rotationOffset[set][blockCtr]);
                    blockCtr++;
                }
            }
        }

        /// <summary>
        /// L Shape-specific reset position.
        /// </summary>
        public override void Reset()
        {
            int center = 5;

            Point a = new Point(center, 0);
            Point b = new Point(center + 1, 0);
            Point c = new Point(center - 1, 0);
            Point d = new Point(center - 1, 1);

            blocks[0].Position = a;
            blocks[1].Position = b;
            blocks[2].Position = c;
            blocks[3].Position = d;
        }
    }
}

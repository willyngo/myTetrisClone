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
    public class ShapeT : Shape
    {
        /// <summary>
        /// Constructs a specific T Shape object.
        /// </summary>
        /// <param name="board">The game board.</param>
        public ShapeT(IBoard board) : base(board)
        {
            currentRotation = 0;
            rotationOffset = setOffsets();
            int center = (board.GetLength(1) / 2);

            Point a = new Point(center, 0);
            Point b = new Point(center + 1, 0);
            Point c = new Point(center - 1, 0);
            Point d = new Point(center, 1);

            Block[] gamePiece =
            {
                new Block(board, Color.Brown, a),
                new Block(board, Color.Brown, b),
                new Block(board, Color.Brown, c),
                new Block(board, Color.Brown, d)
            };

            /*
            Initial position
            [ ][ ][ ][ ]
            [ ][c][a][b]
            [ ][ ][d][ ]
            [ ][ ][ ][ ]
            */

            blocks = gamePiece;
        }

        public Point[][] setOffsets()
        {
            /*
            Set 1

            [ ][ ][ ][ ]            [ ][ ][b][ ]
            [ ][c][a][b]            [ ][ ][a][d]
            [ ][ ][d][ ]    ==>     [ ][ ][c][ ]
            [ ][ ][ ][ ]            [ ][ ][ ][ ]

            */

            Point[] set1 =
            {
                new Point(0, 0),
                new Point(-1, -1),
                new Point(1, 1),
                new Point(1, -1)
            };

            /*
            Set 2

            [ ][ ][b][ ]            [ ][ ][d][ ]
            [ ][ ][a][d]            [ ][b][a][c]
            [ ][ ][c][ ]    ==>     [ ][ ][ ][ ]
            [ ][ ][ ][ ]            [ ][ ][ ][ ]

            */

            Point[] set2 =
            {
                new Point(0, 0),
                new Point(-1, 1),
                new Point(1, -1),
                new Point(-1, -1)
            };

            /*
            Set 3

            [ ][ ][d][ ]            [ ][ ][c][ ]
            [ ][b][a][c]            [ ][d][a][ ]
            [ ][ ][ ][ ]    ==>     [ ][ ][b][ ]
            [ ][ ][ ][ ]            [ ][ ][ ][ ]

            */

            Point[] set3 =
            {
                new Point(0, 0),
                new Point(1, 1),
                new Point(-1, -1),
                new Point(-1, 1)
            };

            /*
            Set 4

            [ ][ ][c][ ]            [ ][ ][ ][ ]
            [ ][d][a][ ]            [ ][c][a][b]
            [ ][ ][b][ ]    ==>     [ ][ ][d][ ]
            [ ][ ][ ][ ]            [ ][ ][ ][ ]

            */

            Point[] set4 =
            {
                new Point(0, 0),
                new Point(1, -1),
                new Point(-1, 1),
                new Point(1, 1)
            };

            Point[][] offset = { set1, set2, set3, set4 };

            return offset;
        }

        /// <summary>
        /// T Shape-specific rotate.
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
        /// I Shape-specific reset position.
        /// </summary>
        public override void Reset()
        {
            int center = (5);

            Point a = new Point(center, 0);
            Point b = new Point(center + 1, 0);
            Point c = new Point(center - 1, 0);
            Point d = new Point(center, 1);

            blocks[0].Position = a;
            blocks[1].Position = b;
            blocks[2].Position = c;
            blocks[3].Position = d;
        }
    }
}


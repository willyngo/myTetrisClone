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
    public class ShapeZ : Shape
    {
        /// <summary>
        /// Constructs a specific Z Shape object.
        /// </summary>
        /// <param name="board">The game board.</param>
        public ShapeZ(IBoard board) : base(board)
        {
            currentRotation = 0;
            rotationOffset = setRotationOffsets();

            int center = board.GetLength(1) / 2;

            /*
            Initial position
            [ ][ ][ ][ ]
            [ ][b][a][ ]
            [ ][ ][c][d]
            [ ][ ][ ][ ]
            */

            Point a = new Point(center, 0);
            Point b = new Point(center - 1, 0);
            Point c = new Point(center, 1);
            Point d = new Point(center + 1, 1);


            Block[] gamePiece =
            {
                new Block(board, Color.Red, a),
                new Block(board, Color.Red, b),
                new Block(board, Color.Red, c),
                new Block(board, Color.Red, d)
            };

            blocks = gamePiece;

        }

        private Point[][] setRotationOffsets()
        {

            /*     
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]            
            [ ][ ][ ][ ][b][a][ ][ ][ ][ ]
            [ ][ ][ ][ ][ ][c][d][ ][ ][ ]
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
            
            */

            Point[] set1 =
            {
                new Point(0, 0),
                new Point(-1, 1),
                new Point(1, 1),
                new Point(2, 0)
            };


            /* 
                        
            [ ][ ][ ][ ][ ][b][ ][ ][ ][ ]
            [ ][ ][ ][ ][c][a][ ][ ][ ][ ]
            [ ][ ][ ][ ][d][ ][ ][ ][ ][ ]
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
            
            */

            Point[] set2 =
            {
                new Point(0, 0),
                new Point(1, -1),
                new Point(-1, -1),
                new Point(-2, 0)
            };



            Point[][] offset = { set2, set1 };

            return offset;

        }

        /// <summary>
        /// Z Shape-specific rotate.
        /// </summary>
        public override void Rotate()
        {
            
            int set = currentRotation % 2;
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
            Point b = new Point(center - 1, 0);
            Point c = new Point(center, 1);
            Point d = new Point(center + 1, 1);

            blocks[0].Position = a;
            blocks[1].Position = b;
            blocks[2].Position = c;
            blocks[3].Position = d;
        }
    }
}

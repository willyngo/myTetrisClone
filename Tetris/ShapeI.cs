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
    public class ShapeI : Shape
    {
        /// <summary>
        /// Constructs a specific I Shape object.
        /// </summary>
        /// <param name="board">The game board.</param>
        public ShapeI(IBoard board) : base(board)
        {
            currentRotation = 0;
            rotationOffset = setOffsets();
            int center = (board.GetLength(1) / 2);

            Point a = new Point(center, 0);
            Point b = new Point(center + 1, 0);
            Point c = new Point(center - 1, 0);
            Point d = new Point(center - 2, 0);

            Block[] gamePiece =
                {
                   new Block(board, Color.Cyan, a),
                   new Block(board, Color.Cyan, b),
                   new Block(board, Color.Cyan, c),
                   new Block(board, Color.Cyan, d)
                };

            /*
            Initial position 
            [ ][ ][ ][ ]
            [d][c][a][b]
            [ ][ ][ ][ ]
            [ ][ ][ ][ ]
            */

            blocks = gamePiece;
        }

        public Point[][] setOffsets()
        {
            /*
            Set 1 puts the shape in its vertical position


            [ ][ ][ ][ ]            [ ][ ][b][ ]
            [d][c][a][b]            [ ][ ][a][ ]
            [ ][ ][ ][ ]    ==>     [ ][ ][c][ ]
            [ ][ ][ ][ ]            [ ][ ][d][ ]
            
            */
            Point[] set1 =
            {
                new Point(0,0),
                new Point (1,1),
                new Point (-1,-1),
                new Point(-2,-2)
            };

            /*
            set 2 puts the shape in its horizontal position

            [ ][ ][b][ ]            [ ][ ][ ][ ]
            [ ][ ][a][ ]            [d][c][a][b]
            [ ][ ][c][ ]    ==>     [ ][ ][ ][ ]
            [ ][ ][d][ ]            [ ][ ][ ][ ]


            */

            Point[] set2 =
            {
                new Point(0,0),
                new Point (-1,-1),
                new Point (1,1),
                new Point(2,2)
            };

            Point[][] offset = { set2, set1 };

            return offset;
        }

        /// <summary>
        /// I Shape-specific rotate.
        /// </summary>
        public override void Rotate()
        {
            
            int set = currentRotation % 2; //Since there is only two possible rotations
            int blockCtr = 0; //Counter to determine which point to rotate.
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

            if(canRotate)
            {
                //If the rotation was successful, Increment the current rotation to go to the next offset.
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
            Point d = new Point(center - 2, 0);

            blocks[0].Position = a;
            blocks[1].Position = b;
            blocks[2].Position = c;
            blocks[3].Position = d;
        }
    }
}

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
    public class ShapeO : Shape
    {
        /// <summary>
        /// Constructs a specific O Shape object.
        /// </summary>
        /// <param name="board">The game board.</param>
        public ShapeO(IBoard board) : base(board)
        {
            currentRotation = 0;
            rotationOffset = setOffsets();
            int center = (board.GetLength(1) / 2);

            Point a = new Point(center, 0);
            Point b = new Point(center - 1, 0);
            Point c = new Point(center - 1, 1);
            Point d = new Point(center, 1);

            Block[] gamePiece =
                {
                   new Block(board, Color.Yellow, a),
                   new Block(board, Color.Yellow, b),
                   new Block(board, Color.Yellow, c),
                   new Block(board, Color.Yellow, d)
                };

            /*
            Initial position 
            [ ][ ][ ][ ][b][a][ ][ ][ ][ ]
            [ ][ ][ ][ ][c][d][ ][ ][ ][ ]
            [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ]
            */

            blocks = gamePiece;
        }

        public Point[][] setOffsets()
        {
            //Since its shape doesn't differ when rotated, no need to adjust
            //offset values.
            Point[] set1 =
            {
                new Point(0,0),
                new Point(0,0),
                new Point(0,0),
                new Point(0,0)
            };

            Point[][] offset = { set1 };
            return offset;
        }

        /// <summary>
        /// O Shape-specific rotate.
        /// </summary>
        public override void Rotate()
        {
            //Shape O does not change when rotated, so no need to adjust.
            return;
        }

        /// <summary>
        /// O Shape-specific reset position.
        /// </summary>
        public override void Reset()
        {
            int center = 5;

            Point a = new Point(center, 0);
            Point b = new Point(center - 1, 0);
            Point c = new Point(center - 1, 1);
            Point d = new Point(center, 1);

            blocks[0].Position = a;
            blocks[1].Position = b;
            blocks[2].Position = c;
            blocks[3].Position = d;
        }
    }
}

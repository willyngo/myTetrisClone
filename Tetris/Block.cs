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
    public class Block
    {
        private IBoard board;
        private Color colour;
        public Point position;

        /// <summary>
        /// Constructs the Block object, which determines how a block will 
        /// move on the board.
        /// </summary>
        /// <param name="board">The game board</param>
        /// <param name="colour">The color</param>
        /// <param name="position">The position</param>
        public Block(IBoard board, Color colour, Point position)
        {
            this.board = board;
            this.colour = colour;
            this.position = position;
        }

        //Properties
        public Color Colour
        {
            get { return colour; }
        }

        public Point Position
        {
            get { return position; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Point is null.");
                else
                    position = value;
            }
        }

        //Methods
        /// <summary>
        /// Checks if the block can move left.
        /// </summary>
        /// <returns>True or false if the block can move left.</returns>
        public bool TryMoveLeft()
        {
            int current_x = position.X;
            int current_y = position.Y;
            try
            {
                if (board[current_y, current_x - 1] == Color.Transparent)
                    return true;
                else
                    return false;
            }
            catch (IndexOutOfRangeException ioe)
            {
                Console.WriteLine("Tried moving left - unable: " + ioe.Message);
                return false;
            }
        }

        /// <summary>
        /// Checks if the block can move right.
        /// </summary>
        /// <returns>True or false if the block can move right.</returns>
        public bool TryMoveRight()
        {
            int current_x = position.X;
            int current_y = position.Y;

            try
            {

                if (board[current_y, current_x + 1] == Color.Transparent)
                    return true;
                else
                    return false;
            }
            catch (IndexOutOfRangeException ioe)
            {
                Console.WriteLine("Tried moving right - unable: " + ioe.Message);
                return false;
            }
        }

        /// <summary>
        /// Checks if the block can move down.
        /// </summary>
        /// <returns>True or false if the block can move down.</returns>
        public bool TryMoveDown()
        {
            int current_x = position.X;
            int current_y = position.Y;

            try
            {
                if (board[current_y + 1, current_x] == Color.Transparent)
                    return true;
                else
                    return false;
            }
            catch (IndexOutOfRangeException ioe)
            {
                Console.WriteLine("Tried moving down - unable: " + ioe.Message);
                return false;
            }
        }

        /// <summary>
        /// Checks if the block can rotate.
        /// </summary>
        /// <returns>True or false if the block can rotate.</returns>
        public bool TryRotate(Point offset)
        {
            try
            {
                if (board[position.Y + offset.Y, position.X + offset.X] == Color.Transparent)
                {
                    return true;
                }
                return false;
            }
            catch (IndexOutOfRangeException ioe)
            {
                Console.WriteLine("Could not rotate: " + ioe.Message);
                return false;
            }
        }

        /// <summary>
        /// Moves the block to the left.
        /// </summary>
        public void MoveLeft()
        {
            if (TryMoveLeft())
                position.X = position.X - 1;
        }

        /// <summary>
        /// Moves the block to the right.
        /// </summary>
        public void MoveRight()
        {
            if (TryMoveRight())
                position.X = position.X + 1;
        }

        /// <summary>
        /// Moves the block down.
        /// </summary>
        public void MoveDown()
        {
            if (TryMoveDown())
                position.Y = position.Y + 1;
        }

        /// <summary>
        /// Rotates the block.
        /// </summary>
        public void Rotate(Point offset)
        {
            if(TryRotate(offset))
            {
                position.X = position.X + offset.X;
                position.Y = position.Y + offset.Y;
            }
        }
    }
}

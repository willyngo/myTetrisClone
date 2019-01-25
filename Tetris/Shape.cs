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
    /// <summary>
    /// Abstract class of a Shape containing methods that define behaviour
    /// for all inheriting Shape classes.
    /// </summary>
    public abstract class Shape : IShape
    {
        private IBoard board;
        protected Block[] blocks;
        protected Point[][] rotationOffset;
        protected int currentRotation;
        

        public event JoinPileHandler JoinPile;

        public Shape(IBoard board)
        {
            this.board = board;
        }
        
        //Methods that fire the event
        /// <summary>
        /// Method that fires the JoinPile event.
        /// </summary>
        protected void OnJoinPile()
        {
            if (JoinPile != null)
                JoinPile();
        }

        public Block this[int i]
        {
            get { return blocks[i]; }
        }

        
        /// <summary>
        /// Method that moves the shape to the left using Block objects.
        /// </summary>
        public void MoveLeft()
        {
            bool canMove = true;
            foreach (Block aBlock in blocks)
            {
                if (!aBlock.TryMoveLeft())
                    canMove = false;
            }

            if(canMove)
            {
                foreach (Block aBlock in blocks)
                    aBlock.MoveLeft();
            }
        }

        /// <summary>
        /// Method that moves the shape to the right using Block objects.
        /// </summary>
        public void MoveRight()
        {
            bool canMove = true;
            foreach (Block aBlock in blocks)
            {
                if (!aBlock.TryMoveRight())
                    canMove = false;
            }

            if (canMove)
            {
                foreach (Block aBlock in blocks)
                    aBlock.MoveRight();
            }
        }

        /// <summary>
        /// Method that moves the shape down using Block objects.
        /// </summary>
        /// <returns>True or false if the block can move down.</returns>
        public bool MoveDown()
        {
            bool canMove = true;
            foreach (Block aBlock in blocks)
            {
                if (!aBlock.TryMoveDown())
                {
                    OnJoinPile();
                    return canMove = false;
                }
            }

            if (canMove)
            {
                foreach (Block aBlock in blocks)
                    aBlock.MoveDown();
            }

            return canMove;
        }

        /// <summary>
        /// Method that drops the shape to the lowest possible point.
        /// </summary>
        public void Drop()
        {
            bool canMove = true;
            while(canMove)
            {
                foreach(Block aBlock in blocks)
                {
                    //Check if block can still move down. Breaks out of loop when it can no longer drop down.
                    if (!aBlock.TryMoveDown())
                    {
                        OnJoinPile();
                        canMove = false;
                        break;
                    }
                }

                if(canMove)
                    MoveDown();
            }
            
        }

        public abstract void Rotate();

        public abstract void Reset();

        // for unit testing 

        public String getPositionOfBlocks()
        {
            String coordinates = "";

            foreach (Block aBlock in blocks)
            {
                coordinates += "(" + aBlock.Position.X + ", " + aBlock.Position.Y + ")"; 
            }

            return coordinates;
        }

        int IShape.Length
        {
            get { return 4; }
        }
        
    }
}

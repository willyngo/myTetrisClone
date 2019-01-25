using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Tetris
{
    public delegate void JoinPileHandler();

    /// <authors>
    /// Seaim Khan and William Ngo
    /// </authors>
    public interface IShape
    {
        //Properties
        /// <summary>
        /// Property that gets the length of a shape.
        /// </summary>
        int Length { get; }

        //Indexer
        /// <summary>
        /// Indexer that gets a specified block.
        /// </summary>
        /// <param name="i">A block index.</param>
        /// <returns>A specified block.</returns>
        Block this[int i] { get; }

        //Events
        /// <summary>
        /// Event for a shape object joining the pile.
        /// </summary>
        event JoinPileHandler JoinPile;

        //Methods
        /// <summary>
        /// Moves the shape to the left.
        /// </summary>
        void MoveLeft();

        /// <summary>
        /// Moves the shape to the right.
        /// </summary>
        void MoveRight();

        /// <summary>
        /// Moves the shape down.
        /// </summary>
        /// <returns>True or false if the shape can move down.</returns>
        bool MoveDown();

        /// <summary>
        /// Drops the shape completely down to the bottom.
        /// </summary>
        void Drop();

        /// <summary>
        /// Rotates the shape clockwise.
        /// </summary>
        void Rotate();

        /// <summary>
        /// Resets the shape position to original.
        /// </summary>
        void Reset();
    }
}

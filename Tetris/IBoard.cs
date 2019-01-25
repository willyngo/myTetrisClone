using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Tetris
{
    public delegate void LinesClearedHandler(int lines);
    public delegate void GameOverHandler();

    /// <authors>
    /// Seaim Khan and William Ngo
    /// </authors>
    public interface IBoard
    {
        //Properties
        /// <summary>
        /// Sends the shape.
        /// </summary>
        IShape Shape { get; }

        //Indexer
        /// <summary>
        /// Board coordinates
        /// </summary>
        /// <param name="i">The x coordinate</param>
        /// <param name="j">The y coordinate</param>
        /// <returns>The coordinates</returns>
        Color this[int i, int j] { get; }

        //Events
        /// <summary>
        /// An event for lines being cleared.
        /// </summary>
        event LinesClearedHandler LinesCleared;

        /// <summary>
        /// An event for the game being over.
        /// </summary>
        event GameOverHandler GameOver;

        //Methods
        /// <summary>
        /// Return the length of a specified dimension.
        /// </summary>
        /// <param name="rank"></param>
        /// <returns></returns>
        int GetLength(int rank);
    }
}
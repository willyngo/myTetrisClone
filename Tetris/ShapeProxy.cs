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
    public class ShapeProxy : IShapeFactory, IShape
    {
        private static Random random;
        private IShape current;
        private IBoard board;

        //Event that initiates when a shape joins the pile.
        public event JoinPileHandler JoinPile;

        /// <summary>
        /// Constructs a ShapeProxy object, that acts as an interface between the 
        /// shapes and other classes.
        /// </summary>
        /// <param name="board">The game board.</param>
        public ShapeProxy(IBoard board)
        {
            this.board = board;
            DeployNewShape();
        }

        //Indexer
        public Block this[int i]
        {
            get { return current[i]; }
        }

        //Properties
        public int Length
        {
            get { return current.Length; }
        }

        //Methods
        /// <summary>
        /// Method that generates a random shape out of the seven concrete 
        /// shapes.
        /// </summary>
        public void DeployNewShape()
        {
            random = new Random();
            int tetrisShapes = random.Next(1, 8);

            switch (tetrisShapes)
            {
                case 1:
                    current = new ShapeI(board);
                    current.JoinPile += OnJoinPile;
                    break;
                case 2:
                    current = new ShapeJ(board);
                    current.JoinPile += OnJoinPile;
                    break;
                case 3:
                    current = new ShapeL(board);
                    current.JoinPile += OnJoinPile;
                    break;
                case 4:
                    current = new ShapeO(board);
                    current.JoinPile += OnJoinPile;
                    break;
                case 5:
                    current = new ShapeS(board);
                    current.JoinPile += OnJoinPile;
                    break;
                case 6:
                    current = new ShapeT(board);
                    current.JoinPile += OnJoinPile;
                    break;
                case 7:
                    current = new ShapeZ(board);
                    current.JoinPile += OnJoinPile;
                    break;
                default:
                    throw new ArgumentException("Error: Invalid shape!");
            }
            
        }

        /// <summary>
        /// Move shape to the left, calling the one implemented in Shape.
        /// </summary>
        public void MoveLeft()
        {
            current.MoveLeft();
        }

        /// <summary>
        /// Move shape to the right, calling the one implemented in Shape.
        /// </summary>
        public void MoveRight()
        {
            current.MoveRight();
        }

        /// <summary>
        /// Move shape down, calling the one implemented in Shape.
        /// </summary>
        public bool MoveDown()
        {
            return current.MoveDown();
        }

        /// <summary>
        /// Drop shape to the bottom, calling the one implemented in Shape.
        /// </summary>
        public void Drop()
        {
            current.Drop();
        }

        /// <summary>
        /// Rotate the shape, calling the one implemented in Shape.
        /// </summary>
        public void Rotate()
        {
            current.Rotate();
        }

        /// <summary>
        /// Reset shape's position, calling the one implemented in Shape.
        /// </summary>
        public void Reset()
        {
            current.Reset();
        }

        /// <summary>
        /// Method that fires the JoinPile event.
        /// </summary>
        protected void OnJoinPile()
        {
            if (JoinPile != null)
                JoinPile();
        }
    }
}
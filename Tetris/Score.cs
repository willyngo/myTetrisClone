using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Tetris
{
    public class Score
    {
        private int level;
        private int numLines;
        private int currentScore;
        private IBoard board;

        /// <summary>
        /// Constructor
        /// </summary>
        public Score(Board board)
        {
            this.board = board;
            board.LinesCleared += incrementLinesCleared;
            this.level = 0;
            this.numLines = 0;
            this.currentScore = 0;
        }

        /// <summary>
        /// The current level.
        /// </summary>
        public int Level
        {
            get { return level; }
        }

        /// <summary>
        /// The number of lines
        /// </summary>
        public int Lines
        {
            get { return numLines; }
        }

        /// <summary>
        /// The current score
        /// </summary>
        public int GameScore
        {
            get { return currentScore; }
        }

        /// <summary>
        /// Event handler
        /// </summary>
        /// <param name="num"></param>
        private void incrementLinesCleared(int num)
        {
            numLines += num;

            if (numLines == 1)
                currentScore = currentScore + 100;
            else
                currentScore = currentScore + (num * 200);

            level = MathHelper.Min((numLines / 10 + 1), 10);
        }
    }
}

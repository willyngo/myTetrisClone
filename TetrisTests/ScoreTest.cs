using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetris;
using TetrisTests;

namespace TetrisTest
{
    [TestClass]
    public class ScoreTest
    {
        [TestMethod]
        public void incrementLinesCleared_BottomLineClear()
        {
            TestScore score = new TestScore();
            bool match1, match2;

            score.incrementLinesCleared(1);
            if (score.Lines == 1)
                match1 = true;
            else
                match1 = false;

            score.incrementLinesCleared(3);
            if (score.Lines == 4)
                match2 = true;
            else
                match2 = false;


            Assert.AreEqual(true, (true && (match1 && match2)));

        }

        [TestMethod]
        public void incrementLinesCleared_Score()
        {
            TestScore score = new TestScore();
            bool match1, match2;

            score.currentScore = 0;
            score.numLines = 0;

            score.incrementLinesCleared(2);
            if (score.GameScore == 400)
                match1 = true;
            else
                match1 = false;

            score.incrementLinesCleared(1);
            if (score.GameScore == 600)
                match2 = true;
            else
                match2 = false;

            Assert.AreEqual(true, (true && (match1 && match2)));
        }
    }
}

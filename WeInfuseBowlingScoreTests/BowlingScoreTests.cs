using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeInfuseBowlingScore;
using System;
using System.Collections.Generic;

namespace WeInfuseBowlingScore.Tests
{
    [TestClass()]
    public class BowlingScoreTests
    {
        private BowlingScore _score = new BowlingScore();

        [TestMethod()]
        public void CalculateScore_IncompleteFrames()
        {
            string[] bowlingFrames = { "4", "5", "X", "8" };
            string[] frameScores = _score.CalculateScore(bowlingFrames);
            string[] correctScores = { "9" };
            CollectionAssert.AreEqual(correctScores, frameScores);
        }

        [TestMethod()]
        public void CalculateScore_3CompleteFrames()
        {
            string[] bowlingFrames = { "4", "5", "X", "8", "1" };
            string[] frameScores = _score.CalculateScore(bowlingFrames);
            string[] correctScores = { "9", "19", "9" };
            CollectionAssert.AreEqual(correctScores, frameScores);
        }

        [TestMethod()]
        public void CalculateScore_CompleteGameWithExtraFrame()
        {
            string[] bowlingFrames = { "4", "5", "X", "8", "1", "3", "/", "5", "2", "4", "/", "X", "4", "/", "8", "1", "X", "X", "5" };
            string[] frameScores = _score.CalculateScore(bowlingFrames);
            string[] correctScores = { "9", "19", "9", "15", "7", "20", "20", "18", "9", "25" };
            CollectionAssert.AreEqual(correctScores, frameScores);
        }

        [TestMethod()]
        public void CalculateScore_CompleteGameWithoutExtraFrame()
        {
            string[] bowlingFrames = { "4", "5", "X", "8", "1", "3", "/", "5", "2", "4", "/", "X", "4", "/", "8", "1", "6", "3" };
            string[] frameScores = _score.CalculateScore(bowlingFrames);
            string[] correctScores = { "9", "19", "9", "15", "7", "20", "20", "18", "9", "9" };
            CollectionAssert.AreEqual(correctScores, frameScores);
        }

        [TestMethod()]
        public void CalculateScore_PerfectGame()
        {
            string[] bowlingFrames = { "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X" };
            string[] frameScores = _score.CalculateScore(bowlingFrames);
            string[] correctScores = { "30", "30", "30", "30", "30", "30", "30", "30", "30", "30", };
            CollectionAssert.AreEqual(correctScores, frameScores);
        }
    }
}
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetris;

namespace TetrisTests
{
    [TestClass]
    public class ShapeProxyTest
    {
        [TestMethod]
        public void DeployNewShape()
        {
            Board board = new Board();
            IShape current = new ShapeProxy(board);
            int count = 0;

            for(int i = 0; i < current.Length; i++)
            {
                count++;
            }

            Assert.AreEqual(true, current.Length == count);

        }
    }
}

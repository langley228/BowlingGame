using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace kata.game.test
{
    [TestClass]
    public class GameTest
    {
        private Game g;

        [TestInitialize]
        public void setup()
        {
            g = new Game();
        }

        [TestMethod]
        public void testGutterGame()
        {
            int expected = 0;
            int actual = 0;
            rollManny(20, 0);
            actual = g.score();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void testAllOnes()
        {
            int expected = 20;
            int actual = 0;
            rollManny(20, 1);
            actual = g.score();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void testOneSpare()
        {
            int expected = 16;
            int actual = 0;
            roolSpare();
            rollManny(1, 3);
            rollManny(17, 0);
            actual = g.score();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void testOneStrile()
        {
            int expected = 24;
            int actual = 0;
            roolStrike();
            g.roll(3);
            g.roll(4);
            rollManny(16, 0);
            actual = g.score();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void testPerfextGame()
        {
            int expected = 300;
            int actual = 0;
            rollManny(12, 10);
            actual = g.score();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void testPerfextGameT()
        {
            int expected = 271;
            int actual = 0;
            rollManny(9, 10);
            rollManny(1, 1);
            rollManny(1, 9);
            rollManny(1, 10);
            actual = g.score();
            //10 10 10 10 10 10 10 10 10 1 9 10
            //10 10 10 10 10 10 10 10  1   
            //10 10 10 10 10 10 10 1   9
 
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void testRoll5x21()
        {
            int expected = 150;
            int actual = 0;
            rollManny(21, 5);
            actual = g.score();
            Assert.AreEqual(expected, actual);
        }

        private void roolStrike()
        {
            g.roll(10);
        }

        private void roolSpare()
        {
            g.roll(5);
            g.roll(5);
        }

        private void rollManny(int n ,int pins)
        {
            for (int i = 0; i < n; i++)
            {
                g.roll(pins);
            }
        }
    }
}

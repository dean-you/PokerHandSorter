using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerHandSorter.Domain.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHandSorter.Tests
{
    [TestClass()]
    public class GameTests
    {
        [TestMethod()]
        public void PlayTest_Pair()
        {
            var t = new Game();
            t.Play("4H 4C 6S 7S KD 2C 3S 9S 9D TD");
            Assert.AreEqual(t.Player2Win, true);
        }

        [TestMethod()]
        public void PlayTest_2Pairs()
        {
            var t = new Game();
            t.Play("4H 4C 2H 2C KD 3C 3S 4S 4D TD");
            Assert.AreEqual(t.Player2Win, true);
        }

        [TestMethod()]
        public void PlayTest_HighCard()
        {
            var t = new Game();
            t.Play("5D 8C 9S JS AC 2C 5C 7D 8S QH");
            Assert.AreEqual(t.Player1Win, true);
        }

        [TestMethod()]
        public void PlayTest_ThreeAces_VS_Flush()
        {
            var t = new Game();
            t.Play("2D 9C AS AH AC 3D 6D 7D TD QD");
            Assert.AreEqual(t.Player2Win, true);
        }

        [TestMethod()]
        public void PlayTest_Flush()
        {
            var t = new Game();
            t.Play("2C 9C AC KC AC 3D 6D 7D TD QD");
            Assert.AreEqual(t.Player1Win, true);
        }

        [TestMethod()]
        public void PlayTest_Pair_HighCard()
        {
            var t = new Game();
            t.Play("4D 6S 9H QH QC 3D 6D 7H QD QS");
            Assert.AreEqual(t.Player1Win, true);
        }

        [TestMethod()]
        public void PlayTest_FullHouse()
        {
            var t = new Game();
            t.Play("2H 2D 4C 4D 4S 3C 3D 3S 9S 9D");
            Assert.AreEqual(t.Player1Win, true);
        }

        [TestMethod()]
        public void PlayTest_FullHouse1()
        {
            var t = new Game();
            t.Play("2H 2D 4C 4D 4S 4C 4D 4S 9S 9D");
            Assert.AreEqual(t.Player2Win, true);
        }

        [TestMethod()]
        public void PlayTest_Straight()
        {
            var t = new Game();
            t.Play("2H 3D 4C 5D 6S 3C 4D 5S 6S 7D");
            Assert.AreEqual(t.Player2Win, true);
        }
    }
}
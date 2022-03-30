using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerHandSorter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHandSorter.Tests
{
    [TestClass()]
    public class HandTests
    {
        [TestMethod()]
        public void HandTest_HighCard()
        {
            var t = new Hand("5D 8C 9S JS AC");
            Assert.AreEqual(CardValue.Ace, t.HighCard1);
            Assert.AreEqual(CardValue.Jack, t.HighCard2);
            Assert.AreEqual(CardValue.Nine, t.HighCard3);
            Assert.AreEqual(CardValue.Eight, t.HighCard4);
            Assert.AreEqual(CardValue.Five, t.HighCard5);
        }

        [TestMethod()]
        public void HandTest_Pair()
        {
            var t = new Hand("4H 4C 6S 7S KD");
            Assert.AreEqual(CardValue.Four, t.Pair1);
            Assert.AreEqual(CardValue.None, t.Pair2);
            Assert.AreEqual(CardValue.King, t.HighCard1);
            Assert.AreEqual(CardValue.Seven, t.HighCard2);
            Assert.AreEqual(CardValue.Six, t.HighCard3);
        }

        [TestMethod()]
        public void HandTest_ThreeKind()
        {
            var t = new Hand("2D 2C 2S AH 3C");
            Assert.AreEqual(CardValue.Ace, t.HighCard1);
            Assert.AreEqual(CardValue.Three, t.HighCard2);
            Assert.AreEqual(CardValue.Two, t.ThreeKind);
        }

        [TestMethod()]
        public void HandTest_FourKind()
        {
            var t = new Hand("2D 2C 2S AH 2C");
            Assert.AreEqual(CardValue.Ace, t.HighCard1);
            Assert.AreEqual(CardValue.Two, t.FourKind);
        }

        [TestMethod()]
        public void HandTest_StraightFlush()
        {
            var t = new Hand("2D 3D 4D 5D 6D");
            var r = t.StraightFlush();
            Assert.AreEqual(CardValue.Six, r);
        }

        [TestMethod()]
        public void HandTest_StraightNotFlush()
        {
            var t = new Hand("2D 3D 4D 5D 6C");
            var r = t.StraightFlush();
            Assert.AreEqual(CardValue.None, r);
        }

    }
}
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
            Assert.AreEqual(14, t.HighCard1);
            Assert.AreEqual(11, t.HighCard2);
            Assert.AreEqual(9, t.HighCard3);
            Assert.AreEqual(8, t.HighCard4);
            Assert.AreEqual(5, t.HighCard5);
        }

        [TestMethod()]
        public void HandTest_Pair()
        {
            var t = new Hand("4H 4C 6S 7S KD");
            Assert.AreEqual(4, t.Pair1);
            Assert.AreEqual(0, t.Pair2);
            Assert.AreEqual(13, t.HighCard1);
            Assert.AreEqual(7, t.HighCard2);
            Assert.AreEqual(6, t.HighCard3);
        }

        [TestMethod()]
        public void HandTest_ThreeKind()
        {
            var t = new Hand("2D 2C 2S AH 3C");
            Assert.AreEqual(14, t.HighCard1);
            Assert.AreEqual(3, t.HighCard2);
            Assert.AreEqual(2, t.ThreeKind);
        }

        [TestMethod()]
        public void HandTest_FourKind()
        {
            var t = new Hand("2D 2C 2S AH 2C");
            Assert.AreEqual(14, t.HighCard1);
            Assert.AreEqual(2, t.FourKind);
        }

        [TestMethod()]
        public void HandTest_StraightFlush()
        {
            var t = new Hand("2D 3D 4D 5D 6D");
            var r = t.StraightFlush();
            Assert.AreEqual(6, r);
        }

        [TestMethod()]
        public void HandTest_StraightNotFlush()
        {
            var t = new Hand("2D 3D 4D 5D 6C");
            var r = t.StraightFlush();
            Assert.AreEqual(0, r);
        }

    }
}
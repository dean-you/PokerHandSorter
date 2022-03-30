using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerHandSorter.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHandSorter.Tests
{
    [TestClass()]
    public class CardTests
    {
        [TestMethod()]
        public void CardTest()
        {
            var card = new Card("2D");
            Assert.AreEqual(CardValue.Two, card.Value);
            Assert.AreEqual(CardSuit.Diamonds, card.Suit);
        }

        [TestMethod()]
        public void CardTest1()
        {
            var card = new Card("3H");
            Assert.AreEqual(CardValue.Three, card.Value);
            Assert.AreEqual(CardSuit.Hearts, card.Suit);
        }

        [TestMethod()]
        public void CardTest2()
        {
            var card = new Card("JS");
            Assert.AreEqual(CardValue.Jack, card.Value);
            Assert.AreEqual(CardSuit.Spades, card.Suit);
        }

        [TestMethod()]
        public void CardTest3()
        {
            var card = new Card("AC");
            Assert.AreEqual(CardValue.Ace, card.Value);
            Assert.AreEqual(CardSuit.Clubs, card.Suit);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void CardTest_InvalidSuit_ShallThrowArgumentException()
        {
            new Card("2K");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void CardTest_InvalidCardValue_ShallThrowArgumentException()
        {
            new Card("ZD");
        }
    }
}
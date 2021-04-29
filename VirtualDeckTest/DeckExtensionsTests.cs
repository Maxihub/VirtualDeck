
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VirtualDeck;

namespace VirtualDeckTest
{

        [TestClass]
    public class DeckExtenstionsTests
    {
        [TestMethod]
        [DataRow(52)]
        public void GetFullDeckTest(int expectedCount)
            {

                Deck testDeck = new Deck();
                int result = testDeck.Cards.Count;
                Assert.AreEqual(expectedCount, result);


            }
        [TestMethod]
        [DataRow(11, "Jack"), DataRow(12, "Queen"), DataRow(13, "King"), DataRow(1, "Ace")]
        public void GetFaceCardTest(int input, string expected)
            {
                Card cardToTest = new Card()
                {
                    Value = input
                };
                cardToTest.GetFaceCard();
                string result = cardToTest.FaceCard;


                Assert.AreEqual(expected, result);
            }
        [TestMethod]
        [DataRow(51)]
        public void PullCardTest(int expected)
            {
                
                Deck fullDeck = new Deck();

                Card TopCardBeforePull = fullDeck.Cards.First();
                fullDeck.PullCard();
                Card TopCardAfterPull = fullDeck.Cards.First();

                int result = fullDeck.Cards.Count;

                Assert.AreNotEqual(TopCardBeforePull, TopCardAfterPull); //Checks wether top card has changed
                Assert.AreEqual(expected, result); // Checks wether top card was removed from deck


            }
        [TestMethod]
        public void ShuffleDeckTest()
            {
                bool unique = false;

                Deck firstDeck = new Deck();
                Deck secondDeck = new Deck();

                firstDeck.ShuffleDeck(); //shuffle first deck

                for (int i = 0; i < firstDeck.Cards.Count; i++)
                {
                    if (firstDeck.Cards[i] != secondDeck.Cards[i])
                    {
                        unique = true;
                        break;
                    }
                }

                Assert.IsTrue(unique);

            }
        [TestMethod]
        [DataRow(1, true), DataRow(2, false), DataRow(3, false),
        DataRow(4, false),DataRow(5, false),DataRow(6, false),
        DataRow(11, true), DataRow(12, true), DataRow(13, true)]

        public void HasFaceCardTest(int input, bool expected)
        {
            Card testCard = new Card();
            testCard.Value = input;
            testCard.GetFaceCard();
            bool result = testCard.HasFaceCard();
            Assert.AreEqual(expected, result);
            
        }


        [TestMethod]
        public void SortDeckTest()
            {
                VirtualDeckApp cg = new VirtualDeckApp();
                bool isMatch = false;
                Deck firstDeck = new Deck();
                Deck secondDeck = new Deck();

                firstDeck.ShuffleDeck();
                secondDeck.ShuffleDeck();

                firstDeck.SortDeck();
                secondDeck.SortDeck();

                for (int i = 0; i < firstDeck.Cards.Count; i++)
                {
                    if(firstDeck.Cards[i].Value == secondDeck.Cards[i].Value && firstDeck.Cards[i].Name == secondDeck.Cards[i].Name)
                {
                    isMatch = true;
                }
                }




                Assert.IsTrue(isMatch);
            }


    }

}


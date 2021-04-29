using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VirtualDeck
{
    public static class DeckExtensions
    {
        /// <summary>
        /// Defines full set of cards in a deck with both Suit and Value
        /// </summary>
        /// <param name="deck"></param>
        public static void GetFullDeck(this Deck deck)
        {
            deck.Cards = new List<Card>();
            foreach (Card.Suit suit in Enum.GetValues(typeof(Card.Suit)))
            {
                for (int i = 1; i < 14; i++)
                {
                    Card genericCard = new Card()
                    {
                        Value = i,
                        Name = suit
                    };
                    deck.Cards.Add(genericCard);

                }

            }


        }
        /// <summary>
        /// Places the cards in the deck in a random order using the Fisher Yates-algorithm
        /// </summary>
        /// <param name="deck"></param>
        public static void ShuffleDeck(this Deck deck)
        {
            
            var rand = new Random();
            var n = deck.Cards.Count;

            for (var i = 0; i < n; i++)
            {
                var r = i + rand.Next(n - i);
                var card = deck.Cards[r];
                deck.Cards[r] = deck.Cards[i];
                deck.Cards[i] = card;
            }
        }
        /// <summary>
        /// Sorting the deck by both Suit and Value
        /// </summary>
        /// <param name="deck"></param>
        public static void SortDeck(this Deck deck)
        {

            deck.Cards = deck.Cards.OrderBy(c => (int)c.Name).ThenBy(c => c.Value).ToList();           
        }
        /// <summary>
        /// Removes the top card from a Deck
        /// </summary>
        /// <param name="deck"></param>
        /// <returns>The Card on top of the deck</returns>
        public static Card PullCard(this Deck deck)
        {

            Card topCard = new Card();
            if (deck.Cards.Count != 0)
            {
                topCard = deck.Cards.First();
                int indexTopCard = deck.Cards.IndexOf(topCard);
                deck.Cards.RemoveAt(indexTopCard);

            }

            return topCard;

        }
        /// <summary>
        /// Gives the right cards their face value (head)
        /// </summary>
        /// <param name="pulledCard"></param>
        public static void GetFaceCard(this Card pulledCard)
        {
            switch (pulledCard.Value)
            {
                case 11:
                    pulledCard.FaceCard = "Jack";
                    break;
                case 12:
                    pulledCard.FaceCard = "Queen";
                    break;
                case 13:
                    pulledCard.FaceCard = "King";
                    break;
                case 1:
                    pulledCard.FaceCard = "Ace";
                    break;
            }
        }
        /// <summary>
        /// Checks if a card has a face card
        /// </summary>
        /// <param name="pulledCard"></param>
        /// <returns>true if card.FaceCard is not equal to null</returns>
        public static bool HasFaceCard(this Card pulledCard)
        {
            if (pulledCard.FaceCard == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}

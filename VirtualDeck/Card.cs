using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualDeck
{
    public class Card
    {
        public enum Suit
        {
            Diamonds = 1,
            Hearts = 2,
            Clubs = 3,
            Spades = 4
        }

        public Suit Name { get; set; }
        public int Value { get; set; }
        public string FaceCard { get; set; }
    }
}

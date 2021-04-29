using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualDeck
{
    public class Deck
    {
        public List<Card> Cards { get; set; }
        public string DeckName { get; set; }
        public Deck(string deckName)
        {
            this.DeckName = deckName;
            this.GetFullDeck();
        }
        public Deck()
        {
            this.GetFullDeck();
        }
    }
    
}

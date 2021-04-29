using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualDeck
{
    public class Deck
    {
        public List<Card> Cards { get; set; }
        public string DeckName { get; set; }
        public Deck()
        {
            this.GetFullDeck();
        }
    }
    
}

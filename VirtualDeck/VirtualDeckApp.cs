using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VirtualDeck
{
    public class VirtualDeckApp
    {
        List<Deck> AllDecks = new List<Deck>();

        readonly char Club = '\u2663';
        readonly char Spade = '\u2660';
        readonly char Diamond = '\u2666';
        readonly char Heart = '\u2665';

        public void Start()
        {
            Menu();
        }
        
        
        public void Menu()
        {
            Console.Clear();
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine($"{Heart} {Diamond} DECK OF CARDS {Spade} {Club}\n\n");
            Console.WriteLine("1. New deck");
            Console.WriteLine("2. Choose deck");
            Console.WriteLine("\nAny key to quit...");

            var input = Console.ReadKey(true);
            switch (input.Key)
            {
                case ConsoleKey.D1:
                    Deck newDeck = new Deck();
                    DeckCreationForm(newDeck);
                    BackToMenuQuestion();
                    break;
                case ConsoleKey.D2:
                    Console.Clear();
                    if (AllDecks.Count > 0)
                    {
                        ShowDeckList();
                    }
                    else
                    {
                        Console.WriteLine("No decks available...");
                        BackToMenuQuestion();
                    }


                    break;

            }
        }

        private void ShowDeckList()
        {
            for (int i = 0; i < AllDecks.Count; i++)
            {
                Console.WriteLine(i + 1 + ": " + AllDecks[i].DeckName);
            }

            try
            {
                var input = int.Parse(Console.ReadLine());
                DeckChoices(AllDecks[input - 1]);
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine("Not a valid input!");
                ShowDeckList();
            }



        }
        /// <summary>
        /// Shows the menu with options for chosen deck
        /// </summary>
        /// <param name="deck"></param>
        private void DeckChoices(Deck deck)
        {

            Console.Clear();
            Console.WriteLine($"{Heart} {Diamond} {deck.DeckName} {Spade} {Club}");
            Console.WriteLine("1. Pull card");
            Console.WriteLine("2. Shuffle deck");
            var input = Console.ReadKey(true);
            switch (input.Key)
            {
                case ConsoleKey.D1:
                    PullingCard(deck, ConsoleKey.D1);
                    break;
                case ConsoleKey.D2:
                    deck.ShuffleDeck();
                    Console.WriteLine("Deck shuffled!");
                    PullingCard(deck, null);
                    break;



            }


        }

        private void PullingCard(Deck deck, ConsoleKey? pullCard)
        {
            ConsoleKey? choice = pullCard;
            while (true)
            {
                //Stops if all cards are pulled
                if (deck.Cards.Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You are out of cards!");
                    Console.ResetColor();
                    BackToMenuQuestion();
                    break;

                }

                if (choice.Equals(ConsoleKey.D1))
                {
                    CardDraw(deck);

                    //Asks for continuation
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("1(Pull again) 2(Shuffle) 3(Sort deck) or (any other key to stop)");
                    Console.ResetColor();
                }



                choice = Console.ReadKey(true).Key;
                if (choice == ConsoleKey.D1)
                {
                    continue;
                }
                else if (choice == ConsoleKey.D2)
                {
                    deck.ShuffleDeck();
                    Console.WriteLine("Deck shuffled!");

                }
                else if (choice == ConsoleKey.D3)
                {
                    deck.SortDeck();
                    Console.WriteLine("Deck Sorted");
                }
                else
                {
                    Console.WriteLine("You stopped");
                    BackToMenuQuestion();
                    break;

                }

            }
        }

        private void CardDraw(Deck deck)
        {
            //Pulls card and gets face card value if existing
            Card pulledCard = deck.PullCard();
            pulledCard.GetFaceCard();

            //Formating output with condition
            Console.WriteLine("You pulled " +
                (pulledCard.HasFaceCard() ?
                pulledCard.FaceCard + " of " + pulledCard.Name :
                pulledCard.Value + " of " + pulledCard.Name));
        }
        
        private void DeckCreationForm(Deck newDeck)
        {
            Console.Clear();
            Console.Write("Give your deck a name: ");
            newDeck.DeckName = Console.ReadLine();
            AllDecks.Add(newDeck);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"New deck created! ({newDeck.DeckName})");
            Console.ResetColor();

        }

        private void BackToMenuQuestion()
        {
            Console.Write("Press any key to go back to menu");
            Console.ReadKey(true);
            Menu();
        }
    }
}

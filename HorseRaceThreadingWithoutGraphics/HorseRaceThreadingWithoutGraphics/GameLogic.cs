using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseRaceThreadingWithoutGraphics
{
    class GameLogic
    {
        // creating the cards and deck
        public static string[] suits = new string[] { "C", "D", "H", "S" };
        public static string[] values = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "A", "K", "Q" };


        public List<string> deck;
        public List<string> discardPile = new List<string>();           // pile to save every drawn card to swap later with deckpile so we can start from begining. dont forget to shuffle again

        public void StartGame()
        {

            //Generate deck with all cards except Jacks
            deck = GenerateDeck();
            // shuffle that deck
            Shuffle(deck);
            // instantiate deckpile
            //DealCards();

            // instantiate jacks
            //DealHorses();

        }

        /// <summary>generate a complete new Deck based on suits and values in string array</summary>
        /// <returns></returns>
        public List<string> GenerateDeck()
        {
            List<string> newDeck = new List<string>();
            foreach (string s in suits)
            {
                foreach (string v in values)
                {
                    // string representing every card in a deck
                    newDeck.Add(s + v);
                }
            }
            return newDeck;
        }

        // FisherYates shuffle algorithm
        void Shuffle<T>(List<T> list)
        {
            System.Random random = new System.Random();
            int n = list.Count;
            while (n > 1)
            {
                int k = random.Next(n);
                n--;
                T temp = list[k];
                list[k] = list[n];
                list[n] = temp;
            }
        }
    }
}

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
        public static string[] suits = new string[] { "Club_", "Diamond_", "Heart_", "Spades_" };
        public static string[] values = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Ace", "King", "Queen" };

        public List<string> deck;
        public List<string> discardPile = new List<string>();           // pile to save every drawn card to swap later with deckpile so we can start from begining. dont forget to shuffle again

        public void StartGame()
        {
            Console.WriteLine("Gamelogic Started");
            //draw Table
            DrawTable();
            //Generate deck with all cards except Jacks
            deck = GenerateDeck();
            // shuffle that deck
            Shuffle(deck);


            // instantiate deckpile
            //DealCards();

            // instantiate jacks
            //DealHorses();

        }

        /// <summary>
        /// Draw Table with jacks and playcards
        /// </summary>
        void DrawTable()
        {
            Console.WriteLine("\n\nxxxxxxxxxxxxxxxxxxxxxx");
            Console.WriteLine("xx1x2x3x4x5x6x7x8x9xxx");
            Console.WriteLine("C__________________||x");
            Console.WriteLine("x                  ||x");
            Console.WriteLine("D__________________||x");
            Console.WriteLine("x                  ||x");
            Console.WriteLine("H__________________||x");
            Console.WriteLine("x                  ||x");
            Console.WriteLine("S__________________||discard");
            Console.WriteLine("x                  ||Deck");
            Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxx\n\n");

        }

        /// <summary>generate a complete new Deck based on suits and values in string array</summary>
        /// <returns></returns>
        public List<string> GenerateDeck()
        {
            Console.WriteLine("Generating Deck...");
            List<string> newDeck = new List<string>();
            foreach (string s in suits)
            {
                foreach (string v in values)
                {
                    // string representing every card in a deck
                    newDeck.Add(s + v);
                }
            }
            Console.WriteLine(String.Format("Deck generated. Deckcount = {0}", newDeck.Count));

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
            Console.WriteLine(String.Format("deck completly shuffled"));
            Console.WriteLine(String.Format("Random check: "));
            Console.WriteLine(String.Format("Card on {0} = {1} ",10, list[10]));

        }
    }
}

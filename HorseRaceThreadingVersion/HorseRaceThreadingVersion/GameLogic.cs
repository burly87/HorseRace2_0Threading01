using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HorseRaceThreadingVersion
{
    class GameLogic
    {
        // creating the cards and deck
        public static string[] suits = new string[] { "C", "D", "H", "S" };
        public static string[] values = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "A", "K", "Q" };


        //public List<string> deck;
        public List<Card> deck1;
        public List<string> discardPile = new List<string>();           // pile to save every drawn card to swap later with deckpile so we can start from begining. dont forget to shuffle again

        Form1 form1;

        public void StartGame()
        {
            form1 = new Form1();

            //Generate deck with all cards except Jacks
            //deck1 = GenerateDeck();
            // give every card the correct Image

            // shuffle that deck
            //Shuffle(deck1);
            // instantiate deckpile
            //DealCards();
            // instantiate jacks
            //DealHorses();

            MessageBox.Show("Count of deck1:" + deck1.Count + "\nName of rnd element: " );
        }

        /// <summary>generate a complete new Deck based on suits and values in string array</summary>
        /// <returns></returns>
        //public List<string> GenerateDeck()
        //{            
        //    List<string> newDeck = new List<string>();
        //    foreach (string s in suits)
        //    {
        //        foreach (string v in values)
        //        {
        //            // string representing every card in a deck
        //            newDeck.Add(s + v);
        //        }
        //    }
        //    return newDeck;
        //}
        public List<Card> GenerateDeck()
        {
            int i = 0;
            List<Card> newDeck = new List<Card>();
            foreach (string s in suits)
            {
                foreach (string v in values)
                {
                    //Card tmp = new Card(v, s, form1.imageList1.Images[i]);
                    //newDeck.Add(tmp);
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

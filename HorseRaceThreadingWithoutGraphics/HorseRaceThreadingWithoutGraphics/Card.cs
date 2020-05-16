using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseRaceThreadingWithoutGraphics
{
    class Card
    {
        private string face;
        private string suit;

        public Card(string cardFace, string cardSuit)
        {
            this.face = cardFace;
            this.suit = cardSuit;
        }

        public override string ToString()
        {
            return face + " of " + suit;
        }
    }
}

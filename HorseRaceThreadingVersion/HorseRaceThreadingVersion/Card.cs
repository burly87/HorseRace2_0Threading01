using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseRaceThreadingVersion
{
    class Card
    {
        private string face;
        private string suit;
        private Image image;

        public Card(string cardFace, string cardSuit, Image cardImage)
        {
            this.face = cardFace;
            this.suit = cardSuit;
            this.image = cardImage;
        }

        public override string ToString()
        {
            return face + " of " + suit;
        }
    }
}

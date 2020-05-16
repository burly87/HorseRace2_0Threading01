using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseRaceThreadingVersion
{
    class UpdateSprite
    {
        private GameLogic gameLogic;

        public void StartUpdateSprite()
        {
            //generate perfect sorted deck to populate deck with cardFaceSprite
            gameLogic = new GameLogic();
            List<Card> deck = gameLogic.GenerateDeck();

            int i = 0;
            foreach (Card card in deck)
            {
                //if(this.)
            }
        }

    }
}

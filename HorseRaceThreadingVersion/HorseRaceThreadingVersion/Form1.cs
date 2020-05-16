using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HorseRaceThreadingVersion
{
    public partial class Form1 : Form
    {
        // --- Drawing the Table ----

        // all cards related
        private int cardWidth = 80;                         // card size x
        private int cardHeight = 117;                       // card size y
        private int offsetY = 15;                           // space between cards
        private string pathToSprites = (@"D:\Workspace\Sligo\AdvancedProgramming\WPF_HorseRace\HorseRaceThreadingVersion\HorseRaceThreadingVersion\Sprites\");
        
        // HorseCards
        private Bitmap horse1, horse2,horse3,horse4;                // jacks / horses cardSprites        
        private int horse1_X = 15;                                  // have to store the position of all horses in own variables
        private int horse1_Y = 147;
        private int horse2_X = 15;
        private int horse2_Y = 264;
        private int horse3_X = 15;
        private int horse3_Y = 381;
        private int horse4_X = 15;
        private int horse4_Y = 498;

        // Trackcards
        private Bitmap trackCard1, trackCard2, trackCard3, trackCard4, trackCard5, trackCard6, trackCard7, trackCard8, trackCard9;
        private int trackCard_Y = 15;
        private int trackCard1_X = 110;
        private int trackCard2_X = 205;
        private int trackCard3_X = 300;
        private int trackCard4_X = 395;
        private int trackCard5_X = 490;
        private int trackCard6_X = 585;
        private int trackCard7_X = 680;
        private int trackCard8_X = 775;
        private int trackCard9_X = 870;

        // Deckcards
        private Bitmap discardPile;
        private Bitmap deckPile;
        private int deckPile_X = 1060;

        // Finishline
        private Bitmap finishLine;

        // --------  ----------
        GameLogic gameLogic;

        public Form1()
        {
            InitializeComponent();
            // Draw Table
            // horses
            horse1 = new Bitmap(pathToSprites + "Cards\\Horses\\jack_of_clubs2.png");
            horse2 = new Bitmap(pathToSprites + "Cards\\Horses\\jack_of_diamonds2.png");
            horse3 = new Bitmap(pathToSprites + "Cards\\Horses\\jack_of_hearts2.png");
            horse4 = new Bitmap(pathToSprites + "Cards\\Horses\\jack_of_spades2.png");
            // trackgards later populated with real cards. now just placeholders
            trackCard1 = new Bitmap(pathToSprites + "Cards\\CardBack00.png");
            trackCard2 = new Bitmap(pathToSprites + "Cards\\CardBack00.png");
            trackCard3 = new Bitmap(pathToSprites + "Cards\\CardBack00.png");
            trackCard4 = new Bitmap(pathToSprites + "Cards\\CardBack00.png");
            trackCard5 = new Bitmap(pathToSprites + "Cards\\CardBack00.png");
            trackCard6 = new Bitmap(pathToSprites + "Cards\\CardBack00.png");
            trackCard7 = new Bitmap(pathToSprites + "Cards\\CardBack00.png");
            trackCard8 = new Bitmap(pathToSprites + "Cards\\CardBack00.png");
            trackCard9 = new Bitmap(pathToSprites + "Cards\\CardBack00.png");
            // deckpile
            deckPile = new Bitmap(pathToSprites + "Cards\\CardBack00.png");
            discardPile = new Bitmap(pathToSprites + "Cards\\emptypos.png");
            // finishlne
            finishLine = new Bitmap(pathToSprites + "FinishLine.png");

            // Create Deck
            //gameLogic = new GameLogic();
            //gameLogic.StartGame();
            
            //MessageBox.Show("COunt of images in imageList: " + cardImageList.Images.Count);

            // Shuffle Deck

            // Deal Cards

            
        }
        
        private void DrawTable()
        {
            
            

        }

        private void DrawHorses(object sender, PaintEventArgs e)
        {
            // horses
            horse1 = new Bitmap(pathToSprites + "Cards\\Horses\\jack_of_clubs2.png");
            horse2 = new Bitmap(pathToSprites + "Cards\\Horses\\jack_of_diamonds2.png");
            horse3 = new Bitmap(pathToSprites + "Cards\\Horses\\jack_of_hearts2.png");
            horse4 = new Bitmap(pathToSprites + "Cards\\Horses\\jack_of_spades2.png");
            // trackgards later populated with real cards. now just placeholders
            trackCard1 = new Bitmap(pathToSprites + "Cards\\CardBack00.png");
            trackCard2 = new Bitmap(pathToSprites + "Cards\\CardBack00.png");
            trackCard3 = new Bitmap(pathToSprites + "Cards\\CardBack00.png");
            trackCard4 = new Bitmap(pathToSprites + "Cards\\CardBack00.png");
            trackCard5 = new Bitmap(pathToSprites + "Cards\\CardBack00.png");
            trackCard6 = new Bitmap(pathToSprites + "Cards\\CardBack00.png");
            trackCard7 = new Bitmap(pathToSprites + "Cards\\CardBack00.png");
            trackCard8 = new Bitmap(pathToSprites + "Cards\\CardBack00.png");
            trackCard9 = new Bitmap(pathToSprites + "Cards\\CardBack00.png");
            // deckpile
            deckPile = new Bitmap(pathToSprites + "Cards\\CardBack00.png");
            discardPile = new Bitmap(pathToSprites + "Cards\\emptypos.png");
            // finishlne
            finishLine = new Bitmap(pathToSprites + "FinishLine.png");

            //draw horses
            e.Graphics.DrawImage(horse1, horse1_X, horse1_Y, cardWidth, cardHeight);
            e.Graphics.DrawImage(horse2, horse2_X, horse2_Y + offsetY, cardWidth, cardHeight);
            e.Graphics.DrawImage(horse3, horse3_X, horse3_Y + offsetY*2, cardWidth, cardHeight);
            e.Graphics.DrawImage(horse4, horse4_X, horse4_Y + offsetY*3, cardWidth, cardHeight);

            //draw trackCard
            e.Graphics.DrawImage(trackCard1, trackCard1_X, trackCard_Y, cardWidth, cardHeight);
            e.Graphics.DrawImage(trackCard2, trackCard2_X, trackCard_Y, cardWidth, cardHeight);
            e.Graphics.DrawImage(trackCard3, trackCard3_X, trackCard_Y, cardWidth, cardHeight);
            e.Graphics.DrawImage(trackCard4, trackCard4_X, trackCard_Y, cardWidth, cardHeight);
            e.Graphics.DrawImage(trackCard5, trackCard5_X, trackCard_Y, cardWidth, cardHeight);
            e.Graphics.DrawImage(trackCard6, trackCard6_X, trackCard_Y, cardWidth, cardHeight);
            e.Graphics.DrawImage(trackCard7, trackCard7_X, trackCard_Y, cardWidth, cardHeight);
            e.Graphics.DrawImage(trackCard8, trackCard8_X, trackCard_Y, cardWidth, cardHeight);
            e.Graphics.DrawImage(trackCard9, trackCard9_X, trackCard_Y, cardWidth, cardHeight);

            //draw deckPile and discardPile
            e.Graphics.DrawImage(discardPile, deckPile_X, horse3_Y + offsetY * 2, cardWidth, cardHeight);
            e.Graphics.DrawImage(deckPile, deckPile_X, horse4_Y + offsetY * 3, cardWidth, cardHeight);

            // draw finishline
            e.Graphics.DrawImage(finishLine, deckPile_X - 95, 0, cardWidth, (cardHeight*5)+90);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

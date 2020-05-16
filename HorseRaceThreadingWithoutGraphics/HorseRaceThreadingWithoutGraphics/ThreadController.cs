using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseRaceThreadingWithoutGraphics
{
    class ThreadController
    {
        static GameLogic gameLogic;


        static void Main(string[] args)
        {
            gameLogic = new GameLogic();
            gameLogic.StartGame();



            Console.ReadLine();
        }
    }
}

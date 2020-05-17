using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThreadingProject
{
    class FormsUpdater : ICallBackBW //implements the CallBackBW Interface for the WaitBW
    {

        private int time;
        private Form1 mainClass;

        public FormsUpdater(Form1 mainClass)
        {
            this.mainClass = mainClass;
        }

        public void Reset()
        {
            time = 0;
        }

        public void Aborted()
        {
            mainClass.SetTotalTimeLabel("Aborted");
            mainClass.BlockControls(false);
        }

        public void Error()
        {
            mainClass.SetTotalTimeLabel("Error!");
            mainClass.BlockControls(false);
        }

        
        public void Finished()
        {
            mainClass.SetTotalTimeLabel("Done! It took " + time +" ms.");
            mainClass.WriteToIso(time);
            mainClass.BlockControls(false);
        }

        public void UpdateGlobal()
        {
            time = time + 10;
            mainClass.SetTotalTimeLabel("Combined time elasped: " + time + " ms.");
        }
    }
}

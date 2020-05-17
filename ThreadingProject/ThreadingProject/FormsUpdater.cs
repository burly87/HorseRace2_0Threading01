using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThreadingProject
{
    class FormsUpdater : CallBackBW //implements the CallBackBW for my WaitBW
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
            mainClass.setTotalTimeLabel("Aborted");
            mainClass.blockControls(false);
        }

        public void Error()
        {
            mainClass.setTotalTimeLabel("Error!");
            mainClass.blockControls(false);
        }

        public void Finished()
        {
            mainClass.setTotalTimeLabel("Done! It took " + time +" ms.");
            mainClass.blockControls(false);
        }

        public void UpdateGlobal()
        {
            time = time + 10;
            mainClass.setTotalTimeLabel("Combined time elasped: " + time + " ms.");
        }
    }
}

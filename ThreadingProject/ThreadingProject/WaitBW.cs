using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThreadingProject
{
    class WaitBW //uses BackgroundWorker
    {
        private Object baton = new Object();
        private ProgressBar progressBar;
        private Label label;
        private int time;               // time to run BW
        private int timeElapsed;
        private BackgroundWorker bw;
        private float percentComplete;
        private CallBackBW callBackBW;


        public WaitBW(ProgressBar pb, Label label, CallBackBW callBackBW)
        {
            progressBar = pb;
            this.label = label;
            this.callBackBW = callBackBW;
            

            bw = new BackgroundWorker(); //not Started yet
            bw.DoWork += new DoWorkEventHandler(DoWork);

            bw.WorkerReportsProgress = true;
            bw.WorkerSupportsCancellation = true;


            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(runWorkerCompleted);
            bw.ProgressChanged += new ProgressChangedEventHandler(progessChanged);
        }

        /// <summary>
        /// Start BackgroundWorker
        /// </summary>
        /// <param name="time"></param>
        public void StartWorker(int time) 
        {
            this.time = time;
            if (bw.IsBusy != true)
            {
                bw.RunWorkerAsync();
            }
        }

        /// <summary>
        /// Cancle running Thread
        /// </summary>
        public void InterruptWorker() 
        {
            bw.CancelAsync(); 
        }

        /// <summary>
        /// Starts when the BW has started running
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoWork(object sender, DoWorkEventArgs e) 
        {

            for (int i = 10; i <= time; i = i+10)
            {
                timeElapsed = i;

                percentComplete = ((float)i / (float)time) * 100;

                // report the % completed
                bw.ReportProgress(int.Parse(Math.Round(percentComplete).ToString())); 

                Thread.Sleep(10); // Not Running and Sleeping for 10 ms

                //set CancellationPending to ensure its possible to abort or interrupt the bw
                if (bw.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
            }
        }

        /// <summary>
        /// raised when bw completed his work
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void runWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // handle error
            if (e.Error != null)
            {
                callBackBW.Error();
            }
            else if (e.Cancelled) 
            {
                callBackBW.Aborted();
            }
            // finished normal
            else
            {
                callBackBW.Finished();
                this.progressBar.Value = 100;
            }
        }

        /// <summary>
        /// update progressBar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void progessChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar.Value = e.ProgressPercentage;
            this.label.Text = (Math.Round((timeElapsed/(float)1000),1).ToString());
            updateGlobalProgress();
        }

        private void updateGlobalProgress()
        {
            lock (baton) //Lock the Code so only one Thread at the time can access it. Resource Sharing / Blocking
            {
                callBackBW.UpdateGlobal();
            }
        }
    }
}

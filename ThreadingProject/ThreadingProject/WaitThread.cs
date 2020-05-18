using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThreadingProject
{
    public class ThreadEventArgs : EventArgs
    {
        //Status 1 = finished ; Status 2 = aborted ; Status 3 = error
        public int status; 

        public ThreadEventArgs(int status)
        {
            this.status = status;
        }
    }

    //using Threads 
    class WaitThread 
    {
        private Thread mainThread;

        //[ThreadStatic]
        private int time;
        private int threadCount;
        private bool abort;

        public event EventHandler<ThreadEventArgs> threadCallBack;

        public WaitThread(Form1 form)
        {
            this.threadCallBack += form.onThreadEvent;
        }

        /// <summary>
        /// set Time to run and count of threads
        /// </summary>
        public void SetTime(int time, int threadCount)
        {
            this.threadCount = threadCount;
            this.time = time;
        }

        /// <summary>
        /// Create thread which runs DoWork()
        /// </summary>
        public void Start()
        {
            abort = false;
            mainThread = new Thread(DoWork);
            mainThread.Name = "MainThread";
            mainThread.Start();
        }

        protected virtual void OnThreadEvent(int status)
        {
            threadCallBack(this, new ThreadEventArgs(status)); // Raise Event
        }

        /// <summary>
        /// Interrupt 
        /// </summary>
        public void Abort() 
        {
            abort = true;
        }

        private void DoWork()
        {
            //create a waitHandle Array to sync threads.
            WaitHandle[] waitHandles = new WaitHandle[threadCount];
            
                for (int i = 0; i < threadCount; i++)
                {
                    var handle = new EventWaitHandle(false, EventResetMode.ManualReset);
                
                    //Creating threads
                    var thread = new Thread(() => 
                    {
                        int tmpTime = time / threadCount;

                        while(tmpTime > 0)
                        {
                            if (abort)
                            {
                                break;
                            }
                            Thread.Sleep(1000);
                            tmpTime = tmpTime-1000;
                        }
                        handle.Set();
                    });
                    waitHandles[i] = handle;
                    thread.Start();
                }
                       

            //wait for all threads to finish and blocks Main-WorkerThread till that moment
            WaitHandle.WaitAll(waitHandles); 
            if (abort != true)
            {
                OnThreadEvent(1);
            }
            else if (abort == true)
            {
                OnThreadEvent(2);
            }
            else
            {
                OnThreadEvent(3);
            }
        }

    }
}

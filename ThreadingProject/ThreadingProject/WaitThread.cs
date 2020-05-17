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
        /// Create thread which runs DoWork(). Index decide which action to run. 1 is Threads, 2 ThreadsQueue , 3 BackgroundWorker
        /// </summary>
        public void Start(int i)
        {
            abort = false;
            mainThread = new Thread(new ParameterizedThreadStart(DoWork));
            mainThread.Name = "MainThread";
            mainThread.Start(i);
        }

        protected virtual void OnThreadEvent(int status)
        {
            threadCallBack(this, new ThreadEventArgs(status)); // Raise Event
        }

        /// <summary>
        /// Interrupt called by button startStop_click
        /// </summary>
        public void Abort() 
        {
            abort = true;
        }

        private void DoWork(object index)
        {
            //create a waitHandle Array to sync threads.
            WaitHandle[] waitHandles = new WaitHandle[threadCount];
            
            // index == 1 means synced Threads
            if((int)index == 1)
            {
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
            }
            // index == 2 means thread Queue
            else if((int)index == 2)
            {
                for (int i = 0; i < threadCount; i++)
                {
                    var handle = new EventWaitHandle(false, EventResetMode.ManualReset);
                    bool hasFinised = false;

                    //Creating threads
                    var thread = new Thread(() =>
                    {
                        int tmpTime = time / threadCount;
                        while (tmpTime > 0)
                        {
                            if (abort)
                            {
                                break;
                            }
                            Thread.Sleep(1000);
                            tmpTime = tmpTime - 1000;                            
                        }

                        hasFinised = true;

                        if (hasFinised)
                        {
                            handle.Set();
                            // handle.WaitOne();
                        }
                    });                   
                  

                    waitHandles[i] = handle;
                    thread.Start();
                }
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

        //Block to wait till Worker Thread is done
        //public void Join() 
        //{
        //   MessageBox.Show("Join used");
        //   mainWorker.Join(); 
        //}
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingProject
{
    public class ThreadEventArgs : EventArgs
    {
        public int status; //Status 1 = finished / Status 2 = aborted / Status 3 = error

        public ThreadEventArgs(int status)
        {
            this.status = status;
        }
    }

    class WaitThread //Uses Threads
    {
        Thread mainWorker;
        int time;
        int threadCount;
        bool abort;

        public event EventHandler<ThreadEventArgs> threadCallBack;

        public WaitThread(Form1 form)
        {
            this.threadCallBack += form.onThreadEvent;
        }

        public void setTime(int time, int threadCount)
        {
            this.threadCount = threadCount;
            this.time = time;
        }

        public void start()
        {
            abort = false;
            mainWorker = new Thread(DoWork); // new Thread for the Work to have Responsiveness
            mainWorker.Start();
        }

        protected virtual void onThreadEvent(int status)
        {
            threadCallBack(this, new ThreadEventArgs(status)); // Raise Event
        }

        public void Abort() //Use Boolean for Graceful Interrupt
        {
            abort = true;
        }

        private void DoWork()
        {
            WaitHandle[] waitHandles = new WaitHandle[threadCount]; //create a waitHandle Array to sync threads.
            for (int i = 0; i < threadCount; i++)
            {
                var handle = new EventWaitHandle(false, EventResetMode.ManualReset);
                var thread = new Thread(() => //Creating threads for doing the work as the user selected
                {
                    int tempTime = time / threadCount;

                    while(tempTime > 0)
                    {
                        if (abort)
                        {
                            break;
                        }
                        Thread.Sleep(1000);
                        tempTime = tempTime-1000;
                    }
                    handle.Set();
                });
                waitHandles[i] = handle;
                thread.Start();
            }
            WaitHandle.WaitAll(waitHandles); //wait for all threads to finish / Block Main-WorkerThread till done!
            if (abort != true)
            {
                onThreadEvent(1);
            }
            else if (abort == true)
            {
                onThreadEvent(2);
            }
            else
            {
                onThreadEvent(3);
            }
        }

        public void Join() //Block to wait till Worker Thread is done
        {
           mainWorker.Join(); 
        }
    }
}

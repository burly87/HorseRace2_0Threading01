using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.IsolatedStorage;
using System.Windows.Forms;       //to use messageBox.Show etc.
using System.Threading;

namespace ThreadingProject
{
    class IsoStorageHandler
    {
        public static Object syncObj = new Object();

        // create Iso
        private IsolatedStorageFile store;

        // folder
        private string folderName;

        // iso text file = need a path to the text file
        private string pathToTextFile;

        public IsoStorageHandler()
        {
            //set name of folder and path to save Isolated Storage file
            folderName = "ThreadResults";
            pathToTextFile = String.Format("{0}\\results.txt", folderName);
            // set store to user and assembly
            store = IsolatedStorageFile.GetUserStoreForAssembly();
        }

        // method writes to Iso
        public void WriteToStorage(Object result)
        {
            if (store == null) return;
            // need to sync the method because different threads will have access to it
            Monitor.Enter(syncObj);
            {
                try
                {
                    //check if folder allready exists. if not create it
                    if (!store.DirectoryExists(folderName))
                        store.CreateDirectory(folderName);
                                       
                    using (IsolatedStorageFileStream isoStream = store.OpenFile(pathToTextFile, FileMode.OpenOrCreate, FileAccess.Write))
                    {
                        using (StreamWriter writer = new StreamWriter(isoStream))
                        {
                            writer.Write(String.Format("Combined time backgroundworkers worked = {0} ms.", result.ToString()));
                            MessageBox.Show("Time the Backgroundworkers worked saved in result.txt");
                        }
                    }

                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
                finally
                {
                    Monitor.Pulse(syncObj);
                    Monitor.Exit(syncObj);
                }
            }
        }
    }
}

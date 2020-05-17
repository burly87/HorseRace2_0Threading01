using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadingProject
{
    //Interface for using WaitBW
    interface CallBackBW 
    {
        void Error();
        void Finished();
        void Aborted();
        void UpdateGlobal();
    }
}

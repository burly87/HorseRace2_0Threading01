using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadingProject
{
    //Interface for using WaitBW
    interface ICallBackBW 
    {
        // if Error occured
        void Error();
        // when completly finished
        void Finished();
        // if canceled
        void Aborted();
        // update text while running 
        void UpdateGlobal();
    }
}

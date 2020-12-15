using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace FileWatcher_lab3
{
    static class Program
    {
        
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new My_lovely_laba()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}

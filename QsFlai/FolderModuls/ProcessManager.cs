using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QsFlai.FolderModuls
{
    public class ProcessManager
    {
        ProcessStartInfo procStartInfo;
        Process proc;

        public ProcessManager(string fileName)
        {
            procStartInfo = new ProcessStartInfo("explorer", fileName);
            proc = new Process();
            proc.StartInfo = procStartInfo;
        }

        public void StartProcess()
        {
            proc.Start();
        }
    }
}

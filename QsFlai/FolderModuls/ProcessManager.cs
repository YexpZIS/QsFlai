using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QsFlai.FolderModuls
{
    public class ProcessManager
    {
        ProcessStartInfo procStartInfo;
        Process proc;

        bool isExists = true;

        public ProcessManager(string fileName)
        {
            try
            {
                procStartInfo = new ProcessStartInfo("explorer", fileName);
                proc = new Process();
                proc.StartInfo = procStartInfo;
            }
            catch { isExists = false; }
        }

        public void StartProcess()
        {
            if (isExists) 
            {
                proc.Start();
            }
            else
            {
                MessageBox.Show("Файла не существует.","Ошибка");
            }
        }
    }
}

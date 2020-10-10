using QsFlai.FolderModuls;
using QsFlai.Preferences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using sys = System.IO;

namespace QsFlai.UserControls
{
    /// <summary>
    /// Логика взаимодействия для Folder.xaml
    /// </summary>
    public partial class Folder : UserControl
    {
        private ProcessManager process;
        public Folder(File file)
        {
            InitializeComponent();

            process = new ProcessManager(file.Link);

            var img = new ImageLoader(ref logo);
            img.LoadImage(file.Image);

            name.Content = String.IsNullOrEmpty(file.Name) ? getFileName(file.Link) : file.Name;
        }

        private string getFileName(string path)// Вынести в отдельный модуль
        {
            return new sys.FileInfo(path).Name;
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Open file
            process.StartProcess();
        }
    }
}

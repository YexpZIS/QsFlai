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
        private VirtualFolder virtualFolder;
        private File file;
        private ProcessManager process;
        private FilesSettings settings;

        public Folder(VirtualFolder virtualFolder, FilesSettings settings,File file)
        {
            InitializeComponent();

            process = new ProcessManager(file.Link);
            this.settings = settings;
            this.file = file;
            this.virtualFolder = virtualFolder;

            setDefaultSettings();
            loadImg();
        }
        private void loadImg()
        {
            var img = new ImageLoader(ref logo);

            var path = "";

            if (file.Image != "" && file.Image != null)
            {
                path = file.Image;

                try
                {
                    img.LoadImage(path);
                }
                catch { }
            }
            else
            {
                var uri = new Uri(file.Link);

                if (uri.IsFile)
                {
                    try
                    {
                        img.LoadIcon(file.Link);
                    }
                    catch { }
                }
                else
                {
                    return;
                }
            }
            
        }

        private void setDefaultSettings()
        {
            name.Text = String.IsNullOrEmpty(file.Name) ? getFileName(file.Link) : file.Name;

            border.Background = new SolidColorBrush(settings.BackgroundColor);
            border.BorderBrush = new SolidColorBrush(settings.BorderColor);
            border.BorderThickness = settings.BorderSize;

            name.Foreground = new SolidColorBrush(settings.TextColor);
            name.FontFamily = settings.FontFamily;
            name.FontSize = settings.FontSize;

            grid.Width = settings.Size.Width;
            grid.Height = settings.Size.Height;
            grid.Margin = settings.Margin;

            block.Height = new GridLength(settings.blockHeight);
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

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            virtualFolder.removeFile(file.id, this);
        }
    }
}

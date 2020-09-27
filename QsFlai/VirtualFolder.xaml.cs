using QsFlai.Animations.WindowSize;
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
using System.Windows.Shapes;

namespace QsFlai
{
    /// <summary>
    /// Логика взаимодействия для VirtualFolder.xaml
    /// </summary>
    public partial class VirtualFolder : Window
    {
        private BackgroundPiner backgroundPiner;
        private Gap settings;
        private WindowManager windowManager;
        private readonly int id;

        private Grid grid;

        public VirtualFolder(int id)
        {
            InitializeComponent();

            this.grid = MainGrid;
            this.id = id;

            settings = MainWindow.settings.gaps[id];
            //setDefautlGridSize();
            backgroundPiner = new BackgroundPiner(this);

            windowManager = new WindowManager(grid, settings);
        }
        private void setDefautlGridSize()
        {
            grid.Height = settings.Scale.Initial.Height;
            grid.Width = settings.Scale.Initial.Width;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            backgroundPiner.HideFromAltTab();
        }
        private void Window_Activated(object sender, EventArgs e)
        {
            backgroundPiner.ShoveToBackground();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }

        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            windowManager.resizeWindowToMaximumSize();
        }

        private void Grid_MouseLeave(object sender, MouseEventArgs e)
        {
            windowManager.resizeWindowToMinimumSize();
        }
    }
}

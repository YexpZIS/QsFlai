using QsFlai.Animations.GridSize;
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
        private GridSizeChanger gridSize;
        
        private readonly int id;

        private Grid grid;

        public VirtualFolder(int id)
        {
            InitializeComponent();

            this.id = id;
            this.grid = MainGrid;

            settings = MainWindow.settings.gaps[id];

            backgroundPiner = new BackgroundPiner(this);

            gridSize = new GridSizeChanger(grid, settings);
            gridSize.sizeChanged += Size_Changed;
        }
        private void Size_Changed()
        {
            if (grid.IsMouseOver)
            {
                gridSize.setSize(GridState.Max);
            }
            else
            {
                gridSize.setSize(GridState.Min);
            }
        }
        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            gridSize.setSize(GridState.Max);
        }
        private void Grid_MouseLeave(object sender, MouseEventArgs e)
        {
            gridSize.setSize(GridState.Min);
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            backgroundPiner.HideFromAltTab();
        }
        private void Window_Activated(object sender, EventArgs e)
        {
            backgroundPiner.ShoveToBackground();
        }
    }
}

using Microsoft.Win32;
using QsFlai.Animations.Colors;
using QsFlai.Animations.GridSize;
using QsFlai.Preferences;
using QsFlai.VirtualFolderModuls;
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
using State = QsFlai.Animations.GridSize;

namespace QsFlai
{
    /// <summary>
    /// Логика взаимодействия для VirtualFolder.xaml
    /// </summary>
    public partial class VirtualFolder : Window
    {
        private readonly int id;

        private Gap settings;
        private Grid grid;

        private AnimationGridController animations;

        public VirtualFolder(int id)
        {
            InitializeComponent();

            this.id = id;
            this.grid = MainGrid;

            settings = MainWindow.settings.gaps.Where(x=>x.id == id).First();

            setupWindowNameElement();
            setDefaultSettings();
            addMoveEvent();

            var backgroundPiner = new BackgroundPiner(this);
            animations = new AnimationGridController(settings, MainGrid, folderPlace, windowName.edit);
        }
        private void setDefaultSettings()
        {
            var objects = new СustomizableObjects(this, grid, ref image, FolderPanel, windowName,  windowName.border, topBorderHeight);
            var setter = new SettingsSetter(settings, objects);
        }
        private void addMoveEvent()
        {
            var move = new MovingWindow(ref settings, this, windowName);
        }
        private void setupWindowNameElement()
        {
            windowName.Constructor(settings, this, id);
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var size = e.NewSize;
            if (settings.Scale.Final != size) {
                animations.changeSize(size);
                setWindowSize(size);
            }
        }
        private void setWindowSize(Size size)
        {
            this.Width = size.Width;
            this.Height = size.Height;

            MainGrid.Width = size.Width;
            MainGrid.Height = size.Height;

            settings.Scale.Final = size;

            MainWindow.Save();
        }

    }
}

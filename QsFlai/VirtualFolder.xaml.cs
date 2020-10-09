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


        public VirtualFolder(int id)
        {
            InitializeComponent();

            this.id = id;
            this.grid = MainGrid;

            settings = MainWindow.settings.gaps[id];

            setupWindowNameElement();
            setDefaultSettings();
            addMoveEvent();

            var backgroundPiner = new BackgroundPiner(this);
            var animations = new AnimationGridController(settings, MainGrid, folderPlace, windowName.edit);
        }
        private void setDefaultSettings()
        {
            var objects = new СustomizableObjects(this, grid, ref image, FolderPanel, windowName,  windowName.border);
            var setter = new SettingsSetter(settings, objects);
        }
        private void addMoveEvent()
        {
            var move = new MovingWindow(ref settings, this, windowName);
        }
        private void setupWindowNameElement()
        {
            windowName.Constructor(this, id);
        }

        /*private void close_Click(object sender, RoutedEventArgs e)
        {
            var result =MessageBox.Show("Удалить данное окно?\n\nНет - закрыть окно.\nДа - удалить окно.\nОтмена - не закрывать окно.",
                "Предупреждение", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                // Удаяем окно
                MainWindow.removeWindow(id);
                this.Close();
            }
            else if (result == MessageBoxResult.No) 
            {
                // Скрываем окно
                this.Close();
            }
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.addNewWindow();
        }
        */
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //setWindowSize(e.NewSize);
        }
    }
}

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
        private GridSizeChanger gridSize;
        private ColorChanger editMode;

        private Grid grid;

        private Size InitialScale;

        public VirtualFolder(int id)
        {
            InitializeComponent();

            this.id = id;
            this.grid = MainGrid;

            settings = MainWindow.settings.gaps[id];

            setDefaultSettings();

            addMoveEvent();

            var backgroundPiner = new BackgroundPiner(this);

            gridSize = new GridSizeChanger(grid,ref settings);
            gridSize.sizeChanged += Size_Changed;


            editMode = new ColorChanger(settings, settings.editMode);
            grid.Background = editMode.GetBrush();
        }
        private void setDefaultSettings()
        {
            var objects = new СustomizableObjects(this, grid, FolderPanel, windowName, windowTextEdit);
            var setter = new SettingsSetter(settings, objects);
            InitialScale = settings.Scale.Initial;
        }
        private void addMoveEvent()
        {
            var move = new MovingWindow(ref settings, this, windowTextEdit);
        }


        /// <summary>
        /// Когда курсор находится внутри Grid, то окно 
        /// увеличивается в размере до settings.Scale.Final
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            gridSize.setSize(GridState.Max);
        }
        /// <summary>
        /// Когда курсор выходит из области Grid, то окно
        /// уменьшается в размерах до settings.Scale.Initial
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Grid_MouseLeave(object sender, MouseEventArgs e)
        {
            gridSize.setSize(GridState.Min);
        }
        /// <summary>
        /// Если после того, как закончиласть анимация 
        /// увеличения Grid курсор не находится в Grid,
        /// то окно сворачивается
        /// </summary>
        private void Size_Changed()
        {
            if (grid.IsMouseOver || isEditable())
            {
                gridSize.setSize(GridState.Max);
            }
            else
            {
                gridSize.setSize(GridState.Min);
            }
        }



        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //setWindowSize(e.NewSize);
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            if (isEditable()) 
            {
                editMode.Stop(); // Останавливает анимацию. Выход из режима редактирования
                settings.Scale.Initial = InitialScale;
                Size_Changed();
            }
            else
            {
                settings.Scale.Initial = settings.Scale.Final; // Делаем окно однго размера. Указываем одинаковые размеры для начального и конечного размера окон.
                gridSize.setSize(GridState.Max);
                editMode.Begin(); // Запускает анимацию. Информирование пользователя о том, что окно находиться в режиме редактирования
            }
        }
        private bool isEditable()
        {
            return settings.Scale.Initial != InitialScale;
        }

        private void close_Click(object sender, RoutedEventArgs e)
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

    }
}

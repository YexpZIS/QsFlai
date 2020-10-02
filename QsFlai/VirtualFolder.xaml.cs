using QsFlai.Animations.GridSize;
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
        private SettingsSetter setter;
        private GridSizeChanger gridSize;
        
        private Grid grid;

        private State.WindowState state = State.WindowState.Normal;

        public VirtualFolder(int id)
        {
            InitializeComponent();

            this.id = id;
            this.grid = MainGrid;

            settings = MainWindow.settings.gaps[id];
            var objects = new СustomizableObjects(this,FolderPanel,windowName, windowTextEdit);
            setter = new SettingsSetter(settings, objects);

            var backgroundPiner = new BackgroundPiner(this);

            gridSize = new GridSizeChanger(grid, settings);
            gridSize.sizeChanged += Size_Changed;
        }
        

        /// <summary>
        /// Когда курсор находится внутри Grid, то окно 
        /// увеличивается в размере до settings.Scale.Final
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            gridChangeSize(GridState.Max);
        }
        /// <summary>
        /// Когда курсор выходит из области Grid, то окно
        /// уменьшается в размерах до settings.Scale.Initial
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Grid_MouseLeave(object sender, MouseEventArgs e)
        {
            gridChangeSize(GridState.Min);
        }
        /// <summary>
        /// Если после того, как закончиласть анимация 
        /// увеличения Grid курсор не находится в Grid,
        /// то окно сворачивается
        /// </summary>
        private void Size_Changed()
        {
            if (grid.IsMouseOver)
            {
                gridChangeSize(GridState.Max);
            }
            else
            {
                gridChangeSize(GridState.Min);
            }

            if (state == State.WindowState.Edit)
            {
                gridSize.setSize(GridState.Max);
            }
        }
        /// <summary>
        /// Изменяем размер если окно не находится в режиме редактирования
        /// </summary>
        /// <param name="GState"></param>
        private void gridChangeSize(GridState GState)
        {
            if (state == State.WindowState.Normal) 
            {
                gridSize.setSize(GState);
            }
        }



        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //setWindowSize(e.NewSize);
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            if (state == State.WindowState.Normal) 
            {
                state = State.WindowState.Edit;
                gridSize.setSize(GridState.Max);
                // Start red animation + add comments ^ and refractor
            }
            else
            {
                state = State.WindowState.Normal;
                Size_Changed();
            }
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            var result =MessageBox.Show("Удалить данное окно?\n\nНет - закрыть окно.\nДа - удалить окно.\nОтмена - не закрывать окно.",
                "Предупреждение", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                MainWindow.removeWindow(id);
                this.Close();
            }
            else if (result == MessageBoxResult.No) 
            {
                this.Close();
            }
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.addNewWindow();
        }
    }
}

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

namespace QsFlai
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BackgroundPiner backgroundPiner;

        public MainWindow()
        {
            InitializeComponent();
            dfghkbjsdgkjsdfng
            // Создавать новый window для каждого gap в Settings
            // Это окно Просто спрятать Visible hide 
            Settings.Save();
            backgroundPiner = new BackgroundPiner(this);
            SetDefaultWindowSettings();
        }
        private void SetDefaultWindowSettings()
        {
            //WindowProperties properties = Settings.getWindowProperties();

           /* Left = properties.X;
            Top = properties.Y;

            Height = properties.Height;
            Width = properties.Width;*/
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
    }
}

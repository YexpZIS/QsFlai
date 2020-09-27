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
        public static Settings settings;
        BackgroundPiner backgroundPiner;

        public MainWindow()
        {
            InitializeComponent();

            settings = new Settings();
            backgroundPiner = new BackgroundPiner(this);
            CreateVirtualFolders();
        }
        
        private void CreateVirtualFolders()
        {
            for (int i=0;i<settings.gaps.Count;i++)
            {
                new VirtualFolder(i).Show();
            }
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

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

namespace QsFlai
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Settings settings;

        public MainWindow()
        {
            InitializeComponent();

            settings = new Settings();
            var backgroundPiner = new BackgroundPiner(this);
            CreateVirtualFolders();
        }
        
        private void CreateVirtualFolders()
        {
            for (int i=0;i<settings.gaps.Count;i++)
            {
                showWindow(i);
            }
        }
        private static void showWindow(int index)
        {
            new VirtualFolder(index).Show();
        }

        public static void addNewWindow()
        {
            settings.gaps.Add(new Gap());
            showWindow(settings.gaps.Count-1);

            Save();
        }
        public static void removeWindow(int id)
        {
            settings.gaps.RemoveAt(id);
            Save();
        }

        public static void Save()
        {
            settings.Save();
        }
    }
}

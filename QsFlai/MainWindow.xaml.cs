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
        private static List<VirtualFolder> folders;

        public MainWindow()
        {
            InitializeComponent();

            folders = new List<VirtualFolder>();

            settings = new Settings();
            var backgroundPiner = new BackgroundPiner(this);
            CreateVirtualFolders();
        }
        
        private static void CreateVirtualFolders()
        {
            int id = 0;

            for (int i=0;i<settings.gaps.Count;i++)
            {
                id = settings.gaps[i].id;
                showWindow(id);
            }
        }
        private static void showWindow(int index)
        {
            var f = new VirtualFolder(index);
            folders.Add(f);

            f.Show();
        }

        public static void addNewWindow()
        {
            int id = getNextWindowId();

            settings.gaps.Add(new Gap(id));
            showWindow(id);

            Save();
        }
        public static int getNextWindowId()
        {
            return settings.gaps.OrderByDescending(x=>x.id).First().id + 1;
        }
        public static void removeWindow(int id)
        {
            var gap = settings.gaps.Where(x=>x.id == id).First();

            if (gap != null)
            {
                settings.gaps.Remove(gap);
                Save();
            }
        }
        public static void Reboot()
        {
            foreach (var f in folders)
            {
                try
                {
                    f.Close();
                }
                catch { }
            }

            folders.Clear();

            settings.Load();
            CreateVirtualFolders();
        }
        public static void Save()
        {
            settings.Save();
        }
    }
}

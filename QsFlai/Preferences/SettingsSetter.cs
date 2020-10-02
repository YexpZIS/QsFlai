using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace QsFlai.Preferences
{
    class SettingsSetter
    {
        private Gap settings;
        private СustomizableObjects objects;

        public SettingsSetter(Gap settings, СustomizableObjects objects)
        {
            this.settings = settings;
            this.objects = objects;

            LoadSettings();
        }

        private void LoadSettings()
        {
            setWindowSize(settings.Scale.Final);
            setWindowPosition(settings.Position);

            setWindowName(settings.Name);

            loadFiles(settings.Files);
        }

        private void setWindowSize(Size size)
        {
            objects.window.Width = size.Width;
            objects.window.Height = size.Height;
        }
        private void setWindowPosition(Point position)
        {
            objects.window.Left = position.X;
            objects.window.Top = position.Y;
        }
        private void setWindowName(string name)
        {
            objects.name.Content = name;
            objects.editableName.Text = name;
        }
        private void loadFiles(List<File> files)
        {
            /*foreach (File file in files)
            {
                objects.filesViewer.Children.Add(new Element(file));
            }*/
            //FolderPanel
        }

    }
}

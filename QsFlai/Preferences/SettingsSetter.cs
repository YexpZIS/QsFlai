using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

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

            setBorderColor();
            setGridImage();
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
        private void setGridImage()
        {
            var img = objects.image;

            if (settings.isImgStaticSize)
            {
                var size = settings.Scale.Final;

                img.Width = size.Width;
                img.Height = size.Height;
            }

            try
            {
                var loader = new ImageLoader(ref img);
                loader.LoadImage(settings.BackgroundImage);
            }
            catch { }
        }
        private void setBorderColor()
        {
            objects.border.Background = new SolidColorBrush(settings.borderColor);
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

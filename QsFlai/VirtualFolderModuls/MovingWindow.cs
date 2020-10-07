using QsFlai.Preferences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace QsFlai.VirtualFolderModuls
{
    class MovingWindow
    {
        private UIElement element;
        private Window window;
        private Gap settings;

        public MovingWindow(ref Gap settings, Window window, UIElement element)
        {
            this.settings = settings;
            this.window = window;
            this.element = element;

            element.MouseMove += MoveWindow;
            element.MouseLeave += SavePosition;
        }

        public void MoveWindow(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                try
                {
                    window.DragMove();
                }
                catch { }
            }
        }
        public void SavePosition(object sender, MouseEventArgs e)
        {
            settings.Position = new Point(window.Left, window.Top);
            MainWindow.Save();
        }
    }
}

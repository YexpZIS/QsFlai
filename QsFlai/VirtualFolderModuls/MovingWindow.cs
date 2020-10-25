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
            element.MouseLeave += SetPosition;
            //window.Closed += Save;
        }

        public void MoveWindow(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (!e.Handled) // ? Событие еще не обработано другим событием ? 
                {
                    // Если убрать данную проверку по возникают трудно уловимые ошибки
                    try
                    {
                        window.DragMove();
                    }
                    catch { }
                }

            }
        }
        public void SetPosition(object sender, MouseEventArgs e)
        {
            var point = new Point(window.Left, window.Top);

            if (!settings.Position.Equals(point))
            {
                settings.Position = point;
            }
        }

        public void Save(object sender, EventArgs e)
        {
            MainWindow.Save();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace QsFlai.Animations.WindowSize
{
    class WindowManager
    {
        Changer width;
        Changer height;

        public WindowManager(Grid grid)
        {
            width = new Width(grid);
            height = new Height(grid);
        }

        public void resizeWindowToMinimumSize()
        {
            changeWindowSize(Settings.gaps[id].Scale.Initial);
        }
        public void resizeWindowToMaximumSize()
        {
            changeWindowSize(Settings.gaps[id].Scale.Final);
        }
        private void changeWindowSize(Size size)
        {
            this.width.Change((int)size.Width);
            this.height.Change((int)size.Height);
        }
    }
}

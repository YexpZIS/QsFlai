using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace QsFlai.Animations.WindowSize
{
    class WindowManager
    {
        Changer width;
        Changer height;

        public WindowManager(Settings settings,Grid grid)
        {
            width = new Width(settings,grid);
            height = new Height(settings,grid);
        }

        public void changeWindowSize(int width, int height)
        {
            this.width.Change(width);
            this.height.Change(height);
        }
    }
}

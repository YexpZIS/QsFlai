using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace QsFlai.Animations.WindowSize
{
    class Width : Animation
    {
        public Width(Settings settings,Grid grid) : base(settings,grid)
        {
            property = Grid.WidthProperty;
        }

        protected override void Save(int size)
        {
            settings.window.Width = size;
        }
    }
}

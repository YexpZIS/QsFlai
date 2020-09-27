using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace QsFlai.Animations.WindowSize
{
    class Width : Animation
    {
        public Width(Grid grid) : base(grid)
        {
            property = Grid.WidthProperty;
        }

        protected override void Save(Size min, Size max)
        {
            Settings.gaps[id].Scale.Final= max;
        }
    }
}

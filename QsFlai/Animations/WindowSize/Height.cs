using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace QsFlai.Animations.WindowSize
{
    class Height : Animation
    {
        public Height(Grid grid) : base(grid)
        {
            property = Grid.HeightProperty;
        }

        protected override void Save(int size)
        {
            Settings.gaps[id].Scale.Final.Height = size;
        }
    }
}

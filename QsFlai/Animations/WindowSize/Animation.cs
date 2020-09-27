using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace QsFlai.Animations.WindowSize
{
    abstract class Animation : Changer
    {
        private DoubleAnimation animation;

        protected Grid grid;
        protected DependencyProperty property;

        protected Animation(Grid grid)
        {
            this.grid = grid;

            animation = new DoubleAnimation();
            animation.Duration = TimeSpan.FromMilliseconds(Settings.gaps[id].Animation.Speed);
        }

        public void Change(int size)
        {
            //Save(size);
            animation.To = size;
            grid.BeginAnimation(property, animation);
        }

        protected abstract void Save(Size min, Size max);
    }
}

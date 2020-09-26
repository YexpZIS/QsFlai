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

        protected Settings settings;
        protected Grid grid;
        protected DependencyProperty property;

        protected Animation(Settings settings, Grid grid)
        {
            this.settings = settings;
            this.grid = grid;

            animation = new DoubleAnimation();
            animation.Duration = TimeSpan.FromMilliseconds(settings.AnimationSpeed);
        }

        public void Change(int size)
        {
            Save(size);
            animation.To = size;
            grid.BeginAnimation(property, animation);
        }

        protected abstract void Save(int size);
    }
}

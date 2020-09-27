using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace QsFlai.Animations.WindowSize
{
    public class Animation
    {
        private DoubleAnimation animation;
        private DependencyProperty property;
        private Grid grid;

        public Animation(Grid grid, DependencyProperty property, int AnimationSpeed)
        {
            this.grid = grid;
            this.property = property;

            animation = new DoubleAnimation();
            animation.Duration = TimeSpan.FromMilliseconds(AnimationSpeed);
        }

        public void setDefaultValue(object obj)
        {
            // Если grid не задать начального значения свойствам
            // (Height, Width), то вернет значение 'NaN'

            var pro = grid.GetType().GetProperty(property.ToString());
            pro.SetValue(grid, obj);
        }

        public void Change(int size)
        {
            animation.From =(double) grid.GetValue(property);
            animation.To = size;
            grid.BeginAnimation(property, animation);
        }

    }
}

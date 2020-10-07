using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace QsFlai.Animations.GridSize
{
    public class Animation
    {
        public DoubleAnimation animation;

        private DependencyProperty property;
        private UIElement ement;

        public Animation(UIElement grid, DependencyProperty property, int AnimationSpeed)
        {
            this.ement = grid;
            this.property = property;

            animation = new DoubleAnimation();
            animation.Duration = TimeSpan.FromMilliseconds(AnimationSpeed);
        }

        public void setDefaultValue(object obj)
        {
            // Если grid не задать начального значения свойствам
            // (Height, Width), то вернет значение 'NaN'

            var pro = ement.GetType().GetProperty(property.ToString());
            pro.SetValue(ement, obj);
        }

        public void Begin(int size)
        {
            animation.From = (double)ement.GetValue(property);
            animation.To = size;
            ement.BeginAnimation(property, animation);
        }

    }
}

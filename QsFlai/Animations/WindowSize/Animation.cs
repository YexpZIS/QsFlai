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
    public class Animation<T> where T : Control
    {
        public DoubleAnimation animation;

        private DependencyProperty property;
        private Control control;

        public Animation(T control, DependencyProperty property, int AnimationSpeed)
        {
            this.control = control;
            this.property = property;

            animation = new DoubleAnimation();
            animation.Duration = TimeSpan.FromMilliseconds(AnimationSpeed);
        }

        public void setDefaultValue(object obj)
        {
            // Если grid не задать начального значения свойствам
            // (Height, Width), то вернет значение 'NaN'

            var pro = control.GetType().GetProperty(property.ToString());
            pro.SetValue(control, obj);
        }

        public void Begin(int size)
        {
            animation.From = (double)control.GetValue(property);
            animation.To = size;
            control.BeginAnimation(property, animation);
        }

    }
}

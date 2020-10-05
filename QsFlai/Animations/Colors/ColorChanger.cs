using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace QsFlai.Animations.Colors
{
    class ColorChanger<T> where T :  class
    {
        public DoubleAnimation animation;

        private DependencyProperty property;
        private T @object;

        public ColorChanger(object obj, DependencyProperty property, int speed)
        {
            @object = obj as T;
            this.property = property;

            animation = new DoubleAnimation();
            animation.Duration = TimeSpan.FromMilliseconds(speed);

            /*var pro = (obj as T).GetType().GetProperty(property.ToString());
            pro.SetValue((obj as T), Brushes.Red);
            //control.Background = Brushes.Red;*/
        }

        public void changeColor(Brushes brushe)
        {
            // Попробовать перписать класс Animation в abstract для 
            // переиспользовния его
        }
    }
}

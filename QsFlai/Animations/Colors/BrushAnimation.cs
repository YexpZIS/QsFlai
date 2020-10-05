using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace QsFlai.Animations.Colors
{
    public class BrushAnimation
    {
        public SolidColorBrush brush;
        public ColorAnimation animation;

        public BrushAnimation(int speed)
        {
            brush = new SolidColorBrush();
            animation = new ColorAnimation();

            animation.Duration = TimeSpan.FromMilliseconds(speed);
        }


        public void Begin(Color color)
        {
            animation.To = color;
            brush.BeginAnimation(SolidColorBrush.ColorProperty, animation);
        }
        
    }
}

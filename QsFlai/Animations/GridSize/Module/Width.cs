using QsFlai.Preferences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace QsFlai.Animations.GridSize.Module
{
    public class Width : Parties
    {
        public Width(Gap settings, UIElement element) : base(settings, element)
        { }

        public override void Initialization()
        {
            animation = new Animation(element, Grid.WidthProperty, settings.Animation.Speed);
            animation.setDefaultValue(settings.Scale.Initial.Width);
            animation.animation.Completed += Animation_Completed;
        }

        protected override void changeSize(Size size)
        {
            animation.Begin((int)size.Width);
        }
    }
}

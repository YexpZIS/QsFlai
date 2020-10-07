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
    class Height : Parties
    {
        public Height(Gap settings, UIElement element) : base(settings, element)
        { }

        public override void Initialization()
        {
            animation = new Animation(element, Grid.HeightProperty, settings.Animation.Speed);
            animation.setDefaultValue(settings.Scale.Initial.Height);
            animation.animation.Completed += Animation_Completed;
        }

        protected override void changeSize(Size size)
        {
            animation.Begin((int)size.Height);
        }
    }

    
}

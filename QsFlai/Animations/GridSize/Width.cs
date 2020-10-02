using QsFlai.Preferences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace QsFlai.Animations.GridSize
{
    public class Width : Parties
    {
        public Width(Grid grid, Gap settings) : base(grid, settings)
        { }

        public override void Initialization()
        {
            animation = new Animation(grid, Grid.WidthProperty, settings.Animation.Speed);
            animation.setDefaultValue(settings.Scale.Initial.Width);
            animation.animation.Completed += Animation_Completed;
        }

        protected override void changeSize(Size size)
        {
            animation.Begin((int)size.Width);
        }
    }
}

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
    public abstract class Parties
    {
        public Animation animation;

        protected UIElement element;
        protected Gap settings;

        public bool isAnimationComplite = true;

        public Parties(Gap settings, UIElement grid)
        {
            this.element = grid;
            this.settings = settings;
        }

        public abstract void Initialization();

        protected void Animation_Completed(object sender, EventArgs e)
        {
            isAnimationComplite = true;
        }

        public void Start(SizeState realState)
        {
            isAnimationComplite = false;

            if (realState == SizeState.Max)
            {
                changeSize(settings.Scale.Final);
            }
            else
            {
                changeSize(settings.Scale.Initial);
            }
        }

        protected abstract void changeSize(Size size);

    }
}

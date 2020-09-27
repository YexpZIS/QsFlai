using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace QsFlai.Animations.WindowSize
{
    public enum GridState
    {
        Max,
        Min
    }

    class WindowManager
    {
        private Gap settings;
        private Animation width;
        private Animation height;

        private GridState state;
        private bool isAnimationActive = false;

        public WindowManager(Grid grid, Gap settings)
        {
            this.settings = settings;
            int animationSpeed = settings.Animation.Speed;


            var initSize = settings.Scale.Initial;

            width = new Animation(grid, Grid.WidthProperty, animationSpeed);
            width.setDefaultValue(initSize.Width);

            height = new Animation(grid, Grid.HeightProperty, animationSpeed);
            height.setDefaultValue(initSize.Height);

            state = GridState.Min;
        }

        public void resizeWindowToMinimumSize()
        {
            if (state == GridState.Max && !isAnimationActive) 
            {
                isAnimationActive = true;
                changeWindowSize(settings.Scale.Initial);
                state = GridState.Min;
                isAnimationActive = false;
            }
        }
        public void resizeWindowToMaximumSize()
        {
            if (state == GridState.Min && !isAnimationActive)
            {
                isAnimationActive = true;
                changeWindowSize(settings.Scale.Final);
                state = GridState.Max;
                isAnimationActive = false;
            }
        }
        private void changeWindowSize(Size size)
        {
            this.width.Change((int)size.Width);
            this.height.Change((int)size.Height);
        }
    }
}

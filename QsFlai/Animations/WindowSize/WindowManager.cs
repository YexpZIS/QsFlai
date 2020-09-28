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

        private GridState state = GridState.Min;
        private GridState realState;

        private bool isAnimationCompleted = true;

        public WindowManager(Grid grid, Gap settings, ref GridState state)
        {
            this.settings = settings;
            int animationSpeed = settings.Animation.Speed;


            var initSize = settings.Scale.Initial;

            width = new Animation(grid, Grid.WidthProperty, animationSpeed);
            width.setDefaultValue(initSize.Width);

            height = new Animation(grid, Grid.HeightProperty, animationSpeed);
            height.setDefaultValue(initSize.Height);

            realState = state;

            width.animation.Completed += Animation_Completed;
            height.animation.Completed += Animation_Completed;

            grid.MouseEnter += Grid_MouseEnter;
            grid.MouseLeave += Grid_MouseLeave;
        }

        private void Grid_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            realState = GridState.Min;
            Resize();
        }

        private void Grid_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            realState = GridState.Max;
            Resize();
        }

        private void Animation_Completed(object sender, EventArgs e)
        {

            if (realState != state)
            {
                isAnimationCompleted = true;
                Resize();
            }
            isAnimationCompleted = true;
        }
        private void Animation_Completed1(object sender, EventArgs e)
        {

            if (realState != state)
            {
                isAnimationCompleted1 = true;
                Resize();
            }
            isAnimationCompleted1 = true;
        }

        private void Resize()
        {
            if (isAnimationCompleted ) 
            {
                isAnimationCompleted = false;
                isAnimationCompleted1 = false;

                state = realState;

                if (realState == GridState.Max)
                {
                    changeWindowSize(settings.Scale.Final);
                }
                else
                {
                    changeWindowSize(settings.Scale.Initial);
                }
            }
        }

       /* public void resizeWindowToMinimumSize()
        {
            if (isAnimationCompleted()) {
                changeWindowSize(settings.Scale.Initial);
                state = GridState.Min;
            }
        }
        public void resizeWindowToMaximumSize()
        {
            if (isAnimationCompleted())
            {
                changeWindowSize(settings.Scale.Final);
                state = GridState.Max;
            }
        }
        private bool isAnimationCompleted()
        {
            return height.isAnimationCompleted &&
                width.isAnimationCompleted;
        }*/

        private void changeWindowSize(Size size)
        {
            this.width.Begin((int)size.Width);
            this.height.Begin((int)size.Height);
        }
    }
}

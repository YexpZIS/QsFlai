using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace QsFlai.Animations.WindowSize
{
    class Height
    {
        public Animation animation;

        private Grid grid;
        private Gap settings;

        public GridState state = GridState.Min;
        public bool isAnimationComplite = true;

        public Height(Grid grid, Gap settings)
        {
            this.grid = grid;
            this.settings = settings;
        }

        public void Init()
        {
            animation = new Animation(grid, Grid.HeightProperty, settings.Animation.Speed);
            animation.setDefaultValue(settings.Scale.Initial.Height);
            animation.animation.Completed += Animation_Completed;
        }

        private void Animation_Completed(object sender, EventArgs e)
        {
            isAnimationComplite = true;
        }

        public void Start(GridState realState)
        {
            if (state != realState)
            {
                state = realState;
                isAnimationComplite = false;

                if (realState == GridState.Max)
                {
                    changeSize(settings.Scale.Final);
                }
                else
                {
                    changeSize(settings.Scale.Initial);
                }
            }
        }

        private void changeSize(Size size)
        {
            animation.Begin((int)size.Height);
        }
    }

    class Width
    {
        public Animation animation;

        private Grid grid;
        private Gap settings;

        public GridState state = GridState.Min;
        public bool isAnimationComplite = true;

        public Width(Grid grid, Gap settings)
        {
            this.grid = grid;
            this.settings = settings;
        }

        public void Init()
        {
            animation = new Animation(grid, Grid.WidthProperty, settings.Animation.Speed);
            animation.setDefaultValue(settings.Scale.Initial.Height);
            animation.animation.Completed += Animation_Completed;
        }

        private void Animation_Completed(object sender, EventArgs e)
        {
            isAnimationComplite = true;
        }

        public void Start(GridState realState)
        {
            if (state != realState)
            {
                state = realState;
                isAnimationComplite = false;

                if (realState == GridState.Max)
                {
                    changeSize(settings.Scale.Final);
                }
                else
                {
                    changeSize(settings.Scale.Initial);
                }
            }
        }

        private void changeSize(Size size)
        {
            animation.Begin((int)size.Width);
        }
    }

    public class AnimationManager 
    {
        public delegate void SizeChanged();
        public SizeChanged sizeChanged;

        private Height height;
        private Width width;

        private bool isHeightComplete = true;
        private bool isWidthComplete = true;

        private GridState state = GridState.Min;

        public AnimationManager(Grid grid, Gap settings)
        {
            height = new Height(grid, settings);
            height.Init();
            width = new Width(grid, settings);
            width.Init();

            height.animation.animation.Completed += heightCompleted;
            width.animation.animation.Completed += widthCompleted;
        }

        private void heightCompleted(object sender, EventArgs e)
        {
            isHeightComplete = true;

            Notify();
        }

        private void widthCompleted(object sender, EventArgs e)
        {
            isWidthComplete = true;

            Notify();
        }
        private void Notify()
        {
            if (checkSize())
            {
                sizeChanged.Invoke();
            }
        }

        public bool checkSize()
        {
            return isHeightComplete && isWidthComplete;
        }

        public void setSize(GridState state)
        {
            if (checkSize() && this.state != state)
            {
                this.state = state;

                isWidthComplete = false;
                isHeightComplete = false;

                width.Start(state);
                height.Start(state);
            }
        }
    }
}

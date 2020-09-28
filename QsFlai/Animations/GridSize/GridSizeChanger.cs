using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace QsFlai.Animations.GridSize
{
    public class GridSizeChanger
    {
        public delegate void SizeChanged();
        public SizeChanged sizeChanged;

        private Height height;
        private Width width;

        private bool isHeightComplete = true;
        private bool isWidthComplete = true;

        private GridState state = GridState.Min;

        public GridSizeChanger(Grid grid, Gap settings)
        {
            height = new Height(grid, settings);
            height.Initialization();
            width = new Width(grid, settings);
            width.Initialization();

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

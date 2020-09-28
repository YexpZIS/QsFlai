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
        private Height height;
        private Width width;

        private GridState realState;

        public WindowManager(Grid grid, Gap settings, ref GridState state)
        {
            this.settings = settings;

            height = new Height(grid, settings);
            height.Init();
            width = new Width(grid, settings);
            width.Init();

            grid.MouseEnter += Grid_MouseEnter;
            grid.MouseLeave += Grid_MouseLeave;
        }

        private void Grid_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (width.isAnimationComplite && height.isAnimationComplite)
            {
                width.Start(GridState.Max);
                height.Start(GridState.Max);
            }
        }
        private void Grid_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (width.isAnimationComplite && height.isAnimationComplite)
            {
                width.Start(GridState.Min);
                height.Start(GridState.Min);
            }
        }
    }
}

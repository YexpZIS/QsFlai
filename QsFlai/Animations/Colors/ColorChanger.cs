using QsFlai.Preferences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace QsFlai.Animations.Colors
{
    class ColorChanger
    {
        private BrushAnimation animation;

        private Gap settings;

        private Color[] colors;
        private Color originalColor;
        private int index = 0;

        private bool isRun = false;

        public ColorChanger(Gap settings,Preferences.Colors colors)
        {
            this.settings = settings;
            this.originalColor = colors.originalColor;
            this.colors = colors.colors;

            animation = new BrushAnimation(settings.Animation.Speed);
            animation.animation.Completed += Animation_Completed;
            animation.brush = new SolidColorBrush(originalColor);
        }

        private void Animation_Completed(object sender, EventArgs e)
        {
            if (isRun)
            {
                index = index + 1 == colors.Length ? 0 : ++index;
                animation.Begin(colors[index]);
            }
            else if(GetBrush().Color != originalColor)
            {
                // Возвращаем обьект к первоначальному цвету
                animation.Begin(originalColor);
            }
        }

        public void Begin()
        {
            isRun = true;
            index = 0;
            animation.Begin(colors[index]);
        }

        public void Stop()
        {
            isRun = false;
        }

        public SolidColorBrush GetBrush()
        {
            return animation.brush;
        }
    }
}

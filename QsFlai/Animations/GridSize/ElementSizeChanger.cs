﻿using QsFlai.Animations.GridSize.Module;
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
    public class ElementSizeChanger
    {
        public delegate void SizeChanged();
        public SizeChanged sizeChanged;

        private Parties[] parties;
        private bool[] isAnimationComplete = new bool[2] { true, true };

        private SizeState state = SizeState.Min;

        public ElementSizeChanger(ref Gap settings, UIElement element)
        {
            parties = new Parties[2] { new Height(settings, element),
                                        new Width(settings, element) };

            for (int i = 0; i < parties.Length; i++) 
            {
                parties[i].Initialization();
            }

            parties[0].animation.animation.Completed += heightCompleted;
            parties[1].animation.animation.Completed += widthCompleted;
        }

        private void heightCompleted(object sender, EventArgs e)
        {
            isAnimationComplete[0] = true;
            Notify();
        }

        private void widthCompleted(object sender, EventArgs e)
        {
            isAnimationComplete[1] = true;
            Notify();
        }
        private void Notify()
        {
            if (checkSize())
            {
                sizeChanged.Invoke();
            }
        }

        private bool checkSize()
        {
            bool result = true;

            foreach (bool status in isAnimationComplete)
            {
                result &= status;
            }

            return result;
        }

        public void setSize(SizeState state)
        {
            if (checkSize() && this.state != state)
            {
                setSizeUnchecked(state);
            }
        }
        public void setSizeUnchecked(SizeState state)
        {
            this.state = state;

            for (int i = 0; i < parties.Length; i++)
            {
                isAnimationComplete[i] = false;
                parties[i].Start(state);
            }
        }
    }
}

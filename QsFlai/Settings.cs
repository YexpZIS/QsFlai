using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace QsFlai
{
    public class Settings
    {
        public WindowProperties window;

        public int AnimationSpeed { get; set; } = 2000; // in Milliseconds
        
        public Settings()
        {
            window = new WindowProperties();
        }

    }

    public class WindowProperties
    {
        public int Height { get; set; } = 450;
        public int Width { get; set; } = 800;
        public int X { get; set; }
        public int Y { get; set; }
    }
}

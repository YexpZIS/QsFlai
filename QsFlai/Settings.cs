using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QsFlai
{
    public class Settings
    {
        public WindowProperties window;

        public string name = ".settings";
        private string path;
        public int AnimationSpeed { get; set; } = 2000; // in Milliseconds
        
        public Settings()
        {
            path = Directory.GetCurrentDirectory();

            window = new WindowProperties();
        }

        public void Save()
        {
            // ToDo serialize objects JSON
            string text = "// ToDo serialize objects JSON";
            File.WriteAllText(String.Format("{0}/{1}", path, name), text);
        }
        public void Load()
        {
            // ToDo serialize objects JSON
            //File.ReadAllText();
        }

    }

    public class WindowProperties
    {
        public int Height { get; set; } = 450;
        public int Width { get; set; } = 800;
        public int X { get; set; }
        public int Y { get; set; }
    }

    // serialize List<Gaps>
    public class Gap 
    {
        public string Name { get; set; } = "Window"; // Название окна

        // Position
        public Point Position { get; set; } = new Point(0, 0); // Положение окна по оси X и Y

        // Size можно свернуть эти свойства в класс
        public bool StaticSize { get; set; } = false; // если true, то окно не меняет ширину и принимает размер FinalSize
        public Size InitialSize { get; set; } = new Size(120,30); // Начальный размер
        public Size FinalSize { get; set; } = new Size(450,800); // Конечный размер

        // Animation Speed
        public double AnimationSpeed { get; set; } = 1000; // Скорость анимаций в милисекундах

        public List<File> Files { get; set; } // Список файлов, добавленных в окно
    }

    public class Size
    {
        public Size(int Width, int Height)
        {
            this.Width = Width;
            this.Height = Height;
        }

        public int Width { get; set; }
        public int Height { get; set; }
    }

    public class File
    {
        public string Name { get; set; } // Название файла
        public string Image { get; set; } //Изображение в формате Base64
        public string Link { get; set; } // Ссылка на файл
    }
}

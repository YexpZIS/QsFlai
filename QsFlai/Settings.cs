using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;

using Sys = System.IO.File;
using System.Windows.Controls;

namespace QsFlai
{
    public class Settings
    {
        private readonly string name = "QsFlai.settings";
        private readonly string path;
        private readonly string fullname;

        public List<Gap> gaps;
        
        public Settings()
        {
            path = Directory.GetCurrentDirectory();
            fullname = String.Format("{0}/{1}", path, name);
            gaps = new List<Gap>();

            Load();
        }

        public void Save()
        {
            string json = JsonConvert.SerializeObject(gaps);
            Sys.WriteAllText(fullname, json);
        }
        public void Load()
        {
            if (Sys.Exists(fullname))
            {
                string json = Sys.ReadAllText(fullname);
                gaps = JsonConvert.DeserializeObject<List<Gap>>(json);
            }
            else
            {
                gaps.Add(new Gap());
                Save();
            }
        }


    }

    // serialize List<Gaps>
    public class Gap 
    {
        public string Name { get; set; } = "Window"; // Название окна

        public string BackgroundImage { get; set; } //(base64) Изображение на подложке типа постер 
        //(при увеличении/уменьшении окна 
        //не должно меняться в размерах)

        // Position
        public Point Position { get; set; } = new Point(0, 0); // Положение окна по оси X и Y

        // Size 
        public Scale Scale { get; set; } = new Scale(); // Отвечает за размер окна

        // Animation 
        public Animation Animation { get; set; } = new Animation();// Отвечает за настройки анимации

        // Files
        public List<File> Files { get; set; } = new List<File>(); // Список файлов, добавленных в окно
    }

    public class Scale
    {
        // Статическую шириру/высоту можно получить при указании одинаковых значений в Initial и Final
        public Size Initial { get; set; } = new Size(120, 30); // Начальный размер (min)
        public Size Final { get; set; } = new Size(450, 800); // Конечный размер (max)
    }

    public class Colors
    {
        /*public EditingMode="";
        public WindowHeader;// Body Border + files color*/
    }

    public class Animation
    {
        public int Speed { get; set; } = 1000; // Скорость всех анимаций в милисекундах
    }

    public class File
    {
        public string Name { get; set; } // Название файла
        public string Image { get; set; } //Изображение в формате Base64
        public string Link { get; set; } // Ссылка на файл
    }
}

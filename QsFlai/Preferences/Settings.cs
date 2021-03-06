﻿using Microsoft.Win32;
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
using System.Windows.Media;

namespace QsFlai.Preferences
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

                if (gaps == null || gaps.Count == 0)
                {
                    gaps = new List<Gap>();
                    gaps.Add(new Gap(0));
                }
            }
            else
            {
                gaps = new List<Gap>();
                gaps.Add(new Gap(0));
                Save();
            }
        }

    }

    [Serializable]
    public class Gap
    {
        public int id { get; set; }

        public Gap(int id)
        {
            this.id = id;
        }

        public TopBorder border = new TopBorder();

        public string BackgroundImage { get; set; } // Путь к изображению типа постер 
        //(при увеличении/уменьшении окна 
        //не должно меняться в размерах)
        public bool isImgStaticSize = true;

        // Position
        public Point Position { get; set; } = new Point(0, 0); // Положение окна по оси X и Y

        // Size 
        public Scale Scale { get; set; } = new Scale(); // Отвечает за размер окна

        // Animation 
        public Animation Animation { get; set; } = new Animation();// Отвечает за настройки анимации

        // Files
        public FilesSettings filesSettings { get; set; } = new FilesSettings();
        public List<File> Files { get; set; } = new List<File>(); // Список файлов, добавленных в окно

        // Цвета editMode
        public Colors editMode { get; set; } = new Colors(Color.FromArgb(100, 0, 0, 0),
                new Color[] { Color.FromArgb(90, 255, 0, 0),
                              Color.FromArgb(100, 0, 0, 0)});

        public Gap DeepCopy()
        {
            var gap = (Gap)this.MemberwiseClone();
            gap.Scale = this.Scale.DeepCopy();

            return gap;
        }
    }

    public class TopBorder 
    {
        public string Name { get; set; } = "Window"; // Название окна
        public Color BorderColor { get; set; } = Color.FromArgb(128, 0, 0, 0); // Цвет верхней полоски
        public Color TextColor { get; set; } = Color.FromArgb(255, 255, 255, 255);
        public FontFamily FontFamily { get; set; } = new FontFamily("Segoe UI");
        public double FontSize { get; set; } = 20;
        public int TextHeight { get; set; } = 40;
        public int BorderHeight { get; set; } = 30;
    }
        
    public class Scale
    {
        // Статическую шириру/высоту можно получить при указании одинаковых значений в Initial и Final
        public Size Initial { get; set; } = new Size(120, 30); // Начальный размер (min)
        public Size Final { get; set; } = new Size(800, 450); // Конечный размер (max)
    
        public Scale DeepCopy()
        {
            return (Scale)this.MemberwiseClone();
        }
    }

    public class Colors
    {
        public Color originalColor { get; set; } = Color.FromArgb(100, 0, 0, 0);
        public Color[] colors { get; set; }

        public Colors() { }
        public Colors(Color originalColor, Color[] colors)
        {
            this.originalColor = originalColor;
            this.colors = colors;
        }
    }

    public class Animation
    {
        public int Speed { get; set; } = 1000; // Скорость всех анимаций в милисекундах
    }

    public class File
    {
        public int id { get; set; }
        public string Name { get; set; } // Название файла
        public string Image { get; set; } //Изображение в формате Base64
        public string Link { get; set; } // Ссылка на файл
    }

    public class FilesSettings
    {
        public Size Size { get; set; } = new Size(80, 110);
        public double blockHeight { get; set; } = 40;

        public Thickness Margin { get; set; } = new Thickness(1);

        // Text
        public Color TextColor { get; set; } = Color.FromArgb(255, 255, 255, 255);
        public FontFamily FontFamily { get; set; } = new FontFamily("Agency FB");
        public double FontSize { get; set; } = 20;

        // Border
        public Color BackgroundColor { get; set; } = Color.FromArgb(128, 0, 0, 0);
        public Color BorderColor { get; set; } = Color.FromArgb(255, 0, 0, 0);
        public Thickness BorderSize { get; set; } = new Thickness(1);

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using sys = System.IO;

namespace QsFlai.Preferences
{
    class ImageLoader
    {
        private Image img;
        private string name;

        public ImageLoader(ref Image img)
        {
            this.img = img;
        }

        public void LoadImage(string name)
        {
            this.name = name;

            if (!String.IsNullOrEmpty(name) && isExists())
            {
                img.Source = new BitmapImage(new Uri(
                    String.Concat(Environment.CurrentDirectory, "/", name)));
            }
            else
            {
                img.Source = null;
            }
        }

        
        private bool isExists()
        {
            return sys.File.Exists(name);
        }


    }
}

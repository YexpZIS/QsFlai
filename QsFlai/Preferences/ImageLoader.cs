using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using sys = System.IO;
using Drawing = System.Drawing;
using System.Windows.Media;
using System.Windows.Interop;

namespace QsFlai.Preferences
{
    class ImageLoader
    {
        private Image img;
        private string name;

        private IntPtr HBitmap;
        private Drawing.Icon icon;
        private Drawing.Bitmap bitmap;

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);

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

        public void LoadIcon(string link)
        {
            icon = Drawing.Icon.ExtractAssociatedIcon(link);
            bitmap = icon.ToBitmap();
            HBitmap = bitmap.GetHbitmap();

            ImageSource imgSource =
                 Imaging.CreateBitmapSourceFromHBitmap(
                      HBitmap, IntPtr.Zero, System.Windows.Int32Rect.Empty,
                      BitmapSizeOptions.FromEmptyOptions());

            img.Source = imgSource;


            // Clear memory
            DeleteObject(HBitmap);
            icon.Dispose();
            bitmap.Dispose();
            GC.Collect();
        }

        
        private bool isExists()
        {
            return sys.File.Exists(name);
        }


    }
}

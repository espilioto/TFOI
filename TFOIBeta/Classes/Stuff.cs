using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace TFOIBeta
{
    public class Image : System.Windows.Controls.Image
    {
        public string ObjectName { get; set; }
        public string ObjectDescription { get; set; }
        public string ObjectMisc { get; set; }
    }

    class Stuff
    { 

        public static ImageSource BitmapToImageSource(Bitmap bitmap)
        {
            return System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                bitmap.GetHbitmap(),
                IntPtr.Zero,
                Int32Rect.Empty,
                BitmapSizeOptions.FromEmptyOptions());
        }

    }
}

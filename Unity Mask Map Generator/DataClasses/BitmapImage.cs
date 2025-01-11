using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unity_Mask_Map_Generator.DataClasses
{
    internal class BitmapImage
    {
        private Bitmap bitmap { get; set; }
        private string filePath { get; set; }
        public BitmapImage(Bitmap bitmap, string filePath)
        {
            this.bitmap = bitmap;
            this.filePath = filePath;
        }

        public String getSource()
        {
            return filePath;
        }

        public Bitmap getBitmap()
        {
            return bitmap;
        }
    }
}

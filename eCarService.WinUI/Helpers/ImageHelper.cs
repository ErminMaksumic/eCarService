using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCarService.WinUI.Helpers
{
    public class ImageHelper
    {
        public static Image ByteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn, 0, byteArrayIn.Length);
            ms.Write(byteArrayIn, 0, byteArrayIn.Length);
            return Image.FromStream(ms, true);
        }

        public static byte[] ImageToByteArray(Image image)
        {
            MemoryStream stream = new MemoryStream();
            image?.Save(stream, image.RawFormat);
            return stream.ToArray();
        }
    }
}

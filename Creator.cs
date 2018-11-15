using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Stripper
{
    class Creator
    {
        readonly int sizeX = 1000;
        readonly int sizeY = 1000;
        Bitmap bitmap;

        

        public Creator()
        {
            bitmap = new Bitmap(sizeX, sizeY);
        }

        public Creator(int sizeX, int sizeY)
        {
            this.sizeX = sizeX;
            this.sizeY = sizeY;
            this.bitmap = new Bitmap(sizeX, sizeY);
        }

        public Bitmap PushTextData(string data)
        {
            
            byte[] bytes = Encoding.ASCII.GetBytes(data);
            
            if (bitmap != null && bytes.Length > 0)
            {
                int counter = 1;
                for (int i = 0; i < bitmap.Width; i++)
                {
                    for (int j = 0; j < bitmap.Height; j++)
                    {
                        if (counter < bytes.Length )
                        {
                            string yourByteString = Convert.ToString(bytes[counter], 2).PadLeft(8, '0');
                            if (yourByteString.Length != 0)
                            {
                                for (int k = 0; k < yourByteString.Length; k++)
                                {

                                    if (yourByteString[k] == '0')
                                    {
                                        bitmap.SetPixel(i, j, Color.Red);
                                    }
                                    if (yourByteString[k] == '1')
                                    {
                                        bitmap.SetPixel(i, j, Color.Blue);
                                    }
                                    counter++;
                                }
                            }
                        }
                        else
                        {
                            break;
                        }
                        
                        
                    }

                }
            }
            return bitmap;
            

        }

        static string ToBinaryString(Encoding encoding, string text)
        {
            return string.Join("", encoding.GetBytes(text).Select(n => Convert.ToString(n, 2).PadLeft(8, '0')));
        }

    }
}

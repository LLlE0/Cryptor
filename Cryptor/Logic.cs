using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Cryptor
{
    public struct Point
    {
        int h, w;
        public int W
        {
            get { return w;  }
            set { w = value; }
        }
        public int H
        {
            get { return h; }
            set { h = value; }
        }
        public Point(int a, int b)
        {
            w = a;
            h = b;
        }
    }
    public class Logic
    {
        //Commenting code sounds like good idea, I guess.
        public static List<string> WriteBits(string fileName, ref Bitmap pb)
        {
            List<string> ret = new();
            using (FileStream stream = File.OpenRead(fileName))
            {
                byte[] buffer = new byte[1];
                
                int i = 0;
                int bytesRead = 0;
                Point z = new Point(0, 0);
                do
                {
                    //reading file byte-by-byte
                    bytesRead = stream.Read(buffer, 0, buffer.Length);
                    if (bytesRead > 0)
                    {
                        //Converting whole byte into a string
                        ret.Add(Convert.ToString(buffer[0], 2).PadLeft(8, '0'));
                        //Main giant logic function to encrypt
                        Encryptor(ret[i], ref pb, ref z);
                    }
                    i++;
                } while (bytesRead > 0);
            }
            return ret;
        }


        //Function that encrypts bit-by-bit
        //Looks awful, but i guess it is absolutely readable.
        public static bool EncryptNextBit(ref Bitmap pb, Point z, int a, int strategy)
        {
            Color pix = pb.GetPixel(z.W, z.H);
            if (strategy == 1)
            {
                if (pix.R>0 && a==1 && pix.R%2==0)
                pb.SetPixel(z.W, z.H, Color.FromArgb(pix.R-1, pix.G, pix.B));
                else if (a == 1 && pix.R % 2 == 0 && pix.R == 0)
                pb.SetPixel(z.W, z.H, Color.FromArgb(pix.R+1, pix.G, pix.B));
                else if (a == 0 && pix.R % 2 == 1 && pix.R > 0)
                pb.SetPixel(z.W, z.H, Color.FromArgb(pix.R - 1, pix.G, pix.B));
                else if (a == 0 && pix.R % 2 == 1 && pix.R == 0)
                pb.SetPixel(z.W, z.H, Color.FromArgb(pix.R + 1, pix.G, pix.B));

            }
            if (strategy == 2)
            {
                if (pix.G > 0 && a == 1 && pix.G % 2 == 0)
                    pb.SetPixel(z.W, z.H, Color.FromArgb(pix.R, pix.G-1, pix.B));
                else if (a == 1 && pix.G % 2 == 0 && pix.G == 0)
                    pb.SetPixel(z.W, z.H, Color.FromArgb(pix.R, pix.G+1, pix.B));
                else if (a == 0 && pix.G % 2 == 1 && pix.G > 0)
                    pb.SetPixel(z.W, z.H, Color.FromArgb(pix.R, pix.G-1, pix.B));
                else if (a == 0 && pix.R % 2 == 1 && pix.R == 0)
                    pb.SetPixel(z.W, z.H, Color.FromArgb(pix.R, pix.G+1, pix.B));
            }
            if (strategy == 3)
            {
                if (pix.B > 0)
                    pb.SetPixel(z.W, z.H, Color.FromArgb(pix.R, pix.G, pix.B-a));
                else
                    pb.SetPixel(z.W, z.H, Color.FromArgb(pix.R, pix.G, pix.B+a));
            }
            
            return (pb.Width == z.W + 1);

        }
        //Encryptor
        public static bool Encryptor(string s, ref Bitmap pb, ref Point z)
        {
            
            return true;
        }
    }

    
}

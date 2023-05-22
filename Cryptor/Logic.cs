using System;
using System.Collections;
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

        public static bool EncryptNextBit(ref Bitmap pb, Point z, int a, int strategy)
        {
            Color pix = pb.GetPixel(z.W, z.H);
            if (strategy == 0)
            {
                if (pix.R > 0 && a == 1 && pix.R % 2 == 0)
                    pb.SetPixel(z.W, z.H, Color.FromArgb(pix.R - 1, pix.G, pix.B));
                else if (a == 1 && pix.R % 2 == 0 && pix.R == 0)
                    pb.SetPixel(z.W, z.H, Color.FromArgb(pix.R + 1, pix.G, pix.B));
                else if (a == 0 && pix.R % 2 == 1 && pix.R > 0)
                    pb.SetPixel(z.W, z.H, Color.FromArgb(pix.R - 1, pix.G, pix.B));
                else if (a == 0 && pix.R % 2 == 1 && pix.R == 0)
                    pb.SetPixel(z.W, z.H, Color.FromArgb(pix.R + 1, pix.G, pix.B));

            }
            if (strategy == 1)
            {
                if (pix.G > 0 && a == 1 && pix.G % 2 == 0)
                    pb.SetPixel(z.W, z.H, Color.FromArgb(pix.R, pix.G - 1, pix.B));
                else if (a == 1 && pix.G % 2 == 0 && pix.G == 0)
                    pb.SetPixel(z.W, z.H, Color.FromArgb(pix.R, pix.G + 1, pix.B));
                else if (a == 0 && pix.G % 2 == 1 && pix.G > 0)
                    pb.SetPixel(z.W, z.H, Color.FromArgb(pix.R, pix.G - 1, pix.B));
                else if (a == 0 && pix.G % 2 == 1 && pix.G == 0)
                    pb.SetPixel(z.W, z.H, Color.FromArgb(pix.R, pix.G + 1, pix.B));
            }
            if (strategy == 2)
            {
                if (pix.B > 0 && a == 1 && pix.B % 2 == 0)
                    pb.SetPixel(z.W, z.H, Color.FromArgb(pix.R, pix.G, pix.B - 1));
                else if (a == 1 && pix.B % 2 == 0 && pix.B == 0)
                    pb.SetPixel(z.W, z.H, Color.FromArgb(pix.R, pix.G, pix.B + 1));
                else if (a == 0 && pix.B % 2 == 1 && pix.B > 0)
                    pb.SetPixel(z.W, z.H, Color.FromArgb(pix.R, pix.G, pix.B - 1));
                else if (a == 0 && pix.B % 2 == 1 && pix.B == 0)
                    pb.SetPixel(z.W, z.H, Color.FromArgb(pix.R, pix.G, pix.B + 1));
            }

            return (pb.Width == z.W + 1);

        }


        public static byte[] ConvertToBytes(string b)
        {
            BitArray bits = new BitArray(b.ToList().ConvertAll<bool>(x => x == '1').ToArray());

            byte[] ret = new byte[bits.Length];
            bits.CopyTo(ret, 0);

            return ret;
        }

        public static bool WriteBitsToFile(string s, ref Bitmap pb)
        {
            int tx, ty;
            int strategy = 0;
            string convert="";
            int[] bits = {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
            ulong ind=0;
            var fileStream = new FileStream(s, FileMode.Create);
            int[] colors = { 1, 2, 3 };
            for (int y = 0; y < pb.Height; y++)
            {
                for (int x = 0; x < pb.Width; x++)
                {
                    colors[0] = pb.GetPixel(x, y).R;
                    colors[1] = pb.GetPixel(x, y).G;
                    colors[2] = pb.GetPixel(x, y).B;
                    if (colors[0] == 0 && colors[1] == 253 && colors[2] == 0)
                    { fileStream.Close(); return true;  }
                    int data = colors[strategy % 3] % 2;
                    bits[ind % 16] = data;
                    strategy++;
                    ind++;
                    if (ind % 16 == 0)
                    {
                        convert = $"{bits[15]}{bits[14]}{bits[13]}{bits[12]}{bits[11]}{bits[10]}{bits[9]}{bits[8]}{bits[7]}{bits[6]}{bits[5]}{bits[4]}{bits[3]}{bits[2]}{bits[1]}{bits[0]}";
                        fileStream.Write(ConvertToBytes(convert), 0, 2);
                        ind = 0;
                    }
                }
            }
            
            fileStream.Close();
            return false;

        }
    }

    
}

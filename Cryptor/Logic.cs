using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptor
{
    public class Logic
    {
        //Commenting code sounds like good idea, I guess.
        public static List<string> WriteBits(string fileName)
        {
            List<string> ret = new();
            using (FileStream stream = File.OpenRead(fileName))
            {
                byte[] buffer = new byte[1];
                
                int i = 0;
                int bytesRead = 0;

                do
                {
                    //reading file byte-by-byte
                    bytesRead = stream.Read(buffer, 0, buffer.Length);
                    if (bytesRead > 0)
                    {
                        //Converting whole byte into a string
                        ret.Add(Convert.ToString(buffer[0], 2).PadLeft(8, '0'));
                    }
                    i++;
                } while (bytesRead > 0);
            }
            return ret;
        }

    }
}

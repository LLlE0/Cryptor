using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptor
{
    internal class Logic
    {
        public static void WriteBits(string fileName)
        {
            using (FileStream stream = File.OpenRead(fileName))
            {
                byte[] buffer = new byte[1];
                int bytesRead = 0;

                do
                {
                    bytesRead = stream.Read(buffer, 0, buffer.Length);
                    if (bytesRead > 0)
                    {
                        Console.Write(Convert.ToString(buffer[0], 2).PadLeft(8, '0'));
                    }
                } while (bytesRead > 0);
            }
        }
    }
}

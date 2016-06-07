using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

class CopyBinaryFile
{
    static void Main(string[] args)
    {
        string path = Console.ReadLine();
        FileStream input = new FileStream(path, FileMode.Open);
        FileStream output = new FileStream("copiedFile"+Path.GetExtension(path), FileMode.Create);
        byte[] buffer = new byte[4096];
        int readBytes = 0;
        
        while (true)
        {
            readBytes = input.Read(buffer, 0, buffer.Length);
            if (readBytes == 0)
            {
                break;
            }
            output.Write(buffer, 0, readBytes);
        }
    }
}
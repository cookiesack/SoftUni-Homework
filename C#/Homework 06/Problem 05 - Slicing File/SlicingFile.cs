using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

class SlicingFile
{
    static void Slice(string sourceFile, string destinationDirectory, int parts)
    {
        FileStream input = new FileStream(sourceFile, FileMode.Open);
        for (int i = 0; i < parts; i++)
        {
            FileStream output = new FileStream(destinationDirectory + Path.GetFileNameWithoutExtension(sourceFile) + "-" + i + Path.GetExtension(sourceFile), FileMode.Create);
            byte[] buffer = new byte[input.Length / parts];
            int readBytes = 0;
            readBytes = input.Read(buffer, 0, buffer.Length);
            if (readBytes == 0)
            {
                break;
            }
            output.Write(buffer, 0, buffer.Length);
        }
        input.Close();
    }

    static void Assemble(List<string> files, string destinationDirectory)
    {
        FileStream output = new FileStream(destinationDirectory + Path.GetFileNameWithoutExtension(files[0]) + "-assembled" + Path.GetExtension(files[0]), FileMode.Create);
        for (int i = 0; i < files.Count; i++)
        {
            FileStream input = new FileStream(files[i], FileMode.Open);
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
            input.Close();
        }
        output.Close();
    }

    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        if (input == "slice" || input == "Slice")
        {
            for (int i = 0; i < args.Length; i++)
            {
                Slice(args[i], Console.ReadLine(), int.Parse(Console.ReadLine()));
            }
        }
        else if (input == "assemble" || input == "Assemble")
        {
            Assemble(args.ToList(), Console.ReadLine());
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

class LineNumbers
{
    static void Main(string[] args)
    {
        string path = Console.ReadLine();
        StreamReader input = new StreamReader(path);
        StreamWriter output = new StreamWriter("output.txt");
        string line = "";
        int count = 0;
        do
        {
            line = input.ReadLine();
            Console.WriteLine(count + " " + line);
            output.WriteLine(count + " " + line);
            count++;
        }
        while (line != null);
        input.Close();
        output.Close();
    }
}
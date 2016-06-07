using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

class OddLines
{
    static void Main(string[] args)
    {
        StreamReader input = new StreamReader("input.txt");
        string line = "";
        int counter = 0;
        do
        {
            line = input.ReadLine();
            if(counter%2==1) Console.WriteLine(line);
            counter++;
        }
        while (line!=null);
    }
}
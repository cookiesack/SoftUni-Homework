using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CountSymbols
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        List<char> symbols = new List<char>();
        int count = 1;
        for (int i = 0; i < input.Length; i++)
        {
            symbols.Add((char)input[i]);
        }
        symbols.Sort();
        symbols.Add('\0');
        for (int i = 0; i < symbols.Count-1; i++)
        {
            if (symbols[i] == symbols[i + 1]) count++;
            else
            {
                Console.WriteLine("{0}: {1} time/s", symbols[i], count);
                count = 1;
            }
        }
    }
}
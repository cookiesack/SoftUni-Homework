using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Phonebook
{
    static void Main(string[] args)
    {
        string input = "";
        List<string> names = new List<string>();
        List<string> numbers = new List<string>();

        while(input!="search")
        {
            input = Console.ReadLine();
            if (input == "search") break;
            names.Add(input.Substring(0, input.IndexOf('-')));
            numbers.Add(input.Substring(input.IndexOf('-')+1));
        }

        while (true)
        {
            input = Console.ReadLine();
            if (names.IndexOf(input) == -1) Console.WriteLine("Contact {0} does not exist.", input);
            else Console.WriteLine("{0} -> {1}", input, numbers[names.IndexOf(input)]);
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SeriesOfLetters
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        string pattern = @"(\w)\1+";
        System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(pattern);
        System.Text.RegularExpressions.MatchCollection matches = regex.Matches(input);
        for (int i = 0; i < matches.Count; i++)
        {
            input = regex.Replace(input, matches[i].ToString()[0].ToString(), 1, i);
        }
        Console.WriteLine(input);
    }
}
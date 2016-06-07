using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ExtractHyperlinks
{
    static void Main(string[] args)
    {
        string text = "";
        string input = Console.ReadLine();
        while (input != "END")
        {
            text += input;
            input = Console.ReadLine();
        }
        string pattern = @"(?<=\<a).*href.{5,}?(?=\u0160)?",
               pattern2 = @".*";
        System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(pattern),
                                             regex2 = new System.Text.RegularExpressions.Regex(pattern2);
        for (int i = 0; i < regex.Matches(text).Count; i++)
        {
            System.Text.RegularExpressions.Match match = regex.Matches(text)[i];
            Console.WriteLine(regex2.Match(match.ToString()));
        }
    }
}
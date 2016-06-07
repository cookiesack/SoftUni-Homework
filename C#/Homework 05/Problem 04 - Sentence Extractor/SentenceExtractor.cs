using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SentenceExtractor
{
    static void Main(string[] args)
    {
        string keyword = Console.ReadLine(),
               text = Console.ReadLine(),
               pattern = @"(?<=\! |\. |\?).* is .*(\!|\.) (?<=\!|\.|\?) |(?=\!|\.|\?)";
        System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(pattern);

        Console.WriteLine(regex.Matches(text)[1]);


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ReplaceTag
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        string pattern = @"\<a (href\=.*?)\>(.*?)\<\/a\>";
        System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(pattern);
        Console.WriteLine(regex.Replace(input, @"[URL " + regex.Matches(input)[0].Groups[1] + @"]" + regex.Matches(input)[0].Groups[2] + @"[/URL]"));
    }
}
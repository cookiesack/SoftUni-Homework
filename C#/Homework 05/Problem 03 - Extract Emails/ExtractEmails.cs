using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ExtractEmails
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        string pattern = @"\S+\@\w+(\.\w+)+";
        System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(pattern);
        System.Text.RegularExpressions.MatchCollection matches = regex.Matches(input);
        for (int i = 0; i < matches.Count; i++)
        {
            Console.WriteLine(matches[i]);
        }
    }
}
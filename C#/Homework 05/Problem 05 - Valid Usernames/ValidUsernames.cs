using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ValidUsernames
{
    static void Main(string[] args)
    {
        string pattern = @"^[a-z](\w)+$";
        System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(pattern);
        char[] separators = { ' ', '/', '\\', '(', ')' };
        List<string> input = Console.ReadLine().Split(separators, System.StringSplitOptions.RemoveEmptyEntries).ToList();

        for (int i = 0; i < input.Count; i++)
        {
            if (regex.IsMatch(input[i]) == false)
            {
                input[i] = "";
            }
        }
        int count = input.Count - 1;
        for (int i = count; i >= 0; i--)
        {
            if (input[i] == "")
            {
                input.RemoveAt(i);
            }
        }
        int maxIndex = 0,
            maxSum = 0;
        for (int i = 0; i < input.Count - 1; i++)
        {
            if (input[i].Length + input[i + 1].Length > maxSum)
            {
                maxIndex = i;
                maxSum = input[i].Length + input[i + 1].Length;
            }
        }

        Console.WriteLine(input[maxIndex]);
        Console.WriteLine(input[maxIndex+1]);
    }
}
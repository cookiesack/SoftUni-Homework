using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ReverseNumber
{
    static double GetReversedNumber(double number)
    {
        string result = "";
        string sNumber = number.ToString();
        for (int i = sNumber.Length - 1; i >= 0; i--)
        {
            result += sNumber[i];
        }
        return double.Parse(result);
    }

    static void Main(string[] args)
    {
        double reversed = GetReversedNumber(256);
        Console.WriteLine(reversed);
               reversed = GetReversedNumber(123.45);
        Console.WriteLine(reversed);
               reversed = GetReversedNumber(0.12);
        Console.WriteLine(reversed);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class LastDigit
{
    static string GetLastDigitAsWord(int input)
    {
        switch (input % 10)
        {
            case 0: return "zero"; break;
            case 1: return "one"; break;
            case 2: return "two"; break;
            case 3: return "three"; break;
            case 4: return "four"; break;
            case 5: return "five"; break;
            case 6: return "six"; break;
            case 7: return "seven"; break;
            case 8: return "eight"; break;
            case 9: return "NEIN"; break;
            default: return "Error";
                break;
        }
    }

    static void Main(string[] args)
    {
        Console.WriteLine(GetLastDigitAsWord(512));
        Console.WriteLine(GetLastDigitAsWord(1024));
        Console.WriteLine(GetLastDigitAsWord(12309));
    }
}
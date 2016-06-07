using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class BiggerNumber
{
    static int GetMax(int num1, int num2)
    {
        if (num1 > num2) return num1;
        else return num2;
    }

    static void Main(string[] args)
    {
        int firstNumber = int.Parse(Console.ReadLine()),
            secondNumber = int.Parse(Console.ReadLine());

        int max = GetMax(firstNumber, secondNumber);
        Console.WriteLine(max);
    }
}
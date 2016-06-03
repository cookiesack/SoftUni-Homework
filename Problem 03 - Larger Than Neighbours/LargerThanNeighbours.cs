using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class LargerThanNeighbours
{
    static bool IsLargerThanNeighbours(int[] numbers, int index)
    {
        if (index == 0)
        {
            if (numbers[0] > numbers[1]) return true;
            else return false;
        }
        else if (index == numbers.Length - 1)
        {
            if (numbers[numbers.Length - 1] > numbers[numbers.Length - 2]) return true;
            else return false;
        }
        else
        {
            if (numbers[index] > numbers[index - 1] && numbers[index] > numbers[index + 1]) return true;
            else return false;
        }
    }

    static void Main(string[] args)
    {
        int[] numbers = { 1, 3, 4, 5, 1, 0, 5 };

        for (int i = 0; i < numbers.Length; i++)
        {
            Console.WriteLine(IsLargerThanNeighbours(numbers, i));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class FirstLargerThanNeighbours
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

    static int GetIndexOfFirstElementLargerThanNeighbours(int[] numbers)
    {
        int result = -1;
        for (int i = 0; i < numbers.Length; i++)
        {
            if (IsLargerThanNeighbours(numbers, i) == true)
            {
                result = i;
                break;
            }
        }
        return result;
    }

    static void Main(string[] args)
    {
        int[] sequenceOne = { 1, 3, 4, 5, 1, 0, 5 };
        int[] sequenceTwo = { 1, 2, 3, 4, 5, 6, 6 };
        int[] sequenceThree = { 1, 1, 1 };

        Console.WriteLine(GetIndexOfFirstElementLargerThanNeighbours(sequenceOne));
        Console.WriteLine(GetIndexOfFirstElementLargerThanNeighbours(sequenceTwo));
        Console.WriteLine(GetIndexOfFirstElementLargerThanNeighbours(sequenceThree));
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class GenericArraySort
{
    static T[] SortArray<T> (T[] input)
    {
        List<T> sorted = input.ToList();
        sorted.Sort();
        for (int i = 0; i < input.Length; i++)
        {
            input[i] = sorted[i];
        }
        return input;
    }

    static void Main(string[] args)
    {
        int[] numbers = { 1, 3, 4, 5, 1, 0, 5 };
        string[] strings = { "zaz", "cba", "baa", "azis" };
        DateTime[] dates = { new DateTime(2002, 3, 1), new DateTime(2015, 5, 6), new DateTime(2014, 1, 1) };

        SortArray(numbers);
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write(numbers[i]+", ");
        }
        Console.WriteLine();

        SortArray(strings);
        for (int i = 0; i < strings.Length; i++)
        {
            Console.Write(strings[i] + ", ");
        }
        Console.WriteLine();

        SortArray(dates);
        for (int i = 0; i < dates.Length; i++)
        {
            Console.Write(dates[i] + ", ");
        }
        Console.WriteLine();
    }
}
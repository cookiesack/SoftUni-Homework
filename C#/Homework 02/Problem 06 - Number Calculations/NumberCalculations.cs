using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class NumberCalculations
{
    static double Min(double[] numbers)
    {
        double min = numbers[0];
        for (int i = 1; i < numbers.Length; i++)
        {
            if (numbers[i] < min)
            {
                min = numbers[i];
            }
        }
        return min;
    }
    static decimal Min(decimal[] numbers)
    {
        decimal min = numbers[0];
        for (int i = 1; i < numbers.Length; i++)
        {
            if (numbers[i] < min)
            {
                min = numbers[i];
            }
        }
        return min;
    }

    static double Max(double[] numbers)
    {
        double max = numbers[0];
        for (int i = 1; i < numbers.Length; i++)
        {
            if (numbers[i] > max)
            {
                max = numbers[i];
            }
        }
        return max;
    }
    static decimal Max(decimal[] numbers)
    {
        decimal max = numbers[0];
        for (int i = 1; i < numbers.Length; i++)
        {
            if (numbers[i] > max)
            {
                max = numbers[i];
            }
        }
        return max;
    }

    static double Sum(double[] numbers)
    {
        double sum = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            sum += numbers[i];
        }
        return sum;
    }
    static decimal Sum(decimal[] numbers)
    {
        decimal sum = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            sum += numbers[i];
        }
        return sum;
    }

    static double Avg(double[] numbers)
    {
        return Sum(numbers) / numbers.Length;
    }
    static decimal Avg(decimal[] numbers)
    {
        return Sum(numbers) / numbers.Length;
    }

    static double Product(double[] numbers)
    {
        double product = 1;
        for (int i = 0; i < numbers.Length; i++)
        {
            product *= numbers[i];
        }
        return product;
    }
    static decimal Product(decimal[] numbers)
    {
        decimal product = 1;
        for (int i = 0; i < numbers.Length; i++)
        {
            product *= numbers[i];
        }
        return product;
    }

    static void Main(string[] args)
    {
        double[] test1 = { 1, 2, 4, 6, 1, 0, 5 };
        Console.WriteLine(Min(test1));
        Console.WriteLine(Max(test1));
        Console.WriteLine(Sum(test1));
        Console.WriteLine(Avg(test1));
        Console.WriteLine(Product(test1));

        decimal[] test2 = { 1, 2, 4, 6, 1, 0, 5 };
        Console.WriteLine(Min(test2));
        Console.WriteLine(Max(test2));
        Console.WriteLine(Sum(test2));
        Console.WriteLine(Avg(test2));
        Console.WriteLine(Product(test2));
    }
}
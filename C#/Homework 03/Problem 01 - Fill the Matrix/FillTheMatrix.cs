using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class FillTheMatrix
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        int[,] matrix = new int[N, N];
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                matrix[i, j] = (i * N) + j + 1;
            }
        }
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                Console.Write(matrix[j, i].ToString().PadRight((N/10)*2+3));
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                if(j%2==0) Console.Write(matrix[j, i].ToString().PadRight((N / 10) * 2 + 3));
                else Console.Write(matrix[j, N-1-i].ToString().PadRight((N / 10) * 2 + 3));
            }
            Console.WriteLine();
        }
    }
}
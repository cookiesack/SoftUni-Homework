using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SequenceInMatrix
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        int N = int.Parse(input.Substring(0, input.IndexOf(" "))),
            M = int.Parse(input.Substring(input.IndexOf(" ")));
        string[][] matrix = new string[N][];
        int count = 1,
            max = 1;
        string sCount = "",
               sMax = "";
        for (int i = 0; i < N; i++)
        {
            matrix[i] = Console.ReadLine().Split(' ').ToArray();
        }
        for (int j = 0; j < N - 1; j++)
        {
            for (int k = 0; k < M - 1; k++)
            {
                for (int q = j, s = k; q < N - 1 && s < M - 1; q++, s++)
                {
                    if (matrix[q][s] == matrix[q + 1][s + 1])
                    {
                        count++;
                        sCount = matrix[q][s];
                    }
                    else break;
                }
                if (count > max)
                {
                    max = count;
                    sMax = sCount;
                }
                count = 1;
            }
        }
        for (int j = 0; j < N; j++)
        {
            for (int k = 0; k < M - 1; k++)
            {
                if (matrix[j][k] == matrix[j][k + 1])
                {
                    count++;
                    sCount = matrix[j][k];
                }
                else break;
            }
            if (count > max)
            {
                max = count;
                sMax = sCount;
            }
            count = 1;
        }
        for (int j = 0; j < M; j++)
        {
            for (int k = 0; k < N - 1; k++)
            {
                if (matrix[k][j] == matrix[k + 1][j])
                {
                    count++;
                    sCount = matrix[k][j];
                }
                else break;
            }
            if (count > max)
            {
                max = count;
                sMax = sCount;
            }
            count = 1;
        }
        for (int i = 0; i < max; i++)
        {
            if (i != max - 1) Console.Write(sMax + ", ");
            else Console.Write(sMax + " ");
        }
    }
}
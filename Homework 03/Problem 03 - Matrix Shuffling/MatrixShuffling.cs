using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MatrixShuffling
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        int N = int.Parse(input.Substring(0, input.IndexOf(" "))),
            M = int.Parse(input.Substring(input.IndexOf(" ")));
        string[][] matrix = new string[N][];
        for (int i = 0; i < N; i++)
        {
            matrix[i] = Console.ReadLine().Split(' ').ToArray();
        }
        string command = " ";
        List<int> coords = new List<int>();
        string temp;
        while (command != "END")
        {
            command = Console.ReadLine();
            if (command.IndexOf(' ') != -1)
            {
                coords = command.Substring(command.IndexOf(' ') + 1).Split(' ').Select(int.Parse).ToList();
                if (command.Substring(0, command.IndexOf(' ')) == "swap")
                {
                    if (coords[0] >= 0 &&
                        coords[0] < N &&
                        coords[1] >= 0 &&
                        coords[1] < M &&
                        coords[2] >= 0 &&
                        coords[2] < N &&
                        coords[3] >= 0 &&
                        coords[3] < M)
                    {
                        temp = matrix[coords[2]][coords[3]];
                        matrix[coords[2]][coords[3]] = matrix[coords[0]][coords[1]];
                        matrix[coords[0]][coords[1]] = temp;
                        for (int i = 0; i < N; i++)
                        {
                            for (int j = 0; j < M; j++)
                            {
                                Console.Write(matrix[i][j] + " ");
                            }
                            Console.WriteLine();
                        }
                    }
                    else Console.WriteLine("Invalid input!");
                }
                else Console.WriteLine("Invalid input!");
            }
            else if (command != "END") Console.WriteLine("Invalid input!");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_01___Find_the_Root
{
    class Program
    {
        static void Main(string[] args)
        {
            int nodes = Int32.Parse(Console.ReadLine());
            int edges = Int32.Parse(Console.ReadLine());
            int[] parents = new int[nodes];
            bool isTree = true;

            for (int i = 0; i < parents.Length; i++)
            {
                parents[i] = -1;
            }

            for (int i = 0; i < edges; i++)
            {
                string[] inputParts = Console.ReadLine().Split();

                int parent = Int32.Parse(inputParts[0]);
                int child = Int32.Parse(inputParts[1]);

                if (parents[child] != -1)
                {
                    isTree = false;
                }

                parents[child] = parent;
            }

            int root = -1;

            int rootCount = 0;
            for (int i = 0; i < parents.Length; i++)
            {
                if (parents[i] != -1) continue;
                rootCount++;
                root = i;
            }

            if (rootCount == 0)
            {
                Console.WriteLine("No root!");
                return;
            }
            else if (rootCount == 1)
            {
                Console.WriteLine(root);
            }
            else
            {
                Console.WriteLine("Multiple root nodes!");
            }
        }
    }
}

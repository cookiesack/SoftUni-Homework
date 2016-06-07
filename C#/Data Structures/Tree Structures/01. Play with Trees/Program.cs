using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Play_with_Trees
{
    static class Program
    {
        static void Main()
        {
            int nodesCount = Int32.Parse(Console.ReadLine());
            Tree<int> tree = new Tree<int>();

            for (int i = 0; i < nodesCount-1; i++)
            {
                string[] edge = Console.ReadLine().Split(' ');
                int father = Int32.Parse(edge[0]);
                int child = Int32.Parse(edge[1]);

                tree.AddChildTo(father, child);
            }

            int pathSum = Int32.Parse(Console.ReadLine());
            int subTreeSum = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Root node: {0}", tree.GetRoot());
            Console.WriteLine("Leaf nodes: {0}", String.Join(", ", tree.GetLeaves()));
            Console.WriteLine("Middle nodes: {0}", String.Join(", ", tree.GetMiddles()));

            Console.WriteLine("Longest path:");
            var longest = tree.FindLongestPath();
            Console.WriteLine("{0} (length = {1})",
                String.Join(" -> ", longest),
                longest.Length);

            Console.WriteLine("Paths of sum {0}:", pathSum);
            tree.FindPathsOfSum(pathSum).ForEach(p => Console.WriteLine(String.Join(" -> ", p)));

            Console.WriteLine("Subtrees of sum {0}:", subTreeSum);
            tree.FindSubTreeOfSum(subTreeSum).ForEach(p => Console.WriteLine(String.Join(" + ", p)));
        }
    }
}

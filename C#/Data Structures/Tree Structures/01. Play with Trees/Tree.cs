using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Play_with_Trees
{
    public class Tree<T>
    {
        private SortedDictionary<T, TreeNode<T>> valueMap;

        private TreeNode<T> Root { get; set; }

        public Tree()
        {
            this.valueMap = new SortedDictionary<T, TreeNode<T>>();
        }

        public void AddChildTo(T father, T child)
        {
            if (Root == null)
            {
                Root = new TreeNode<T>(father, new List<T>());
                valueMap[father] = Root;
            }

            if (!valueMap.ContainsKey(father))
            {
                valueMap[father] = new TreeNode<T>(father, new List<T>());
            }

            if (!valueMap.ContainsKey(child))
            {
                valueMap[child] = new TreeNode<T>(child, new List<T>());
            }

            valueMap[father].DirectChildren.Add(valueMap[child]);
        }

        public T GetRoot()
        {
            return Root.Value;
        }

        public T[] GetLeaves()
        {
            return valueMap.Values
                .Where(v => v.DirectChildren == null || v.DirectChildren.Count == 0)
                .Select(v => v.Value).ToArray();
        }

        public T[] GetMiddles()
        {
            return valueMap.Values
                .Where(v => v.DirectChildren != null && v.DirectChildren.Count > 0 && v != Root)
                .Select(v => v.Value).ToArray();
        }

        public int[] FindLongestPath()
        {

            if (!(typeof(T) == typeof(int))) return null;

            Stack<TreeNode<T>> nodesStack = new Stack<TreeNode<T>>();
            nodesStack.Push(Root);
            TreeNode<T>[] longestPathNodes = new TreeNode<T>[0];
            SearchLongestPath(nodesStack, ref longestPathNodes);

            return longestPathNodes
                .Select(n => n.Value)
                .Cast<int>()
                .ToArray();
        }

        public void SearchLongestPath(Stack<TreeNode<T>> currentNodes, ref TreeNode<T>[] longestPathNodes)
        {
            TreeNode<T> currentNode = currentNodes.Peek();
            if (currentNodes.Count > longestPathNodes.Length)
            {
                longestPathNodes = currentNodes
                    .Reverse()
                    .ToArray();
            }
            if (currentNode.DirectChildren == null || currentNode.DirectChildren.Count == 0)
            {
                return;
            }
            foreach (TreeNode<T> node in currentNode.DirectChildren)
            {
                currentNodes.Push(node);
                SearchLongestPath(currentNodes, ref longestPathNodes);
                currentNodes.Pop();
            }
        }

        public List<int[]> FindPathsOfSum(int sum)
        {
            if (!(typeof(T) == typeof(int))) return null;
            
            List<int[]> winningNumbers = new List<int[]>();
            StartSearchingFrom(Root, winningNumbers, sum);
            return winningNumbers;
        }

        /// <summary>
        /// Recursively calls SearchForSum with all nodes as starting points
        /// </summary>
        /// <param name="startNode"></param>
        /// <param name="winningNumbers"></param>
        /// <param name="desiredSum"></param>
        private void StartSearchingFrom(TreeNode<T> startNode, List<int[]> winningNumbers, int desiredSum)
        {
            Stack<int> current = new Stack<int>();
            SearchForSum(winningNumbers, current, startNode, desiredSum);
            
            foreach (TreeNode<T> child in startNode.DirectChildren)
            {
                StartSearchingFrom(child, winningNumbers, desiredSum);
            }
        }

        /// <summary>
        /// Starting at the starting currentNode, recursively adds child nodes and finds all collections, which sum is equal to the desired.
        /// </summary>
        /// <param name="winningNumbers"></param>
        /// <param name="currentNumbers"></param>
        /// <param name="currentNode"></param>
        /// <param name="desiredSum"></param>
        /// <returns></returns>
        private bool SearchForSum(List<int[]> winningNumbers, Stack<int> currentNumbers, TreeNode<T> currentNode, int desiredSum)
        {
            currentNumbers.Push(Convert.ToInt32(currentNode.Value)); // Push number from current node

            int currentSum = currentNumbers.Sum(); // Calculate current sum
            
            if (currentSum > desiredSum)
            {
                return false;
            }

            if (currentSum == desiredSum)
            {
                return true;
            }

            for (int i = 0; i < currentNode.DirectChildren.Count; i++)
            {
                if (SearchForSum(winningNumbers, currentNumbers, currentNode.DirectChildren[i], desiredSum))
                {
                    // If sum found

                    if (winningNumbers == null)
                    {
                        winningNumbers = new List<int[]>();
                    }
                    
                    winningNumbers.Add(
                        currentNumbers
                        .Reverse() // Stack -> Queue order
                        .ToArray());
                }
                currentNumbers.Pop(); // Remove last inserted value, we already used it in the search
            }
            return false; // If no child provides an appropriate sum, go back
        }

        public List<int[]> FindSubTreeOfSum(int sum)
        {
            List<int[]> winningNumbers = new List<int[]>();
            StartSearchingSubTreeFrom(Root, winningNumbers, sum);
            return winningNumbers;
        }

        /// <summary>
        /// Recursively calls StartSearchingSubTreeFrom with all nodes as starting points
        /// </summary>
        /// <param name="startNode"></param>
        /// <param name="winningNumbers"></param>
        /// <param name="desiredSum"></param>
        private void StartSearchingSubTreeFrom(TreeNode<T> startNode, List<int[]> winningNumbers, int desiredSum)
        {
            List<TreeNode<T>> subNodes = new List<TreeNode<T>>();
            GetAllSubNodesOf(startNode, subNodes);
            var currentNumbers = subNodes.Select(n => n.Value).Cast<int>().ToArray();

            int currentSum = currentNumbers.Sum();
            if (currentSum == desiredSum)
            {
                winningNumbers.Add(currentNumbers);
            }

            foreach (TreeNode<T> child in startNode.DirectChildren)
            {
                StartSearchingSubTreeFrom(child, winningNumbers, desiredSum);
            }
        }

        private void GetAllSubNodesOf(TreeNode<T> node, List<TreeNode<T>> subNodes)
        {
            subNodes.Add(node);
            foreach (TreeNode<T> treeNode in node.DirectChildren)
            {
                GetAllSubNodesOf(treeNode, subNodes);
            }
        }
    }
}

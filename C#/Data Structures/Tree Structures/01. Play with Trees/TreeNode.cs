using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Play_with_Trees
{
    public class TreeNode<T>
    {
        public T Value;

        public List<TreeNode<T>> DirectChildren;

        public TreeNode(T value, List<T> directChildren)
        {
            Value = value;
            DirectChildren = new List<TreeNode<T>>();
            foreach (T directChild in directChildren)
            {
                DirectChildren.Add(new TreeNode<T>(directChild, new List<T>()));
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Linked_Stack
{
    class StackNode<T>
    {
        public StackNode<T> previousNode;

        public T value;

        public StackNode(T value)
        {
            this.value = value;
        }
    }
}

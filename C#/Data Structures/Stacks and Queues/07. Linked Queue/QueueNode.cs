using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Linked_Queue
{
    class QueueNode<T>
    {
        public QueueNode<T> previousNode;
        public QueueNode<T> nextNode;
        public T value;

        public QueueNode(T value)
        {
            this.value = value;
        }
    }
}

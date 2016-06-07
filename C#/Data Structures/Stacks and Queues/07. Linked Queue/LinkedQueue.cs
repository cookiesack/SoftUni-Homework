using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Linked_Queue
{
    public class LinkedQueue<T>
    {
        private QueueNode<T> startNode;
        private QueueNode<T> endNode;

        public int Count { get; set; }

        public void Enqueue(T value)
        {
            if (Count == 0)
            {
                startNode = new QueueNode<T>(value);
                endNode = startNode;
            }
            else if (Count == 1)
            {
                endNode = new QueueNode<T>(value);
                endNode.previousNode = startNode;
                startNode.nextNode = endNode;
            }
            else
            {
                var newNode = new QueueNode<T>(value);

                endNode.nextNode = newNode;
                newNode.previousNode = endNode;
                endNode = newNode;
            }

            Count++;
        }

        public T Dequeue()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("There are no elements to dequeue.");
            }

            T value = startNode.value;

            if (Count != 1)
            {
                startNode = startNode.nextNode;
                startNode.previousNode = null;
            }

            Count--;
            return value;
        }

        public T[] ToArray()
        {
            QueueNode<T> currentNode = startNode;

            T[] array = new T[Count];
            for (int i = 0; i < Count; i++, currentNode = currentNode.nextNode)
            {
                array[i] = currentNode.value;
            }
            return array;
        }
    }
}

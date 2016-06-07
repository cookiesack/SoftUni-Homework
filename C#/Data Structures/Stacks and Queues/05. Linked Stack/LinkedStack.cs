using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Linked_Stack
{
    public class LinkedStack<T>
    {
        private StackNode<T> lastNode;

        public int Count { get; set; }

        public T Pop()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("There are no elements to pop.");
            }

            T lastValue = lastNode.value;
            lastNode = lastNode.previousNode;
            Count--;
            return lastValue;
        }

        public void Push(T value)
        {
            var newNode = new StackNode<T>(value);
            newNode.previousNode = lastNode;
            lastNode = newNode;
            Count++;
        }

        public T Peek()
        {
            return lastNode.value;
        }

        public T[] ToArray()
        {
            T[] array = new T[Count];
            StackNode<T> currentNode = lastNode;

            for (int index = 0; index < Count; index++, currentNode = currentNode.previousNode)
            {
                array[index] = currentNode.value;
            }
            return array;
        }
    }
}

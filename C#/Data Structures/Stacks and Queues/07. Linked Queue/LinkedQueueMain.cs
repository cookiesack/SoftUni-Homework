using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Linked_Queue
{
    class LinkedQueueMain
    {
        static void Main(string[] args)
        {
            LinkedQueue<int> numbersStack = new LinkedQueue<int>();
            numbersStack.Enqueue(3);
            numbersStack.Enqueue(6);
            numbersStack.Enqueue(4);
            numbersStack.Enqueue(8);
            numbersStack.Enqueue(9);
            numbersStack.Enqueue(10);
            numbersStack.Enqueue(24);
            Console.WriteLine(numbersStack.Dequeue());
            numbersStack.Enqueue(1);
            Console.WriteLine(String.Join(", ", numbersStack.ToArray()));
        }
    }
}

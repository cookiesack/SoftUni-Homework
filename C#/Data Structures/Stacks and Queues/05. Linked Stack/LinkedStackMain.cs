using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Linked_Stack
{
    static class LinkedStackMain
    {
        static void Main(string[] args)
        {
            LinkedStack<int> numbersStack = new LinkedStack<int>();
            numbersStack.Push(3);
            numbersStack.Push(6);
            numbersStack.Push(4);
            numbersStack.Push(8);
            numbersStack.Push(9);
            numbersStack.Push(10);
            numbersStack.Push(24);
            Console.WriteLine(numbersStack.Pop());
            numbersStack.Push(1);
            Console.WriteLine(String.Join(", ", numbersStack.ToArray()));
        }
    }
}

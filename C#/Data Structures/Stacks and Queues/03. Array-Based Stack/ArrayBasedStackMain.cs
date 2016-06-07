using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Array_Based_Stack
{
    class ArrayBasedStackMain
    {
        static void Main(string[] args)
        {
            ArrayBasedStack<int> numbersStack = new ArrayBasedStack<int>();
            numbersStack.Push(1);
            numbersStack.Push(2);
            numbersStack.Push(3);
            numbersStack.Push(4);
            numbersStack.Push(5);
            numbersStack.Push(1);
            numbersStack.Push(2);
            numbersStack.Push(3);
            numbersStack.Push(4);
            numbersStack.Push(5);
            numbersStack.Push(1);
            numbersStack.Push(2);
            numbersStack.Push(3);
            numbersStack.Push(4);
            numbersStack.Push(5);
            numbersStack.Push(1);
            numbersStack.Push(2);
            numbersStack.Push(3);
            numbersStack.Push(4);
            numbersStack.Push(5);

            foreach (int i in numbersStack)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }
}

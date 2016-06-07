using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Reverse_Numbers
{
    static class ReverseNumbers
    {
        static void Main(string[] args)
        {
            string[] sNumbers = Console.ReadLine().Split(' ');
            Stack<int> numbersStack = new Stack<int>();

            foreach (string t in sNumbers)
            {
                numbersStack.Push(Int32.Parse(t));
            }

            while (numbersStack.Count > 0)
            {
                Console.Write(numbersStack.Pop()+" ");
            }
        }
    }
}

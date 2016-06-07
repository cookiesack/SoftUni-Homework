using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Calculate_Sequence
{
    class CalculateSequence
    {
        static void Main(string[] args)
        {
            int n = Int32.Parse(Console.ReadLine());
            Queue<int> sequenceQueue = new Queue<int>();
            sequenceQueue.Enqueue(n);

            for (int i = 0; i < 50; i+=2)
            {
                int currentNumber = sequenceQueue.Dequeue();
                Console.Write(currentNumber + " ");

                sequenceQueue.Enqueue(currentNumber + 1);
                sequenceQueue.Enqueue(currentNumber * 2 + 1);
                sequenceQueue.Enqueue(currentNumber + 2);
            }
            Console.WriteLine();
        }
    }
}

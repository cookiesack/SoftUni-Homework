using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Sequence_NM
{
    static class SequenceNM
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ');
            int start = Int32.Parse(input[0]);
            int end = Int32.Parse(input[1]);

            if (end < start) return;

            Stack<Operation> operationStack = new Stack<Operation>();

            while (end != start)
            {
                if (end > start * 2) // If we can divide by 2
                {
                    if (end % 2 == 1) // Must be even to devide, so if it's not - subtract 1
                    {
                        operationStack.Push(Operation.PlusOne);
                        end--;
                    }

                    operationStack.Push(Operation.TimesTwo);
                    end /= 2;
                }

                else // If we CANNOT divide by 2 (end < start * 2)
                {
                    if (start % 2 != end % 2) // If they're not both even or both odd, make them by subracting 1
                    {
                        operationStack.Push(Operation.PlusOne);
                        end--;
                        continue; // e.g. start = 2, end = 3; end -> 2 so we don't need to subtract 2, they are equal, exit the loop
                    }

                    operationStack.Push(Operation.PlusTwo); // When they're both odd/even just keep subtracting 2 until they are equal
                    end -= 2;
                }
            }

            /*
             * Note! We can speed up this algorithm by printing the output directly in the loop above while calculating, but we would have to operate from start to end, or to insert at the beginning of a string:
             * 10 - 30
             * 30
             * 15 -> 30
             * 14 -> 15 -> 30
             * 12 -> 14 -> 15 -> 30
             * 10 -> 12 -> 14 -> 15 -> 30
             */

            Console.Write(start);
            while (operationStack.Count > 0)
            {
                Console.Write(" -> ");
                switch (operationStack.Pop()) // Perform the last operation on the start variable and print it
                {
                    case Operation.PlusOne:
                        start += 1;
                        break;
                    case Operation.PlusTwo:
                        start += 2;
                        break;
                    case Operation.TimesTwo:
                        start *= 2;
                        break;
                }
                Console.Write(start);
            }
            Console.WriteLine();
        }
    }
}

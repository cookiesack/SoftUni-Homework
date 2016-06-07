using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _07.Linked_Queue;

namespace _08.Linked_Queue_Tests
{
    [TestClass]
    public class LinkedQueueTests
    {
        [TestMethod]
        public void BasicEnqueueDequeueTest()
        {
            LinkedQueue<int> queue = new LinkedQueue<int>();
            Assert.AreEqual(0, queue.Count);

            queue.Enqueue(5);
            Assert.AreEqual(1, queue.Count);
            Assert.AreEqual(5, queue.Dequeue());
        }

        [TestMethod]
        public void EnqueueDequeue1000ElementsTest()
        {
            LinkedQueue<int> stack = new LinkedQueue<int>();
            Assert.AreEqual(0, stack.Count);

            for (int i = 1; i <= 1000; i++)
            {
                stack.Enqueue(i);
                Assert.AreEqual(i, stack.Count);
            }

            for (int i = 1; i <= 1000; i++)
            {
                int n = stack.Dequeue();
                Assert.AreEqual(i, n);
                Assert.AreEqual(1000-i, stack.Count);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void EmptyQueueDequeueTest()
        {
            LinkedQueue<int> queue = new LinkedQueue<int>();
            queue.Dequeue();
        }

        [TestMethod]
        public void ToArrayTest()
        {
            LinkedQueue<int> stack = new LinkedQueue<int>();
            stack.Enqueue(3);
            stack.Enqueue(4);
            stack.Enqueue(7);
            stack.Enqueue(8);
            stack.Enqueue(10);
            int[] testArray = {3, 4, 7, 8, 10};
            int[] array = stack.ToArray();
            CollectionAssert.AreEqual(array, testArray);
        }
    }
}

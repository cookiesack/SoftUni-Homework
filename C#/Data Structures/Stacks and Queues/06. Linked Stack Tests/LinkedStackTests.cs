using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _05.Linked_Stack;

namespace _08.Linked_Stack_Tests
{
    [TestClass]
    public class LinkedStackTests
    {
        [TestMethod]
        public void BasicPushPopTest()
        {
            LinkedStack<int> stack = new LinkedStack<int>();
            Assert.AreEqual(0, stack.Count);
            stack.Push(4);
            Assert.AreEqual(1, stack.Count);
            Assert.AreEqual(4, stack.Pop());
        }

        [TestMethod]
        public void PushPop1000ElementsTest()
        {
            LinkedStack<int> stack = new LinkedStack<int>();
            Assert.AreEqual(0, stack.Count);

            for (int i = 1; i <= 1000; i++)
            {
                stack.Push(i);
                Assert.AreEqual(i, stack.Count);
            }

            for (int i = 1000; i >= 1; i--)
            {
                int n = stack.Pop();
                Assert.AreEqual(i, n);
                Assert.AreEqual(i - 1, stack.Count);
            }
        }

        [TestMethod]
        public void PeekTest()
        {
            LinkedStack<int> stack = new LinkedStack<int>();
            stack.Push(4);
            Assert.AreEqual(4, stack.Peek());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void EmptyPopTest()
        {
            LinkedStack<int> stack = new LinkedStack<int>();
            stack.Pop();
        }


        [TestMethod]
        public void ToArrayTest()
        {
            LinkedStack<int> stack = new LinkedStack<int>();
            stack.Push(3);
            stack.Push(4);
            stack.Push(7);
            stack.Push(8);
            stack.Push(10);
            int[] testArray = { 10, 8, 7, 4, 3 };
            int[] array = stack.ToArray();
            CollectionAssert.AreEqual(array, testArray);
        }

        [TestMethod]
        public void EmptyToArrayTest()
        {
            LinkedStack<int> stack = new LinkedStack<int>();
            int[] testArray = { };
            int[] array = stack.ToArray();
            CollectionAssert.AreEqual(array, testArray);
        }
    }
}

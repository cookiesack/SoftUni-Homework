using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _03.Array_Based_Stack;

namespace _04.Array_Based_Stack_Tests
{
    [TestClass]
    public class ArrayBasedStackTest
    {
        [TestMethod]
        public void BasicPushPopTest()
        {
            ArrayBasedStack<int> stack = new ArrayBasedStack<int>();
            Assert.AreEqual(0, stack.Count);
            stack.Push(0);
            Assert.AreEqual(1, stack.Count);
            Assert.AreEqual(0, stack.Pop());
            Assert.AreEqual(0, stack.Count);
        }

        [TestMethod]
        public void PushPop1000ElementsTest()
        {
            ArrayBasedStack<int> stack = new ArrayBasedStack<int>();
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
                Assert.AreEqual(i-1, stack.Count);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PopFromEmptyStackTest()
        {
            ArrayBasedStack<int> stack = new ArrayBasedStack<int>();
            stack.Pop();
        }

        [TestMethod]
        public void PushPopInitialCapacity1Test()
        {
            ArrayBasedStack<int> stack = new ArrayBasedStack<int>();
            Assert.AreEqual(0, stack.Count);
            stack.Push(0);
            Assert.AreEqual(1, stack.Count);
            stack.Push(1);
            Assert.AreEqual(2, stack.Count);

            Assert.AreEqual(1, stack.Pop());
            Assert.AreEqual(1, stack.Count);
            Assert.AreEqual(0, stack.Pop());
            Assert.AreEqual(0, stack.Count);
        }

        [TestMethod]
        public void ToArrayTest()
        {
            ArrayBasedStack<int> stack = new ArrayBasedStack<int>();
            stack.Push(3);
            stack.Push(4);
            stack.Push(7);
            stack.Push(8);
            stack.Push(10);
            int[] testArray = {10, 8, 7, 4, 3};
            int[] array = stack.ToArray();
            CollectionAssert.AreEqual(array, testArray);
        }

        [TestMethod]
        public void EmptyToArrayTest()
        {
            ArrayBasedStack<int> stack = new ArrayBasedStack<int>();
            int[] testArray = {};
            int[] array = stack.ToArray();
            CollectionAssert.AreEqual(array, testArray);
        }

        [TestMethod]
        public void EnumerationTest()
        {
            ArrayBasedStack<int> stack = new ArrayBasedStack<int>();
            stack.Push(4);
            stack.Push(3);
            stack.Push(2);
            stack.Push(1);
            stack.Push(0);
            int[] testArray = { 0, 1, 2, 3, 4 };
            foreach (int i in stack)
            {
                Assert.AreEqual(i, testArray[i]);
            }
        }
    }
}

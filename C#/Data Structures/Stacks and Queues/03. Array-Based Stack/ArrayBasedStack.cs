using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Array_Based_Stack
{
    public class ArrayBasedStack<T> : IEnumerable<T> // <= bonus
    {
        public const int InitialCapacity = 16;

        private T[] _elements;

        public int Count { get; set; }

        public ArrayBasedStack(int capacity = InitialCapacity)
        {
            _elements = new T[capacity];
        }

        public void Push(T element)
        {
            if (_elements.Length == Count)
            {
                Grow();
            }

            _elements[Count] = element;
            Count++;
        }

        public T Pop()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("There are no elements to pop.");
            }

            Count--;
            return _elements[Count];
        }

        private void Grow()
        {
            T[] newArray = new T[_elements.Length * 2];
            Array.Copy(_elements, newArray, _elements.Length);
            _elements = newArray;
        }

        public T[] ToArray()
        {
            T[] array = new T[Count];
            for (int i = Count-1; i >= 0; i-- )
            {
                array[i] = _elements[Count - i - 1];
            }
            return array;
        }

        public IEnumerator<T> GetEnumerator()
        {
            while (Count > 0)
            {
                yield return Pop();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

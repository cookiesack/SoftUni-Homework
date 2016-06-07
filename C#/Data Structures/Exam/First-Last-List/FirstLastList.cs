using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class FirstLastList<T> : IFirstLastList<T>
    where T : IComparable<T>
{
    private List<T> elements = new List<T>();
    private OrderedBag<T> elementsOrdered = new OrderedBag<T>();

    public void Add(T newElement)
    {
        elements.Add(newElement);
        elementsOrdered.Add(newElement);
    }

    public int Count
    {
        get { return elements.Count; }
    }

    public IEnumerable<T> First(int count)
    {
        if (elements.Count < count) throw new ArgumentOutOfRangeException();
        return elements.Take(count);
    }

    public IEnumerable<T> Last(int count)
    {
        if (elements.Count < count) throw new ArgumentOutOfRangeException();
        List<T> elems = new List<T>(elements);
        elems.Reverse();
        return elems.Take(count);
    }

    public IEnumerable<T> Min(int count)
    {
        if (elements.Count < count) throw new ArgumentOutOfRangeException();
        return elementsOrdered.OrderBy(x => elementsOrdered.IndexOf(x)).ThenBy(x => elements.IndexOf(x)).Take(count);
    }

    public IEnumerable<T> Max(int count)
    {
        if (elements.Count < count) throw new ArgumentOutOfRangeException();
        return elementsOrdered.Reversed().OrderByDescending(x=>elementsOrdered.IndexOf(x)).ThenBy(x=>elements.IndexOf(x)).Take(count);
    }

    public int RemoveAll(T element)
    {
        int count = elementsOrdered.NumberOfCopies(element);
        elements.RemoveAll(x => x.Equals(element));
        elementsOrdered.RemoveAllCopies(element);
        return count;
    }

    public void Clear()
    {
        elements.Clear();
        elementsOrdered.Clear();
    }
}

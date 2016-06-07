namespace IntervalTree
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Wintellect.PowerCollections;

    public enum StubMode
    {
        Contains,
        ContainsStart,
        ContainsStartThenEnd
    }

    public class IntervalTree<TKey, TValue> where TValue : struct, IComparable<TValue>
    {
        private IntervalNode<TKey, TValue> head;
        private List<Interval<TKey, TValue>> intervalList;
        private bool inSync;
        private int size;

        public IntervalTree()
        {
            this.head = new IntervalNode<TKey, TValue>();
            this.intervalList = new List<Interval<TKey, TValue>>();
            this.inSync = true;
            this.size = 0;
        }

        public IntervalTree(List<Interval<TKey, TValue>> intervalList)
        {
            this.head = new IntervalNode<TKey, TValue>(intervalList);
            this.intervalList = new List<Interval<TKey, TValue>>();
            this.intervalList.AddRange(intervalList);
            this.inSync = true;
            this.size = intervalList.Count;
        }

        public List<TKey> Get(TValue time)
        {
            return this.Get(time, StubMode.Contains);
        }

        public List<TKey> Get(TValue time, StubMode mode)
        {
            List<Interval<TKey, TValue>> intervals = this.GetIntervals(time, mode);
            List<TKey> result = new List<TKey>();
            foreach (Interval<TKey, TValue> interval in intervals)
                result.Add(interval.Data);
            return result;
        }

        public List<Interval<TKey, TValue>> GetIntervals(TValue time)
        {
            return GetIntervals(time, StubMode.Contains);
        }

        public List<Interval<TKey, TValue>> GetIntervals(TValue time, StubMode mode)
        {
            Build();

            List<Interval<TKey, TValue>> stubedIntervals;

            switch (mode)
            {
                case StubMode.Contains:
                    stubedIntervals = head.Stab(time, ContainConstrains.None);
                    break;
                case StubMode.ContainsStart:
                    stubedIntervals = head.Stab(time, ContainConstrains.IncludeStart);
                    break;
                case StubMode.ContainsStartThenEnd:
                    stubedIntervals = head.Stab(time, ContainConstrains.IncludeStart);
                    if (stubedIntervals.Count == 0)
                    {
                        stubedIntervals = head.Stab(time, ContainConstrains.IncludeEnd);
                    }
                    break;
                default:
                    throw new ArgumentException("Invalid StubMode " + mode, "mode");
            }

            return stubedIntervals;
        }

        public List<TKey> Get(TValue start, TValue end)
        {
            List<Interval<TKey, TValue>> intervals = GetIntervals(start, end);
            List<TKey> result = new List<TKey>();
            foreach (Interval<TKey, TValue> interval in intervals)
                result.Add(interval.Data);
            return result;
        }

        public List<Interval<TKey, TValue>> GetIntervals(TValue start, TValue end)
        {
            Build();
            return head.Query(new Interval<TKey, TValue>(start, end, default(TKey)));
        }

        public void AddInterval(Interval<TKey, TValue> interval)
        {
            intervalList.Add(interval);
            inSync = false;
        }

        public void AddInterval(TValue begin, TValue end, TKey data)
        {
            intervalList.Add(new Interval<TKey, TValue>(begin, end, data));
            inSync = false;
        }

        public bool IsInSync()
        {
            return inSync;
        }

        public void Build()
        {
            if (!inSync)
            {
                head = new IntervalNode<TKey, TValue>(intervalList);
                inSync = true;
                size = intervalList.Count;
            }
        }

        public int CurrentSize
        {
            get
            {
                return size;
            }
        }

        public int ListSize
        {
            get
            {
                return intervalList.Count;
            }
        }

        public IEnumerable<ICollection<Interval<TKey, TValue>>> GetIntersections()
        {
            Build();

            Queue<IntervalNode<TKey, TValue>> toVisit = new Queue<IntervalNode<TKey, TValue>>();
            toVisit.Enqueue(head);

            do
            {
                var node = toVisit.Dequeue();
                foreach (var intersection in node.Intersections)
                {
                    yield return intersection;
                }

                if (node.Left != null) toVisit.Enqueue(node.Left);
                if (node.Right != null) toVisit.Enqueue(node.Right);

            } while (toVisit.Count > 0);
        }

        public IList<Interval<TKey, TValue>> Intervals
        {
            get
            {
                return Algorithms.ReadOnly(intervalList);
            }
        }

        public override string ToString()
        {
            return NodeString(head, 0);
        }

        private string NodeString(IntervalNode<TKey, TValue> node, int level)
        {
            if (node == null)
                return "";

            var sb = new StringBuilder();
            for (int i = 0; i < level; i++)
                sb.Append("\t");
            sb.Append(node + "\n");
            sb.Append(NodeString(node.Left, level + 1));
            sb.Append(NodeString(node.Right, level + 1));
            return sb.ToString();
        }
    }
}

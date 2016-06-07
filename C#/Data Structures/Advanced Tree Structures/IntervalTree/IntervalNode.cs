namespace IntervalTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Wintellect.PowerCollections;
    
    public class IntervalNode<TKey, TValue> where TValue : struct, IComparable<TValue>
    {
        private OrderedDictionary<Interval<TKey, TValue>, List<Interval<TKey, TValue>>> intervals;
        private TValue center;
        private IntervalNode<TKey, TValue> leftNode;
        private IntervalNode<TKey, TValue> rightNode;

        public IntervalNode()
        {
            this.intervals = new OrderedDictionary<Interval<TKey, TValue>, List<Interval<TKey, TValue>>>();
            this.center = default(TValue);
            this.leftNode = null;
            this.rightNode = null;
        }

        public IntervalNode(List<Interval<TKey, TValue>> intervalList)
        {
            this.intervals = new OrderedDictionary<Interval<TKey, TValue>, List<Interval<TKey, TValue>>>();

            var endpoints = new OrderedSet<TValue>();

            foreach (var interval in intervalList)
            {
                endpoints.Add(interval.Start);
                endpoints.Add(interval.End);
            }

            Nullable<TValue> median = this.GetMedian(endpoints);
            this.center = median.GetValueOrDefault();

            List<Interval<TKey, TValue>> left = new List<Interval<TKey, TValue>>();
            List<Interval<TKey, TValue>> right = new List<Interval<TKey, TValue>>();

            foreach (Interval<TKey, TValue> interval in intervalList)
            {
                if (interval.End.CompareTo(this.center) < 0)
                {
                    left.Add(interval);
                }
                else if (interval.Start.CompareTo(this.center) > 0)
                {
                    right.Add(interval);
                }
                else
                {
                    List<Interval<TKey, TValue>> posting;
                    if (!this.intervals.TryGetValue(interval, out posting))
                    {
                        posting = new List<Interval<TKey, TValue>>();
                        this.intervals.Add(interval, posting);
                    }

                    posting.Add(interval);
                }
            }

            if (left.Count > 0)
            {
                this.leftNode = new IntervalNode<TKey, TValue>(left);
            }

            if (right.Count > 0)
            {
                this.rightNode = new IntervalNode<TKey, TValue>(right);
            }
        }

        public TValue Center
        {
            get { return this.center; }
            set { this.center = value; }
        }

        public IntervalNode<TKey, TValue> Left
        {
            get { return this.leftNode; }
            set { this.leftNode = value; }
        }

        public IntervalNode<TKey, TValue> Right
        {
            get { return this.rightNode; }
            set { this.rightNode = value; }
        }

        public IEnumerable<IList<Interval<TKey, TValue>>> Intersections
        {
            get
            {
                if (this.intervals.Count == 0)
                {
                    yield break;
                }
                else if (this.intervals.Count == 1)
                {
                    if (this.intervals.First().Value.Count > 1)
                    {
                        yield return this.intervals.First().Value;
                    }
                }
                else
                {
                    var keys = this.intervals.Keys.ToArray();

                    int lastIntervalIndex = 0;
                    List<Interval<TKey, TValue>> intersectionsKeys = new List<Interval<TKey, TValue>>();
                    for (int index = 1; index < this.intervals.Count; index++)
                    {
                        var intervalKey = keys[index];
                        if (intervalKey.Intersects(keys[lastIntervalIndex]))
                        {
                            if (intersectionsKeys.Count == 0)
                            {
                                intersectionsKeys.Add(keys[lastIntervalIndex]);
                            }

                            intersectionsKeys.Add(intervalKey);
                        }
                        else
                        {
                            if (intersectionsKeys.Count > 0)
                            {
                                yield return this.GetIntervalsOfKeys(intersectionsKeys);
                                intersectionsKeys = new List<Interval<TKey, TValue>>();
                                index--;
                            }
                            else
                            {
                                if (this.intervals[intervalKey].Count > 1)
                                {
                                    yield return this.intervals[intervalKey];
                                }
                            }

                            lastIntervalIndex = index;
                        }
                    }

                    if (intersectionsKeys.Count > 0)
                    {
                        yield return this.GetIntervalsOfKeys(intersectionsKeys);
                    }
                }
            }
        }

        private string Debug
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                foreach (var key in this.intervals.Keys)
                {
                    sb.AppendLine(key.ToString());
                    sb.AppendLine("==");
                    foreach (var val in this.intervals[key])
                    {
                        sb.AppendLine(val.ToString());
                        sb.AppendLine("--");
                    }

                    sb.AppendLine("***");
                }

                return sb.ToString();
            }
        }

        public List<Interval<TKey, TValue>> Stab(TValue time, ContainConstrains constraint)
        {
            List<Interval<TKey, TValue>> result = new List<Interval<TKey, TValue>>();

            foreach (var entry in this.intervals)
            {
                if (entry.Key.Contains(time, constraint))
                {
                    foreach (var interval in entry.Value)
                    {
                        result.Add(interval);
                    }
                }
                else if (entry.Key.Start.CompareTo(time) > 0)
                {
                    break;
                }
            }

            if (time.CompareTo(this.center) < 0 && this.leftNode != null)
            {
                result.AddRange(this.leftNode.Stab(time, constraint));
            }
            else if (time.CompareTo(this.center) > 0 && this.rightNode != null)
            {
                result.AddRange(this.rightNode.Stab(time, constraint));
            }

            return result;
        }

        public List<Interval<TKey, TValue>> Query(Interval<TKey, TValue> target)
        {
            List<Interval<TKey, TValue>> result = new List<Interval<TKey, TValue>>();

            foreach (var entry in this.intervals)
            {
                if (entry.Key.Intersects(target))
                {
                    foreach (Interval<TKey, TValue> interval in entry.Value)
                    {
                        result.Add(interval);
                    }
                }
                else if (entry.Key.Start.CompareTo(target.End) > 0)
                {
                    break;
                }
            }

            if (target.Start.CompareTo(this.center) < 0 && this.leftNode != null)
            {
                result.AddRange(this.leftNode.Query(target));
            }

            if (target.End.CompareTo(this.center) > 0 && this.rightNode != null)
            {
                result.AddRange(this.rightNode.Query(target));
            }

            return result;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(this.center + ": ");
            foreach (var entry in this.intervals)
            {
                sb.Append("[" + entry.Key.Start + "," + entry.Key.End + "]:{");
                foreach (Interval<TKey, TValue> interval in entry.Value)
                {
                    sb.Append("(" + interval.Start + "," + interval.End + "," + interval.Data + ")");
                }

                sb.Append("} ");
            }

            return sb.ToString();
        }

        private List<Interval<TKey, TValue>> GetIntervalsOfKeys(List<Interval<TKey, TValue>> intervalKeys)
        {
            var allIntervals =
              from k in intervalKeys
              select this.intervals[k];

            return allIntervals.SelectMany(x => x).ToList();
        }

        private Nullable<TValue> GetMedian(OrderedSet<TValue> set)
        {
            int i = 0;
            int middle = set.Count / 2;
            foreach (TValue point in set)
            {
                if (i == middle)
                {
                    return point;
                }

                i++;
            }

            return null;
        }
    }
}
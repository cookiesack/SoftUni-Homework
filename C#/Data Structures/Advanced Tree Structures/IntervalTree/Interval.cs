namespace IntervalTree
{
    using System;

    public enum ContainConstrains
    {
        None,
        IncludeStart,
        IncludeEnd,
        IncludeStartAndEnd
    }

    public class Interval<TKey, TValue> : IComparable<Interval<TKey, TValue>> where TValue : IComparable<TValue>
    {
        private TValue start;
        private TValue end;
        private TKey data;

        public Interval(TValue start, TValue end, TKey data)
        {
            this.start = start;
            this.end = end;
            this.data = data;
        }

        public TValue Start
        {
            get { return this.start; }
            set { this.start = value; }
        }

        public TValue End
        {
            get { return this.end; }
            set { this.end = value; }
        }

        public TKey Data
        {
            get { return this.data; }
            set { this.data = value; }
        }

        public bool Contains(TValue time, ContainConstrains constraint)
        {
            bool isContained;

            switch (constraint)
            {
                case ContainConstrains.None:
                    isContained = this.Contains(time);
                    break;
                case ContainConstrains.IncludeStart:
                    isContained = this.ContainsWithStart(time);
                    break;
                case ContainConstrains.IncludeEnd:
                    isContained = this.ContainsWithEnd(time);
                    break;
                case ContainConstrains.IncludeStartAndEnd:
                    isContained = this.ContainsWithStartEnd(time);
                    break;
                default:
                    throw new ArgumentException("Invalid constraint " + constraint);
            }

            return isContained;
        }

        public bool Contains(TValue time)
        {
            return time.CompareTo(this.end) < 0 && time.CompareTo(this.start) > 0;
        }

        public bool ContainsWithStart(TValue time)
        {
            return time.CompareTo(this.end) < 0 && time.CompareTo(this.start) >= 0;
        }

        public bool ContainsWithEnd(TValue time)
        {
            return time.CompareTo(this.end) <= 0 && time.CompareTo(this.start) > 0;
        }

        public bool ContainsWithStartEnd(TValue time)
        {
            return time.CompareTo(this.end) <= 0 && time.CompareTo(this.start) >= 0;
        }

        public bool Intersects(Interval<TKey, TValue> other)
        {
            return other.End.CompareTo(this.start) > 0 && other.Start.CompareTo(this.end) < 0;
        }

        public int CompareTo(Interval<TKey, TValue> other)
        {
            if (this.start.CompareTo(other.Start) < 0)
            {
                return -1;
            }
            else if (this.start.CompareTo(other.Start) > 0)
            {
                return 1;
            }
            else if (this.end.CompareTo(other.End) < 0)
            {
                return -1;
            }
            else if (this.end.CompareTo(other.End) > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}-{1}", this.start, this.end);
        }
    }
}

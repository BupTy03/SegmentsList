using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace SegmentsList
{
    class SegmentsList<TKey, TValue> where TKey : IComparable
    {
        public SegmentsList()
        {           
        }

        public bool Add(TKey lowerBound, TValue value)
        {
            var segment = new Segment(lowerBound, value);
            int index = m_data.BinarySearch(segment, new SegmentComp());
            if(index >= 0)
                return false;

            index = ~index;
            m_data.Insert(index, segment);
            return true;
        }

        public TValue this[TKey lowerBound] { 
            get 
            {
                if (m_data.Count == 0)
                    throw new IndexOutOfRangeException();

                var segment = new Segment(lowerBound, default(TValue));
                int index = m_data.BinarySearch(segment, new SegmentComp());
                if (index >= 0)
                    return m_data[index].Value;

                index = ~index;
                return m_data[index - 1].Value;
            }
        }

        private struct Segment
        {
            public Segment(TKey lowerBound, TValue value)
            {
                LowerBound = lowerBound;
                Value = value;
            }

            public TKey LowerBound { get; }
            public TValue Value { get; }
        }

        private class SegmentComp : IComparer<Segment>
        {
            public int Compare([AllowNull] Segment x, [AllowNull] Segment y)
            {
                return x.LowerBound.CompareTo(y.LowerBound);
            }
        }

        private List<Segment> m_data = new List<Segment>();
    }
}

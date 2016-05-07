using System;
using System.Collections.Generic;
using System.Text;

namespace ShortestCycleDirGraph.Core
{
    public class Cycle : IComparable<Cycle>
    {
        public List<Vertex<int>> Sequence { get; }

        public Cycle()
        {
            Sequence = new List<Vertex<int>>();
        }

        public int Length => Sequence.Count - 1;
       
        public int CompareTo(Cycle other)
        {
            if (other.Length < Length) return 1;
            else if (other.Length > Length) return -1;
            else return 0;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var vertex in Sequence)
            {
                sb.Append(vertex.Value.ToString() + " ");
            }
            return sb.ToString();
        }
    }
}
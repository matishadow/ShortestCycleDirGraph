using System.Collections.Generic;
using System.Linq;

namespace ShortestCycleDirGraph.Core
{
    public class Graph<T>
    {
        public Graph()
        {
            VertexSet = new List<Vertex<T>>();
        }

        public int EdgeCount
        {
            get { return VertexSet.Sum(vertex => vertex.Adjacents.Count); }
        }


        public List<Vertex<T>> VertexSet { get; }
    }
}
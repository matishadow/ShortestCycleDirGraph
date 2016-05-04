using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

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
	        get
	        {
	            return VertexSet.Sum(vertex => vertex.Adjacents.Count);
	        }
	    }

		public Vertex<T> Head { get; set; }
		public List<Vertex<T>> VertexSet { get; }

		
	}
}
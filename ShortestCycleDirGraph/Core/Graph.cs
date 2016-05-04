using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ShortestCycleDirGraph.Core
{
	public class Graph<T>
	{

		public Graph()
		{
			VertexSet = new List<Vertex<T>>();
		}


		public Vertex<T> Head { get; set; }
		public List<Vertex<T>> VertexSet { get; }

		
	}
}
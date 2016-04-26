using System;
using System.Collections.Generic;

namespace ShortestCycleDirGraph.Core
{
	public class Vertex<T> : IEquatable<Vertex<T>>
	{
		public T Value { get; set; }

		public List<Vertex<T>> Adjacents { get; }

		public Vertex(T value)
		{
			Value = value;
			Adjacents = new List<Vertex<T>>();


		}

		public bool Equals(Vertex<T> other)
		{
			return Value.Equals(other.Value);
		}
	}
}
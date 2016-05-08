using System.Text;

namespace ShortestCycleDirGraph.Core
{
    public class GraphExporting
    {
        //checked
        public static sbyte[,] ToAdjMatrix(Graph<int> graph)
        {
            int vertexCount = graph.VertexSet.Count;
            var adjMatrix = new sbyte[vertexCount, vertexCount];

            foreach (var vertex in graph.VertexSet)
            {
                foreach (var adjVertex in vertex.Adjacents)
                {
                    adjMatrix[vertex.Value - 1, adjVertex.Value - 1] = 1;
                }
            }

            return adjMatrix;
        }

        //checked
        public static sbyte[,] ToIncMatrix(Graph<int> graph)
        {
            int vertexCount = graph.VertexSet.Count;
            int edgeCount = graph.EdgeCount;

            var incMatrix = new sbyte[vertexCount, edgeCount];

            int currentEdge = 0;
            foreach (var vertex in graph.VertexSet)
            {
                foreach (var adjVertex in vertex.Adjacents)
                {
                    incMatrix[vertex.Value - 1, currentEdge] = -1;
                    incMatrix[adjVertex.Value - 1, currentEdge] = 1;

                    currentEdge++;
                }
            }

            return incMatrix;
        }

        //checked
        public static string ToEdgeSet(Graph<int> graph)
        {
            var sb = new StringBuilder();

            foreach (var vertex in graph.VertexSet)
            {
                foreach (var adjVertex in vertex.Adjacents)
                {
                    sb.Append($"{vertex.Value}->{adjVertex.Value}, ");
                }
            }


            return sb.ToString().Substring(0, sb.Length - 2);
        }
    }
}
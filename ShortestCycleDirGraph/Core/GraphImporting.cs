using System.Text.RegularExpressions;
using ShortestCycleDirGraph.Pages.Input;

namespace ShortestCycleDirGraph.Core
{
    public class GraphImporting
    {
        // TODO: generic values
        // checked
        public static Graph<int> FromAdjMatrix(sbyte[,] adjMatrix)
        {
            var graph = new Graph<int>();

            int size = adjMatrix.GetLength(0);

            for (int i = 0; i < size; i++) { graph.VertexSet.Add(new Vertex<int>(i + 1)); }
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (adjMatrix[i, j] == 1) graph.VertexSet[i].Adjacents.Add(graph.VertexSet[j]);
                }
            }
            return graph;
        }

        //checked
        public static Graph<int> FromIncMatrix(sbyte[,] incMatrix)
        {
            // invalid form of matrix
            if (!Matrix<int>.CheckValidIncMatrix(incMatrix)) incMatrix = Matrix<sbyte>.Transpose(incMatrix);

            var graph = new Graph<int>();
            for (int i = 0; i < incMatrix.GetLength(0); i++) { graph.VertexSet.Add(new Vertex<int>(i + 1)); }

            for (int i = 0; i < incMatrix.GetLength(1); i++)
            {
                for (int j = 0; j < incMatrix.GetLength(0); j++)
                {
                    if (incMatrix[j, i] != 1) continue;
                    for (int k = 0; k < incMatrix.GetLength(0); k++)
                    {
                        if (incMatrix[k, i] == -1) graph.VertexSet[k].Adjacents.Add(graph.VertexSet[j]);
                    }
                }
            }

            return graph;
        }

        //checked
        public static Graph<int> FromEdgeSet(string edgeSet)
        {
            var graph = new Graph<int>();

            string edge1 = Regex.Replace(edgeSet, "\n", ""); //TODO: simplify
            var edges = Regex.Replace(edge1, " ", "").Split(',');

            foreach (string t1 in edges)
            {
                var edge = Regex.Split(t1, "->");
                foreach (string t in edge)
                {
                    var v = new Vertex<int>(int.Parse(t));
                    if (!graph.VertexSet.Contains(v))
                        graph.VertexSet.Add(v);
                }
            }
            if (graph.VertexSet.Count != Input.VertexCount)
            {
                for (int i = 0; i < Input.VertexCount; i++)
                {
                    var v = new Vertex<int>(i+1);
                    if (!graph.VertexSet.Contains(v))
                        graph.VertexSet.Add(v);
                }
            }

            foreach (string t in edges)
            {
                var edge = Regex.Split(t, "->");

                Vertex<int> left = null, right = null;
                foreach (var t1 in graph.VertexSet)
                {
                    if (int.Parse(edge[0]) == t1.Value) left = t1;
                    if (int.Parse(edge[1]) == t1.Value) right = t1;
                }
                left?.Adjacents.Add(right);
            }

            return graph;
        }
    }
}
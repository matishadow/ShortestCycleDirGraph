using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using ShortestCycleDirGraph.Core;

namespace ShortestCycleDirGraph.Pages.Alg
{
    /// <summary>
    /// Interaction logic for Alg.xaml
    /// </summary>
    public partial class Alg : UserControl
    {
        public Alg()
        {
            InitializeComponent();
        }

        private Cycle FindShortestCycle(Graph<int> graph, Vertex<int> startingVertex)
        {
            var queue = new Queue<Vertex<int>>();

            foreach (var vertex in graph.VertexSet)
            {
                vertex.Distance = -1; //as if inf
                vertex.Parent = null;
            }

            startingVertex.Distance = 0;

            queue.Enqueue(startingVertex);
            while (queue.Count != 0)
            {
                var current = queue.Dequeue();

                foreach (var adjVertex in current.Adjacents)
                {
                    // adjVertex.Distance == 0      to get cycle
                    if (adjVertex.Distance == -1 || adjVertex.Distance == 0)
                    {
                        adjVertex.Distance = current.Distance + 1;
                        adjVertex.Parent = current;
                        queue.Enqueue(adjVertex);
                    }
                }
            }


            if (startingVertex.Parent == null) // cycle not found
            {
                return null;
            }
            else
            {
                var cycle = new Cycle();

                var current = startingVertex;
                while (current.Parent != startingVertex)
                {
                    cycle.Sequence.Add(current);
                    current = current.Parent;
                }
                cycle.Sequence.Add(startingVertex); //to end cycle

                return cycle;
            }
        }
    }
}

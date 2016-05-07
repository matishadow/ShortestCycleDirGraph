using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
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
using FirstFloor.ModernUI.Windows;
using Microsoft.Msagl.Drawing;
using ShortestCycleDirGraph.Core;
using FragmentNavigationEventArgs = FirstFloor.ModernUI.Windows.Navigation.FragmentNavigationEventArgs;
using NavigatingCancelEventArgs = FirstFloor.ModernUI.Windows.Navigation.NavigatingCancelEventArgs;
using NavigationEventArgs = FirstFloor.ModernUI.Windows.Navigation.NavigationEventArgs;

namespace ShortestCycleDirGraph.Pages.Alg
{
    /// <summary>
    /// Interaction logic for Alg.xaml
    /// </summary>
    public partial class Alg : UserControl, IContent
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
                do
                {
                    cycle.Sequence.Add(current);
                    current = current.Parent;
                } while (current != startingVertex);
                

                cycle.Sequence.Add(startingVertex); //to end cycle

                return cycle;
            }
        }

        public void OnFragmentNavigation(FragmentNavigationEventArgs e)
        {
            
        }

        public void OnNavigatedFrom(NavigationEventArgs e)
        {
            
        }

        public void OnNavigatedTo(NavigationEventArgs e)
        {
            var g = Models.GraphModel.Graph;
            if (g != null && g.EdgeCount != 0)
            {
                AlgTitle.Text = "Wynik algorytmu";

                var cycles = new List<Cycle>();
                foreach (var vertex in g.VertexSet)
                {
                    var cycle = FindShortestCycle(g, vertex);
                    if (cycle != null) cycles.Add(cycle);
                }

                var shortestCycle = cycles.Min();

                DrawResult(shortestCycle);
            }
            else AlgTitle.Text = "Najpierw trzeba wprowadzić graf!";          
        }

        public void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
           
        }

        private void DrawResult(Cycle shortestCycle)
        {
            const int bitmapSize = 450;
            var blackColour = new Microsoft.Msagl.Drawing.Color(37, 37, 38);
            var grayColour = new Microsoft.Msagl.Drawing.Color(193, 193, 193);
            var yellowColour = new Microsoft.Msagl.Drawing.Color(0xe3, 0xc8, 0x0);

            var g = Models.GraphModel.Graph;

            var graph = new Graph("graph");

            //put Nodes
            foreach (var vertex in g.VertexSet)
            {
                graph.AddNode(vertex.Value.ToString());
            }
            //put Edges
            foreach (var vertex in g.VertexSet)
            {
                foreach (var adjVertex in vertex.Adjacents)
                {
                    graph.AddEdge(vertex.Value.ToString(), "", adjVertex.Value.ToString());
                }
            }

            var renderer = new Microsoft.Msagl.GraphViewerGdi.GraphRenderer(graph);
            var bitmap = new System.Drawing.Bitmap(bitmapSize, bitmapSize);

            //color nodes and edges
            foreach (var edge in graph.Edges)
            {
                if(CycleContainsEdge(shortestCycle, edge)) // yellow shortest cycle
                {
                    edge.Attr.Color = yellowColour;
                }   
                else edge.Attr.Color = grayColour;
            }
            for (int i = 0; i < g.VertexSet.Count; i++)
            {
                var vertex = graph.FindNode(Convert.ToString(i + 1));
                if (shortestCycle != null && shortestCycle.Sequence.Contains(new Vertex<int>(i+1))) //yellow shortest cycle
                {
                    vertex.Label.FontColor = yellowColour;
                    vertex.Attr.Color = yellowColour;
                }
                else
                {
                    vertex.Label.FontColor = grayColour;
                    vertex.Attr.Color = grayColour;
                }
            }
            graph.Attr.BackgroundColor = blackColour;

            //TODO: change layout

            renderer.Render(bitmap);

            // putting image shenanigans
            var ms = new MemoryStream();
            bitmap.Save(ms, ImageFormat.Png);
            ms.Position = 0;
            var bi = new BitmapImage();
            bi.BeginInit();
            bi.StreamSource = ms;
            bi.EndInit();

            AlgImage.Source = bi;
        }

        private bool CycleContainsEdge(Cycle shortestCycle, Edge edge)
        {
            if (shortestCycle == null) return false;
            else return shortestCycle.Sequence.Contains(new Vertex<int>(int.Parse(edge.Source)))
                && shortestCycle.Sequence.Contains(new Vertex<int>(int.Parse(edge.Target)));
        }
    }
}

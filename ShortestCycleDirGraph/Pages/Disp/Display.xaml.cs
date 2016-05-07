using System;
using System.Collections.Generic;
using System.Drawing;
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
using System.Windows.Shapes;
using FirstFloor.ModernUI.Windows;
using Microsoft.Msagl.Drawing;
using Color = System.Drawing.Color;
using FragmentNavigationEventArgs = FirstFloor.ModernUI.Windows.Navigation.FragmentNavigationEventArgs;
using Image = System.Drawing.Image;
using NavigatingCancelEventArgs = FirstFloor.ModernUI.Windows.Navigation.NavigatingCancelEventArgs;
using NavigationEventArgs = FirstFloor.ModernUI.Windows.Navigation.NavigationEventArgs;

namespace ShortestCycleDirGraph.Pages.Disp
{
    /// <summary>
    /// Interaction logic for Display.xaml
    /// </summary>
    public partial class Display : UserControl, IContent
    {
        public Display()
        {
            InitializeComponent();


        }

        private void DrawGraph()
        {
            const int bitmapSize = 450;
            var blackColour = new Microsoft.Msagl.Drawing.Color(37, 37, 38);
            var grayColour = new Microsoft.Msagl.Drawing.Color(193, 193, 193);

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
                edge.Attr.Color = grayColour;
            }
            for (int i = 0; i < g.VertexSet.Count; i++)
            {
                var vertex = graph.FindNode(Convert.ToString(i + 1));
                vertex.Label.FontColor = grayColour;
                vertex.Attr.Color = grayColour;
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

            GraphImage.Source = bi;
        }

        public void OnFragmentNavigation(FragmentNavigationEventArgs e)
        {
           
        }

        public void OnNavigatedFrom(NavigationEventArgs e)
        {
           
        }

        public void OnNavigatedTo(NavigationEventArgs e)
        {
            GraphImage.Source = null;
            if (Models.GraphModel.Graph != null && Models.GraphModel.Graph.EdgeCount != 0)
            {
                DisplayTitle.Text = "Wprowadzony graf";
                DrawGraph();
            }
            else DisplayTitle.Text = "Najpierw trzeba wprowadzić graf!";
        }

        public void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            
        }
    }
}

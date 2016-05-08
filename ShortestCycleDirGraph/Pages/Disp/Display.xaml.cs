using System;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using FirstFloor.ModernUI.Windows;
using Microsoft.Msagl.Drawing;
using ShortestCycleDirGraph.Models;
using FragmentNavigationEventArgs = FirstFloor.ModernUI.Windows.Navigation.FragmentNavigationEventArgs;
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
            const int bitmapSize = 1000;
            var blackColour = new Microsoft.Msagl.Drawing.Color(37, 37, 38);
            var grayColour = new Microsoft.Msagl.Drawing.Color(193, 193, 193);

            // needed when using threads
            this.Dispatcher.Invoke((Action) (() =>
            {
                if (string.Equals("Układ warstowy", GraphModel.SelectedSettings.Name))
                {
                    GraphImage.Width = 500;
                    GraphImage.Height = 500;
                }
                else
                {
                    GraphImage.Width = double.NaN;
                    GraphImage.Height = double.NaN;
                }
            }));

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


            graph.LayoutAlgorithmSettings = GraphModel.SelectedSettings.Settings;
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


            renderer.Render(bitmap);

            // putting image shenanigans
            var ms = new MemoryStream();
            bitmap.Save(ms, ImageFormat.Png);
            ms.Position = 0;
            var bi = new BitmapImage();
            bi.BeginInit();
            bi.StreamSource = ms;
            bi.EndInit();


            bi.Freeze(); // Freeze BitmapImage to make it thread safe
            this.Dispatcher.Invoke((Action) (() => { GraphImage.Source = bi; }));
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

                new Thread(DrawGraph).Start();
            }
            else DisplayTitle.Text = "Najpierw trzeba wprowadzić graf!";
        }

        public void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
        }
    }
}

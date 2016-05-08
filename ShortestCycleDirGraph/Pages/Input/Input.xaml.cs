using System;
using System.Windows;
using System.Windows.Controls;
using FirstFloor.ModernUI.Windows;
using ShortestCycleDirGraph.Core;
using FragmentNavigationEventArgs = FirstFloor.ModernUI.Windows.Navigation.FragmentNavigationEventArgs;
using NavigatingCancelEventArgs = FirstFloor.ModernUI.Windows.Navigation.NavigatingCancelEventArgs;
using NavigationEventArgs = FirstFloor.ModernUI.Windows.Navigation.NavigationEventArgs;

namespace ShortestCycleDirGraph.Pages.Input
{
    /// <summary>
    /// Interaction logic for Input.xaml
    /// </summary>
    public partial class Input : UserControl, IContent
    {
        public static Graph<int> Graph { get; set; }

        private static int _edgeCount;
        private static int _vertexCount;

        public static int VertexCount
        {
            get { return _vertexCount; }
            set { _vertexCount = value; }
        }

        public static int EdgeCount
        {
            get { return _edgeCount; }
            set { _edgeCount = value; }
        }


        public Input()
        {
            InitializeComponent();
        }


        public void OnFragmentNavigation(FragmentNavigationEventArgs e)
        {
        }

        public void OnNavigatedFrom(NavigationEventArgs e)
        {
            ParseTextBoxes();

            if (Graph != null && (Graph.VertexSet.Count != _vertexCount || Graph.EdgeCount != _edgeCount)) Graph = null;
        }

        private void ParseTextBoxes()
        {
            int.TryParse(TbVertex.Text, out _vertexCount);
            int.TryParse(TbEdge.Text, out _edgeCount);
        }

        public void OnNavigatedTo(NavigationEventArgs e)
        {
            if (Models.GraphModel.Graph == null) return;
            TbVertex.Text = Models.GraphModel.Graph.VertexSet.Count.ToString();
            TbEdge.Text = Models.GraphModel.Graph.EdgeCount.ToString();
        }

        public void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
        }

        private void RandomGraphButton_Click(object sender, RoutedEventArgs e)
        {
            ParseTextBoxes();
            if (_vertexCount < 1)
            {
                RandomAlert.Text = "Musisz podać liczbę wierzchołków i krawędzi";
            }
            else
            {
                RandomAlert.Text = "";
                GenerateRandomGraph();
            }
        }

        private void GenerateRandomGraph()
        {
            var random = new Random();
            var incMatrix = new sbyte[_vertexCount, _edgeCount];

            for (int i = 0; i < _edgeCount; i++)
            {
                int positive = random.Next(_vertexCount);
                int negative = positive;
                while (positive == negative)
                {
                    negative = random.Next(_vertexCount);
                }
                incMatrix[positive, i] = 1;
                incMatrix[negative, i] = -1;
            }


            Models.GraphModel.Graph = GraphImporting.FromIncMatrix(incMatrix);
            TbVertex.Text = Models.GraphModel.Graph.VertexSet.Count.ToString();
            TbEdge.Text = Models.GraphModel.Graph.EdgeCount.ToString();
            ParseTextBoxes();
        }
    }
}
    
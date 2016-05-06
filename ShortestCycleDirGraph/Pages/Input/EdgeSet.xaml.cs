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
using System.Windows.Shapes;
using FirstFloor.ModernUI.Windows;
using ShortestCycleDirGraph.Core;
using FragmentNavigationEventArgs = FirstFloor.ModernUI.Windows.Navigation.FragmentNavigationEventArgs;
using NavigatingCancelEventArgs = FirstFloor.ModernUI.Windows.Navigation.NavigatingCancelEventArgs;
using NavigationEventArgs = FirstFloor.ModernUI.Windows.Navigation.NavigationEventArgs;

namespace ShortestCycleDirGraph.Pages.Input
{
    /// <summary>
    /// Interaction logic for EdgeSet.xaml
    /// </summary>
    public partial class EdgeSet : UserControl, IContent
    {
        public EdgeSet()
        {
            InitializeComponent();
        }

        private void ExportGraph()
        {
            string edgeSet = GraphExporting.ToEdgeSet(Models.GraphModel.Graph);

            var edgeTextBox = EdgeSetControl;
            edgeTextBox.Document.Blocks.Clear();
            edgeTextBox.Document.Blocks.Add(new Paragraph(new Run(edgeSet)));
        }

        public void ImportGraph()
        {
            try
            {
                string edgeSet = new TextRange(EdgeSetControl.Document.ContentStart, EdgeSetControl.Document.ContentEnd).Text;

                Models.GraphModel.Graph = GraphImporting.FromEdgeSet(edgeSet);
                Input.VertexCount = Models.GraphModel.Graph.VertexSet.Count;
                Input.EdgeCount = Models.GraphModel.Graph.EdgeCount;
            }
            catch (Exception)
            {
                //TODO: do shit
            }
        }

        public void OnFragmentNavigation(FragmentNavigationEventArgs e)
        {
            
        }

        public void OnNavigatedFrom(NavigationEventArgs e)
        {
            ImportGraph();
        }

        public void OnNavigatedTo(NavigationEventArgs e)
        {
            EdgeSetControl.Document.Blocks.Clear();
            if (Models.GraphModel.Graph != null && Models.GraphModel.Graph.EdgeCount != 0)
            {
                ExportGraph();
            }
        }

        public void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            
        }
    }
}

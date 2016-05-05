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
          
            int.TryParse(TbVertex.Text, out _vertexCount);
            int.TryParse(TbEdge.Text, out _edgeCount);
            if (Graph != null && (Graph.VertexSet.Count != _vertexCount || Graph.EdgeCount != _edgeCount)) Graph = null;
        }

        public void OnNavigatedTo(NavigationEventArgs e)
        {
            if (Input.Graph == null) return;
            TbVertex.Text = Input.Graph.VertexSet.Count.ToString();
            TbEdge.Text = Input.Graph.EdgeCount.ToString();
        }

        public void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            
        }
    }
}

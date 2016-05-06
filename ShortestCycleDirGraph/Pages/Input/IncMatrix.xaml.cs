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
    /// Interaction logic for IncMatrix.xaml
    /// </summary>
    public partial class IncMatrix : UserControl, IContent
    {
        public IncMatrix()
        {
            InitializeComponent();
        }

        public void Reload()
        {
            IncMatrixBoxes.Children.Clear();

            if (Input.VertexCount == 0 || Input.EdgeCount == 0) IncTitleText.Text = "Musisz wprowadzić liczbę wierzchołków i liczbę krawędzi!";
            else if (Input.VertexCount < 0 || Input.EdgeCount < 0) IncTitleText.Text = "Podana liczba wierzchołków i krawędzi musi być większa od 0";
            else
            {
                IncTitleText.Text = "Wprowadź macierz incydencji";

                DrawTextBoxes();
            }
        }

        private void DrawTextBoxes()
        {
            for (int i = 0; i < Input.VertexCount; i++)
            {
                var sp = new StackPanel
                {
                    Orientation = Orientation.Horizontal,
                    Margin = new Thickness(0, 0, 0, 10)
                };

                for (int j = 0; j < Input.EdgeCount; j++)
                {
                    var tb1 = new TextBox { Width = 30, Margin = new Thickness(0, 0, 10, 0) };
                    sp.Children.Add(tb1);
                }
                IncMatrixBoxes.Children.Add(sp);
            }
        }
        private void ExportGraph()
        {
            var incMatrix = GraphExporting.ToIncMatrix(Models.GraphModel.Graph);

            int i = 0;
            foreach (StackPanel stackPanel in IncMatrixBoxes.Children)
            {
                int j = 0;
                foreach (TextBox textBox in stackPanel.Children)
                {
                    textBox.Text = Convert.ToString(incMatrix[i, j]);
                    j++;
                }
                i++;
            }
        }

        private void ImportGraph()
        {
            try
            {
                var incMatrix = new sbyte[Input.VertexCount, Input.EdgeCount];

                int i = 0;
                foreach (StackPanel stackPanel in IncMatrixBoxes.Children)
                {
                    int j = 0;
                    foreach (TextBox textBox in stackPanel.Children)
                    {
                        if (textBox.Text == "") incMatrix[i, j] = 0;
                        else incMatrix[i, j] = sbyte.Parse(textBox.Text);

                        j++;
                    }
                    i++;
                }

                Models.GraphModel.Graph = GraphImporting.FromIncMatrix(incMatrix);
                Input.VertexCount = Models.GraphModel.Graph.VertexSet.Count;
                Input.EdgeCount = Models.GraphModel.Graph.EdgeCount;
            }
            catch (Exception)
            {
                //TODO fill it
            }
        }

        public void OnFragmentNavigation(FragmentNavigationEventArgs e)
        {
         
        }

        public void OnNavigatedFrom(NavigationEventArgs e)
        {
            if (Input.VertexCount == 0 || Input.EdgeCount == 0) return;
            ImportGraph();
        }

        public void OnNavigatedTo(NavigationEventArgs e)
        {
            Reload();
            if (Models.GraphModel.Graph != null && !GraphChanged()) 
            {
                ExportGraph();
            }
            
        }

        private bool GraphChanged()
        {
            return Models.GraphModel.Graph.VertexSet.Count != Input.VertexCount;
        }

        public void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
         
        }
    }
}

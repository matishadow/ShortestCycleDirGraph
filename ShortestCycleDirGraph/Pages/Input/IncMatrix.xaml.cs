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
        }


        public void OnFragmentNavigation(FragmentNavigationEventArgs e)
        {
         
        }

        public void OnNavigatedFrom(NavigationEventArgs e)
        {
         
        }

        public void OnNavigatedTo(NavigationEventArgs e)
        {
            Reload();
        }

        public void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
         
        }
    }
}

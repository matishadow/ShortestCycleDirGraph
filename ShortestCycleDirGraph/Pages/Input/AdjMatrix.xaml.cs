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
    /// Interaction logic for AdjMatrix.xaml
    /// </summary>
    public partial class AdjMatrix : UserControl, IContent
    {
        
        public AdjMatrix()
        {
            InitializeComponent();


            
        }

        public void Reload()
        {
            AdjMatrixBoxes.Children.Clear();

            if (Input.VertexCount == 0) AdjTitleText.Text = "Musisz wprowadzić liczbę wierzchołków!";
            else if (Input.VertexCount < 0) AdjTitleText.Text = "Podana liczba wierzchołków musi być większa od 0";
            else
            {
                AdjTitleText.Text = "Wprowadź macierz sąsiedztwa";


                
                for (int i = 0; i < Input.VertexCount; i++)
                {
                    var sp = new StackPanel
                    {
                        Orientation = Orientation.Horizontal,
                        Margin = new Thickness(0, 0, 0, 10)
                    };

                    for (int j = 0; j < Input.VertexCount; j++)
                    {
                        var tb1 = new TextBox { Width = 30, Margin = new Thickness(0, 0, 10, 0) };
                        sp.Children.Add(tb1);
                    }
                    AdjMatrixBoxes.Children.Add(sp);
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

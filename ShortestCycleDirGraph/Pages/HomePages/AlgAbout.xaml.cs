using System.Windows.Controls;

namespace ShortestCycleDirGraph.Pages.HomePages
{
    /// <summary>
    /// Interaction logic for AlgAbout.xaml
    /// </summary>
    public partial class AlgAbout : UserControl
    {
        public AlgAbout()
        {
            InitializeComponent();

            AlgContent.Text =
                "W projekcie użyliśmy zmodyfikowanego algorytmu \"przeszukiwania wszerz\". \r\n\n" +
                "Modyfikacja polegała na zmianie warunku przechodzenia po kolejnych wierzchołkach.\r\n\n" +
                "W podstawowej wersji algorytmu warunkiem przejścia do wierzchołka jest aby jego odległość była równa Inf, " +
                "u nas pozwalamy jeszcze na wejście do wierzchołka gdy jego odległość jest równa 0 (jest wierzchołkiem początkowym). \n\n" +
                "Dzięki temu odnajdujemy najkrótszą ścieżkę z zadanego wierzchołka do niego samego - czyli najkrótszy cykl dla danego wierzchołka. \n\n" +
                "Aby znaleźć najkrótszy cykl w całym grafie wystarczy użyć wyżej opisanego algorytmu na każdym z wierzchołków.";
        }
    }
}

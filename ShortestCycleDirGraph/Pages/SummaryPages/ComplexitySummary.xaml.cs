using System.Windows.Controls;

namespace ShortestCycleDirGraph.Pages.SummaryPages
{
    /// <summary>
    /// Interaction logic for ComplexitySummary.xaml
    /// </summary>
    public partial class ComplexitySummary : UserControl
    {
        public ComplexitySummary()
        {
            InitializeComponent();

            CompContent.Text = "Pesymistyczna złożoność algorytmu \"przeszukiwania wszerz\" to: O(|V| + |E|). \n" +
                               "Jako że nasz zmodyfikowany algorytm jest uruchamiany dla każdego wierzchołka to całkowia pesymistyczna złożoność wyniesie O( (|V|+|E|) * |V| )";
        }
    }
}

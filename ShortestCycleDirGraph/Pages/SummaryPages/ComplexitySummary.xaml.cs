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

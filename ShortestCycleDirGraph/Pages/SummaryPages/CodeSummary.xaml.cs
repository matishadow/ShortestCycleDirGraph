using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace ShortestCycleDirGraph.Pages.SummaryPages
{
    /// <summary>
    /// Interaction logic for CodeSummary.xaml
    /// </summary>
    public partial class CodeSummary : UserControl
    {
        public CodeSummary()
        {
            InitializeComponent();

            var uriSource = new Uri(@"/Resources/alg.bmp", UriKind.Relative);

            CodeImage.Source = new BitmapImage(uriSource);
        }
    }
}

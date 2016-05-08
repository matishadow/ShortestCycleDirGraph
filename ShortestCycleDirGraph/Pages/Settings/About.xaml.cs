using System.Windows.Controls;

namespace ShortestCycleDirGraph.Pages.Settings
{
    /// <summary>
    /// Interaction logic for About.xaml
    /// </summary>
    public partial class About : UserControl
    {
        public About()
        {
            InitializeComponent();

            LibContent.Text =
                "Rysowanie grafów: Microsoft Automatic Graph Layout\n" +
                "https://github.com/Microsoft/automatic-graph-layout \n" +
                "\r\nMotyw okienkowy: Modern UI for WPF\n" +
                "https://github.com/firstfloorsoftware/mui";

            RepContent.Text = "https://github.com/matishadow/ShortestCycleDirGraph";
            AuthContent.Text = "Mateusz Tracz \nDominika Kucharska";
        }
    }
}

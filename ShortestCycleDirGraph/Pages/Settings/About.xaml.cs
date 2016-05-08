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

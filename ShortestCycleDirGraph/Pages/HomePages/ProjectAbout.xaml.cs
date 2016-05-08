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

namespace ShortestCycleDirGraph.Pages.HomePages
{
    /// <summary>
    /// Interaction logic for ProjectAbout.xaml
    /// </summary>
    public partial class ProjectAbout : UserControl
    {
        public ProjectAbout()
        {
            InitializeComponent();

            TopicContent.Text = " 27. Znajdowanie najkrótszego cyklu w grafie skierowanym.";
            TeamContent.Text = " Mateusz Tracz - grupa 2\n Dominika Kucharska - grupa 1";
        }
    }
}

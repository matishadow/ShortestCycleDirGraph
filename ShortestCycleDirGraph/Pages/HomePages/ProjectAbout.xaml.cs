using System.Windows.Controls;

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

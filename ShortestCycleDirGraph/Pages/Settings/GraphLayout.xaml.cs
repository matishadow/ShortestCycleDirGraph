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
using ShortestCycleDirGraph.Models;
using FragmentNavigationEventArgs = FirstFloor.ModernUI.Windows.Navigation.FragmentNavigationEventArgs;
using NavigatingCancelEventArgs = FirstFloor.ModernUI.Windows.Navigation.NavigatingCancelEventArgs;
using NavigationEventArgs = FirstFloor.ModernUI.Windows.Navigation.NavigationEventArgs;

namespace ShortestCycleDirGraph.Pages.Settings
{
    /// <summary>
    /// Interaction logic for GraphLayout.xaml
    /// </summary>
    public partial class GraphLayout : UserControl, IContent
    {
        public GraphLayout()
        {
            InitializeComponent();

            SettingsList.ItemsSource = GraphModel.SettingsList;
            SettingsList.SelectedIndex = 0;
        }

        public void OnFragmentNavigation(FragmentNavigationEventArgs e)
        {
        }

        public void OnNavigatedFrom(NavigationEventArgs e)
        {
         
        }

        public void OnNavigatedTo(NavigationEventArgs e)
        {
            
        }

        public void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            
        }

        private void SettingsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GraphModel.SelectedSettings = GraphModel.SettingsList[SettingsList.SelectedIndex];
        }
    }
}

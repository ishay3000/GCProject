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
using System.Windows.Shapes;

namespace GCProject.Views
{
    /// <summary>
    /// Interaction logic for DashboardWindow.xaml
    /// </summary>
    public partial class DashboardWindow : Window
    {
        public DashboardWindow()
        {
            InitializeComponent();
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
	        ButtonCloseMenu.Visibility = Visibility.Visible;
	        ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
	        ButtonCloseMenu.Visibility = Visibility.Collapsed;
	        ButtonOpenMenu.Visibility = Visibility.Visible;
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
	        UserControl usc = null;
	        GridMain.Children.Clear();

	        switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
	        {
		        case "ItemHome":
			        usc = new CustomCardControl();
			        GridMain.Children.Add(usc);
					ButtonCloseMenu_Click(this, null);
			        break;
		        case "ItemCreate":
			        usc = new CustomCardControl();
			        GridMain.Children.Add(usc);
			        break;
		        default:
			        usc = new CustomCardControl();
			        GridMain.Children.Add(usc);
			        break;
	        }
        }
	}
}

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
using GCProject.ViewModels;

namespace GCProject.Views
{
    /// <summary>
    /// Interaction logic for DataTemplateWindow.xaml
    /// </summary>
    public partial class DataTemplateWindow : Window
    {
	    public MenuCardViewModel ViewModel { get; set; }
        public DataTemplateWindow()
        {
            InitializeComponent();
			ViewModel = new MenuCardViewModel();
			//DataContext = ViewModel;
        }
    }
}

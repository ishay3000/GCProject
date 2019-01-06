using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using GCProject.Models;
using GCProject.ViewModels;

namespace GCProject.Views
{
    /// <summary>
    /// Interaction logic for CardScrollControl.xaml
    /// </summary>
    public partial class CardScrollControl : UserControl
    {
		ObservableCollection<EquipmentItem> m_selectedEquipmentHorizontal = new ObservableCollection<EquipmentItem>();
		private ObservableCollection<MenuCard> _menuCards;// = new ObservableCollection<MenuCard>();
		MenuCardViewModel _viewModel = new MenuCardViewModel();

		public CardScrollControl()
		{
			InitializeComponent();
		}

		protected override void OnInitialized(EventArgs e)
		{
			base.OnInitialized(e);

			_menuCards = _viewModel.Cards;
			this.horizontalListBox.ItemsSource = _menuCards;
		}
	}
}

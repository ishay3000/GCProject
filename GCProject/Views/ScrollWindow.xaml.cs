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
using System.Windows.Shapes;
using GCProject.Models;
using GCProject.ViewModels;

namespace GCProject.Views
{
    /// <summary>
    /// Interaction logic for ScrollWindow.xaml
    /// </summary>
    public partial class ScrollWindow : Window
    {
	    ObservableCollection<EquipmentItem> m_selectedEquipmentHorizontal = new ObservableCollection<EquipmentItem>();
	    private ObservableCollection<MenuCard> _menuCards;// = new ObservableCollection<MenuCard>();
		MenuCardViewModel _viewModel = new MenuCardViewModel();

		public ScrollWindow()
        {
            InitializeComponent();
        }

		protected override void OnInitialized(EventArgs e)
		{
			base.OnInitialized(e);

			ObservableCollection<EquipmentItem> equipmentList1 = new ObservableCollection<EquipmentItem>();
			this.horizontalListBox.ItemsSource = equipmentList1;
			CreateEquipments(equipmentList1, "Tank-");

			_menuCards = _viewModel.Cards;
			this.horizontalListBox.ItemsSource = _menuCards;
		}

		private ObservableCollection<EquipmentItem> CreateEquipments(ObservableCollection<EquipmentItem> equipmentList, string prefix)
		{
			int maxItemCount = 20;
			for (int i = 0; i < maxItemCount; i++)
			{
				equipmentList.Add(new EquipmentItem() { Name = prefix + i.ToString(), CampaignName = "Batch_ " + i.ToString() });
			}
			return equipmentList;
		}
	}
}

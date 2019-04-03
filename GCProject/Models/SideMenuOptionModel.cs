using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCProject.Commands;
using MaterialDesignThemes.Wpf;

namespace GCProject.Models
{
	/// <summary>
	/// Represents an option in the dashboard's side menu
	/// </summary>
	public class SideMenuOptionModel
    {
	    private PackIconKind _itemPackIcon;
		private string _itemText;
		private RelayCommand _itemCommand;

		public SideMenuOptionModel(PackIconKind itemPackIcon, string itemText, RelayCommand itemCommand)
		{
			_itemPackIcon = itemPackIcon;
			_itemText = itemText;
			_itemCommand = itemCommand;
		}

		public PackIconKind ItemPackIcon
		{
			get => _itemPackIcon;
			set => _itemPackIcon = value;
		}

		public string ItemText
		{
			get => _itemText;
			set => _itemText = value;
		}

		public RelayCommand ItemCommand
		{
			get => _itemCommand;
			set => _itemCommand = value;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

		public SideMenuOptionModel(PackIconKind itemPackIcon, string itemText)
		{
			_itemPackIcon = itemPackIcon;
			_itemText = itemText;
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
    }
}

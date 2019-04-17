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
        public SideMenuOptionModel(PackIconKind itemPackIcon, string itemText, RelayCommand itemCommand)
        {
            ItemPackIcon = itemPackIcon;
            ItemText = itemText;
            ItemCommand = itemCommand;
        }

        public PackIconKind ItemPackIcon { get; set; }

        public string ItemText { get; set; }

        public RelayCommand ItemCommand { get; set; }
    }
}

using System.Collections.ObjectModel;
using GCProject.Models;
using MaterialDesignThemes.Wpf;

namespace GCProject.ViewModels
{
	/// <summary>
	/// A view model to bridge between the side menu in dashboard and the <see cref="SideMenuOptionModel"/> model
	/// </summary>
	public class SideMenuOptionViewModel : BaseViewModel
	{
		public ObservableCollection<SideMenuOptionModel> SideMenuOptions { get; set; }

		public SideMenuOptionViewModel()
		{
			SideMenuOptions = new ObservableCollection<SideMenuOptionModel>();

			LoadMenuOptions();
		}

		/// <summary>
		/// Loads the options for the side menu
		/// </summary>
		private void LoadMenuOptions()
		{
			SideMenuOptions.Add(new SideMenuOptionModel(PackIconKind.Home, "Home"));
			SideMenuOptions.Add(new SideMenuOptionModel(PackIconKind.Settings, "Settings"));
		}
	}
}
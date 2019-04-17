using System.Collections.ObjectModel;
using System.Windows;
using GCProject.Commands;
using GCProject.miscellanies;
using GCProject.Models;
using GCProject.Views;
using MaterialDesignThemes.Wpf;

namespace GCProject.ViewModels
{
	/// <summary>
	/// A view model to bridge between the side menu in dashboard and the <see cref="SideMenuOptionModel"/> model
	/// </summary>
	public class SideMenuOptionViewModel : BaseViewModel
	{
		public ObservableCollection<SideMenuOptionModel> SideMenuOptions { get; set; }
		private static readonly SideMenuOptionViewModel Instance = new SideMenuOptionViewModel();

		public static SideMenuOptionViewModel INSTANCE => Instance;

		private SideMenuOptionViewModel()
		{
			SideMenuOptions = new ObservableCollection<SideMenuOptionModel>();

			LoadMenuOptions();
		}

		/// <summary>
		/// Loads the options for the side menu
		/// </summary>
		private void LoadMenuOptions()
		{
			RelayCommand home = new RelayCommand( () => 
            {
                FrameManager.MovePage(ControlsTitles.Cards);
            });
			RelayCommand settings = new RelayCommand(() =>
            {
                FrameManager.MovePage(ControlsTitles.Settings);
            });
            SideMenuOptions.Add(new SideMenuOptionModel(PackIconKind.Home, "Home", home));
			SideMenuOptions.Add(new SideMenuOptionModel(PackIconKind.Settings, "Settings", settings));
		}
	}
}
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GCProject.Commands;
using GCProject.Models;

namespace GCProject.ViewModels
{
	class ScanResultsViewModel : BaseViewModel
	{
		public ObservableCollection<ScanResultsModel> ScanResults { get; set; }
		public RelayCommand NewScanCommand { get; set; }
		public RelayCommand PreviousScanCommand { get; set; }
		private Visibility _gridVisibility, _menuVisibility;

		public Visibility GridVisibility
		{
			get => _gridVisibility;
			set
			{
				_gridVisibility = value;
				OnPropertyChanged("GridVisibility");
			}
		}

		public Visibility MenuVisibility
		{
			get => _menuVisibility;
			set
			{
				_menuVisibility = value;
				OnPropertyChanged("MenuVisibility");
			}
		}


		private static readonly ScanResultsViewModel Instance = new ScanResultsViewModel();

		public static ScanResultsViewModel INSTANCE => Instance;

		private ScanResultsViewModel()
		{
			ScanResults = new ObservableCollection<ScanResultsModel>();
			ShowMenu();

			LoadDummyResults();
			LoadButtonsCommands();
		}

		private void ShowMenu()
		{
			MenuVisibility = Visibility.Visible;
			GridVisibility = Visibility.Hidden;
		}

		private void ShowGrid()
		{
			MenuVisibility = Visibility.Hidden;
			GridVisibility = Visibility.Visible;
		}

		private void LoadButtonsCommands()
		{
			NewScanCommand = new RelayCommand(o => true, o => NewScan());
			PreviousScanCommand = new RelayCommand(o => true, o => PreviousScan());
		}

		private void NewScan()
		{
			//MessageBox.Show("New scan not implemented yet");
			LoadDummyResults();
			ShowGrid();
		}

		private void PreviousScan()
		{
			MessageBox.Show("Previous scan not implemented yet");
		}

		private void LoadDummyResults()
		{
			Random rnd = new Random(0);
			var numbers = Enumerable.Range(0, 30)
				.Select(r => rnd.Next(7000, 7020))
				.ToList().AsParallel().AsOrdered();

			foreach (int number in numbers)
			{
				ScanResults.Add(new ScanResultsModel(number));
			}
		}
	}
}

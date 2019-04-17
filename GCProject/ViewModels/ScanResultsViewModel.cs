using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GCProject.Commands;
using GCProject.Miscellanies;
using GCProject.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GCProject.ViewModels
{
	class ScanResultsViewModel : BaseViewModel
	{
		public ObservableCollection<ScanResultsModel> ScanResults { get; set; }
		public RelayCommand NewScanCommand { get; set; }
		public RelayCommand PreviousScanCommand { get; set; }
		public RelayCommand ToggleMenuCommand { get; set; }
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

		private void ToggleMenu()
		{
			Visibility tempVisibility = MenuVisibility;
			MenuVisibility = GridVisibility;
			GridVisibility = tempVisibility;
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
			NewScanCommand = new RelayCommand(o => true, async (o) =>
			{
				await NewScan();
			});

			PreviousScanCommand = new RelayCommand(o => true, o => PreviousScan());

			ToggleMenuCommand = new RelayCommand(o => true, o => ToggleMenu());
		}

		class Numbers
		{
			private List<int> numbers;
		}
		class Results
		{
			private Numbers Result { get; set; }
			private string Status { get; set; }

		}

		private async Task NewScan()
		{
			//MessageBox.Show("New scan not implemented yet");
			LoadDummyResults();
			Dictionary<string, string> requestDictionary = new Dictionary<string, string>
			{
				{"Command", "Scan"}, {"Args", "New"}
			};

			string jsonRequest = JsonConvert.SerializeObject(requestDictionary);
			dynamic response = await Client.INSTANCE.SendAndReceiveAsync(jsonRequest);

			var jobj = JObject.Parse(response);
			string status = jobj["Status"];
			var jsonResult = jobj["Result"];
			var result = JsonConvert.DeserializeObject<Results>(response);

			if (status == "OK")
			{
				// TODO iterate over the results and make a list of ScanResultsModels and add to collection
				Console.WriteLine("Scan Results: \n" + result);
			}

			else
			{
				Console.WriteLine("Error retrieving scan results");
			}

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

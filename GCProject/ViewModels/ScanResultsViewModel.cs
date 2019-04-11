using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCProject.Models;

namespace GCProject.ViewModels
{
	class ScanResultsViewModel : BaseViewModel
	{
		public ObservableCollection<ScanResultsModel> ScanResults { get; set; }
		//private RelayCommand _cardCommand;

		private static readonly ScanResultsViewModel Instance = new ScanResultsViewModel();

		public static ScanResultsViewModel INSTANCE => Instance;

		private ScanResultsViewModel()
		{
			ScanResults = new ObservableCollection<ScanResultsModel>();
			LoadDummyResults();
		}

		private void LoadDummyResults()
		{
			var numbers = (from x in Enumerable.Range(7000, 7010)
				let rnd = new Random(0)
				select x).ToList();

			var tmp = (numbers.AsParallel().AsOrdered()).ToList();

			foreach (int number in numbers)
			{
				ScanResults.Add(new ScanResultsModel(number));
			}
		}
	}
}

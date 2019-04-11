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

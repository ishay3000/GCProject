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
        #region Members
        private ObservableCollection<ScanResultsModel> _scanResults;

        #endregion


        #region Props
        public ObservableCollection<ScanResultsModel> ScanResults
        {
            get { return _scanResults; }
            set
            {
                _scanResults = value;
                OnPropertyChanged("ScanResults");
            }
        }

        #endregion



        private static readonly ScanResultsViewModel Instance = new ScanResultsViewModel();

        public static ScanResultsViewModel INSTANCE => Instance;

		private ScanResultsViewModel()
		{
			ScanResults = new ObservableCollection<ScanResultsModel>();
		}

        public void SetResults(List<int> numbersList)
        {
            foreach (int number in numbersList)
            {
                _scanResults.Add(new ScanResultsModel(number));
            }
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

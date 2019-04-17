using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using GCProject.Commands;
using GCProject.miscellanies;
using GCProject.Miscellanies;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GCProject.ViewModels
{
    class ScanFormViewModel : BaseViewModel
    {
        #region Members
        private static readonly ScanFormViewModel Instance = new ScanFormViewModel();
        private RelayCommand _newScanCommand;
        private RelayCommand _previousScanCommand;
        public List<int> NumbersList;

        public static ScanFormViewModel INSTANCE => Instance;

        #endregion

        public ScanFormViewModel()
        {
            _newScanCommand = new RelayCommand(NewScan);
            _previousScanCommand = new RelayCommand(PreviousScan);
            NumbersList = new List<int>();
        }

        #region props
        public RelayCommand NewScanCommand
        {
            get { return _newScanCommand; }
            set { _newScanCommand = value; }
        }

        public RelayCommand PreviousScanCommand
        {
            get { return _previousScanCommand; }
            set { _previousScanCommand = value; }
        }


        #endregion

        private void ShowResultsPage(List<int> numbList)
        {
            ScanResultsViewModel.INSTANCE.SetResults(numbList);
            FrameManager.MovePage(ControlsTitles.ScanResults);
        }

        private async void NewScan()
        {
            var numbers = await TelephonyScanner.ScanAsyncTask();
            if (numbers != null)
            {
                ShowResultsPage(numbers);
            }
            else
            {
                Console.WriteLine("Couldn't find numbers");
            }
        }

        private void PreviousScan()
        {
            // TODO implement previous scan logic
        }
    }
}

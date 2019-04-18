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
        private string _startText;
        private string _endText;

        public List<int> NumbersList;
        public static ScanFormViewModel INSTANCE => Instance;

        #endregion

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

        public string StartText
        {
            get { return _startText; }
            set
            {
                _startText = value;
                OnPropertyChanged("StartText");
            }
        }

        public string EndText
        {
            get { return _endText; }
            set
            {
                _endText = value;
                OnPropertyChanged("EndText");
            }
        }

        #endregion


        public ScanFormViewModel()
        {
            _newScanCommand = new RelayCommand(NewScan);
            _previousScanCommand = new RelayCommand(PreviousScan);
            NumbersList = new List<int>();
        }


        private void ShowResultsPage(List<int> numbList)
        {
            ScanResultsViewModel.INSTANCE.SetResults(numbList);
            FrameManager.MovePage(ControlsTitles.ScanResults);
        }

        private async void NewScan()
        {
            var requestArgs = new Dictionary<string, object>();
            requestArgs["ScanType"] = "New";
            requestArgs["ScanRange"] = new { Start = int.Parse(_startText), End = int.Parse(_endText) };
            
            var numbers = await TelephonyScanner.ScanAsyncTask(requestArgs);
            if (numbers != null)
            {
                ShowResultsPage(numbers);
            }
            else
            {
                Console.WriteLine("Couldn't find numbers");
            }
        }

        private async void PreviousScan()
        {
            // TODO implement previous scan logic
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using GCProject.Commands;
using GCProject.miscellanies;
using GCProject.Miscellanies;
using Microsoft.VisualBasic.Logging;
using Microsoft.Win32;
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
        private RelayCommand _openFileDialogCommand;
        private string _whitelistFilePath;
        private string _startText;
        private string _endText;

        public List<int> NumbersList;
        private List<int> _whitelistNumbersList;
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

        public RelayCommand OpenFileDialogCommand
        {
            get { return _openFileDialogCommand; }
            set { _openFileDialogCommand = value; }
        }

        public string WhitelistFilePath
        {
            get { return _whitelistFilePath; }
            set
            {
                _whitelistFilePath = value;
                OnPropertyChanged("WhitelistFilePath");
            }
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
            _openFileDialogCommand = new RelayCommand(OpenFileDialog);
            NumbersList = new List<int>();
        }


        private void ShowResultsPage(List<int> numbList)
        {
            ScanResultsViewModel.INSTANCE.SetResults(numbList);
            FrameManager.MovePage(ControlsTitles.ScanResults);
        }

        private async void OpenFileDialog()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == true)
            {
                WhitelistFilePath = dialog.FileName;
                Console.WriteLine("Reading whitelist at path: " + WhitelistFilePath);
                await Task.Run(async () =>
                {
                    _whitelistNumbersList = await FileReader.ReadWhitelistAsync(WhitelistFilePath);
                });
                if (_whitelistNumbersList != null && _whitelistNumbersList.Count > 0)
                {
                    Console.WriteLine("Finished reading whitelist. Numbers counts: " + _whitelistNumbersList.Count);
                }

                else
                {
                    Console.WriteLine("Error: Couldn't read whitelist");
                }
            }
        }

        private async void NewScan()
        {
            // TODO perhaps consider using builder pattern instead ?
            string request = new JRequestBuilder()
                .SetScanType("New")
                .SetScanArgs(new {Start = int.Parse(_startText), End = int.Parse(_endText)})
                .Build()
                .ToJson();
            
            var numbers = await TelephonyScanner.ScanAsyncTask(request);
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
            string input =
                Microsoft.VisualBasic.Interaction.InputBox("Please choose the previous scan's name",
                    "Scan name",
                    "Test",
                    -1, -1);

            if (!string.IsNullOrEmpty(input))
            {
                string request = JRequestBuilder
                    .CreateNew()
                    .SetScanType("Previous")
                    .SetScanArgs(new {ScanName = input})
                    .Build()
                    .ToJson();

                var numbers = await TelephonyScanner.ScanAsyncTask(request);
                if (numbers != null)
                {
                    ShowResultsPage(numbers);
                }
                else
                {
                    Console.WriteLine("Couldn't find numbers");
                }
            }
        }
    }
}

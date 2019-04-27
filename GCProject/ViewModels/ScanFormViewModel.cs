using System;
using System.Collections.Generic;
using System.Windows;
using GCProject.ClientService;
using GCProject.Commands;
using GCProject.miscellanies;
using GCProject.Misc;
using GCProject.Miscellanies;
using GCProject.ValidationService;
using Microsoft.Win32;

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
            _newScanCommand = new RelayCommand(NewScan/*, CanExecuteNew*/);
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
                Console.WriteLine("Reading whitelist at path:\t{0}", WhitelistFilePath);

                _whitelistNumbersList = await FileReader.ReadWhitelistAsync(WhitelistFilePath);
                if (_whitelistNumbersList != null && _whitelistNumbersList.Count > 0)
                {
                    Console.WriteLine("Finished reading whitelist. Numbers Found: " + _whitelistNumbersList.Count);
                }
                else
                {
                    Console.WriteLine("Error: Couldn't read whitelist");
                }
            }
        }

        private async void NewScan()
        {
            var validation = ScanValidation.ValidateNew(_startText, _endText, _whitelistNumbersList);
            if (!validation.Item1)
            {
                MessageBox.Show(validation.Item2);
                return;
            }

            // TODO perhaps consider using builder pattern instead ?
            string request = new ScanJRequest("New",
                new { Start = StartText, End = EndText, Whitelist = _whitelistNumbersList })
                .ToJson();
            var numbers = await TelephonyScanner.ScanAsyncTask(request);
            if (numbers != null && numbers.Count > 0)
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
            string scanName =
                Microsoft.VisualBasic.Interaction.InputBox("Please choose the previous scan's name",
                    "Scan name",
                    "Test",
                    -1, -1);

            var validation = ScanValidation.ValidatePrevious(scanName);
            if (!validation.Item1)
            {
                MessageBox.Show(validation.Item2);
                return; ;
            }

            ScanJRequest scanJRequest = new ScanJRequest("Previous",
                new { ScanName = scanName });

            var numbers = await TelephonyScanner.ScanAsyncTask(scanJRequest.ToJson());
            if (numbers != null && numbers.Count > 0)
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GCProject.Commands;
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
        private List<int> _numbersList;

        public static ScanFormViewModel INSTANCE => Instance;

        #endregion

        public ScanFormViewModel()
        {
            _newScanCommand = new RelayCommand(NewScan);
            _previousScanCommand = new RelayCommand(PreviousScan);
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


        private void NewScan()
        {
            Task.Run((async () =>
            {
                var requestDictionary = new Dictionary<string, string>
                {
                    {"Command", "Scan"}, {"Args", "New"}
                };

                string jsonRequest = JsonConvert.SerializeObject(requestDictionary);
                dynamic response = await Client.INSTANCE.SendAndReceiveAsync(jsonRequest);

                try
                {
                    JObject responseJObject = JObject.Parse(response);
                    var status = responseJObject["Status"];

                    if (status.ToString() == "OK")
                    {
                        var numbers = responseJObject["Result"];
                        foreach (var number in numbers)
                        {
                            _numbersList.Add(int.Parse(number.ToString()));
                        }
                    }

                    else
                    {
                        MessageBox.Show("Error scanning network");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }));
        }

        private void PreviousScan()
        {
            // TODO implement previous scan logic
        }
    }
}

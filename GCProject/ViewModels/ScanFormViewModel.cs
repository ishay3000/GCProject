using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                Dictionary<string, string> requestDictionary = new Dictionary<string, string>
                {
                    {"Command", "Scan"}, {"Args", "New"}
                };

                string jsonRequest = JsonConvert.SerializeObject(requestDictionary);
                dynamic response = await Client.INSTANCE.SendAndReceiveAsync(jsonRequest);

                /*
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
                */

            }));
        }

        private void PreviousScan()
        {
            // TODO implement previous scan logic
        }
    }
}

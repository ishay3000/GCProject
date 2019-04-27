using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GCProject.ClientService;
using Newtonsoft.Json;

namespace GCProject.Misc
{
    static class TelephonyScanner
    {
        public static async Task<List<int>> ScanAsyncTask(string request)
        {
            List<int> numbersList = null;
            string response = await Client.INSTANCE.SendAndReceiveAsync(request);

            try
            {
                dynamic result = JsonConvert.DeserializeObject(response);
                var status = result["Status"];

                if (status != null && status.ToString() == "OK")
                {
                    numbersList = new List<int>();
                    var numbers = result["Result"];
                    foreach (var number in numbers)
                    {
                        numbersList.Add(int.Parse(number.ToString()));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return numbersList;
        }
    }
}

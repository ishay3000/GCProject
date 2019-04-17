using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GCProject.Miscellanies
{
    static class TelephonyScanner
    {
        public static async Task<List<int>> ScanAsyncTask(object args)
        {
            return await Task.Run(async () =>
            {
                var requestDictionary = new Dictionary<string, object>();
                requestDictionary["Command"] = "Scan";
                requestDictionary["Args"] = args;

                List<int> numbersList = null;

                string jsonRequest = JsonConvert.SerializeObject(requestDictionary);
                string response = await Client.INSTANCE.SendAndReceiveAsync(jsonRequest);

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
            });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GCProject.Miscellanies
{
    class JRequest
    {
        public readonly Dictionary<string, object> _requestDictionary;

        public JRequest(string type, object args)
        {
            _requestDictionary = new Dictionary<string, object>();
            _requestDictionary["ScanType"] = type;
            _requestDictionary["Args"] = args;
        }

        public string ToJson()
        {
            string jsonRequest = JsonConvert.SerializeObject(_requestDictionary);
            return jsonRequest;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (var o in _requestDictionary)
            {
                builder.Append(o.Key + ": " + o.Value + "\n");
            }

            return builder.ToString();
        }
    }
}

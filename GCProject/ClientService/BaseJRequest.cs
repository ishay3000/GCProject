using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GCProject.ClientService
{
    abstract class BaseJRequest
    {
        protected Dictionary<string, object> RequestDictionary = new Dictionary<string, object>();
        private string _commandType;

        protected string CommandType
        {
            get { return _commandType; }
            set
            {
                _commandType = value;
                RequestDictionary["Command"] = _commandType;
            }
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(RequestDictionary);
        }
    }
}

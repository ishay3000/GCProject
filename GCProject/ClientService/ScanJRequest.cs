using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GCProject.ClientService
{
    class ScanJRequest : BaseJRequest
    {
        public ScanJRequest(string scanType, object scanArgs)
        {
            base.CommandType = "Scan";
            RequestDictionary["Args"] = new {ScanType = scanType, ScanArgs = scanArgs};
            //RequestDictionary["ScanType"] = scanType;
            //RequestDictionary["ScanArgs"] = scanArgs;
        }
    }
}

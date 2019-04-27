using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GCProject.ClientService
{
    class CallManagerJRequest : BaseJRequest
    {
        public CallManagerJRequest()
        {
            base.CommandType = "CallManager";
        }
    }
}

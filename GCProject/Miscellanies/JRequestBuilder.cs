using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCProject.Miscellanies
{
    sealed class JRequestBuilder : IJRequestBuilder, IJRequestScanType, IJRequestScanArgs
    {
        private string _scanType;
        private object _scanArgs;

        public static IJRequestScanType CreateNew()
        {
            return new JRequestBuilder();
        }

        public JRequest Build()
        {
            return new JRequest(_scanType, _scanArgs);
        }

        public IJRequestScanArgs SetScanType(string scanType)
        {
            _scanType = scanType;
            return this;
        }

        public IJRequestBuilder SetScanArgs(object scanArgs)
        {
            _scanArgs = scanArgs;
            return this;
        }
    }
}

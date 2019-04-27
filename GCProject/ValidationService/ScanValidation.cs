using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GCProject.ValidationService
{
    static class ScanValidation
    {
        /// <summary>
        /// Validates a new scan
        /// </summary>
        /// <param name="start">start range</param>
        /// <param name="end">end range</param>
        /// <param name="whitelist">whitelist numbers</param>
        /// <returns>whether the parameters are valid</returns>
        public static Tuple<bool, string> ValidateNew(string start, string end, List<int> whitelist)
        {
            StringBuilder errorBuilder = new StringBuilder();
            bool isValid = true;

            if (!IsValidRange(start, end))
            {
                errorBuilder.AppendLine("You must set a valid scan range");
            }

            if (whitelist == null || whitelist.Count < 1)
            {
                errorBuilder.AppendLine("You must set a valid whitelist");
            }

            if (errorBuilder.Length > 0)
            {
                isValid = false;
            }

            return new Tuple<bool, string>(isValid, errorBuilder.ToString());
        }

        private static bool IsValidRange(string start, string end)
        {
            int a, b;
            if (int.TryParse(start, out a) && int.TryParse(end, out b))
            {
                if (a < b)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Validates a previous scan
        /// </summary>
        /// <param name="scanName">the scan's name</param>
        /// <returns>whether the scan parameter is valid</returns>
        public static Tuple<bool, string> ValidatePrevious(string scanName)
        {
            StringBuilder errorBuilder = new StringBuilder();
            bool isValid = true;

            if (string.IsNullOrEmpty(scanName))
            {
                errorBuilder.AppendLine("You must enter a scan name");
            }

            if (errorBuilder.Length > 0)
            {
                isValid = false;
            }

            return new Tuple<bool, string>(isValid, errorBuilder.ToString());
        }
    }
}

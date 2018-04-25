using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATP2.BDAID.Framework.Helper
{
    public class ValidationHelper
    {
        public static bool IsStringValid(string data)
        {
            if (string.IsNullOrEmpty(data) || string.IsNullOrWhiteSpace(data))
                return false;
            return true;
        }
        public static bool IsIntValid(string data)
        {
            int value;
            return Int32.TryParse(data, out value);
        }

        public static bool IsFloatValid(string data)
        {
            float value;
            return float.TryParse(data, out value);
        }
    }
}

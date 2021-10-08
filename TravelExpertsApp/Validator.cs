using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelExpertsApp
{
    public static class Validator
	{
        public static string LineEnd { get; set; } = "\n";

        public static string IsPresent(string value, string name)
        {
            string msg = "";
            if (value == "")
            {
                msg += name + " is a required field." + LineEnd;
            }
            return msg;
        }

        public static string IsDecimal(string value, string name)
        {
            string msg = "";
            if (!Decimal.TryParse(value, out _))
            {
                msg += name + " must be a valid decimal value." + LineEnd;
            }
            return msg;
        }

        // The IsInt32 and IsWithinRange methods were omitted from figure 12-15.
        public static string IsInt32(string value, string name)
        {
            string msg = "";
            if (!Int32.TryParse(value, out _))
            {
                msg += name + " must be a valid integer value." + LineEnd;
            }
            return msg;
        }

        public static string IsWithinRange(string value, string name, decimal min,
            decimal max)
        {
            string msg = "";
            if (Decimal.TryParse(value, out decimal number))
            {
                if (number < min || number > max)
                {
                    msg += name + " must be between " + min + " and " + max + "." + LineEnd;
                }
            }
            return msg;
        }

        //public static string IsDate(string value, string name)
        //{
        //    string msg = "";
        //    if (!DateTime.TryParse(value, out _))
        //    {
        //        msg += name + " must be a valid date." + LineEnd;
        //    }
        //    return msg;
        //}

        public static string IsDate(string dateValue, string name)
        {
            string msg = "";
            DateTime temp;
            if (DateTime.TryParse(dateValue, out temp))
                return msg = "";
            else
                return msg += name + " must be a valid date in the format MM/DD/YYYY or YYYY-MM-DD." + LineEnd;
        }


    }
}

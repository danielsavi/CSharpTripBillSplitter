using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperLibrary
{
    public static class Bill
    {
        public static decimal Calc(decimal tripAmount, decimal personAmount, int numberOfPeople)
        {
            if (numberOfPeople == 0)
            {
                throw new ArgumentException("numberOfPeople should be greater than zero");
            }

            return (tripAmount / numberOfPeople) - personAmount;
        }

        public static string FormatDecimalToCustomString(decimal value)
        {
            return (value < 0) ? string.Format("(${0})", Math.Round(value * -1, 2)) :
                                 string.Format("${0}", Math.Round(value, 2));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorUtility;
using CalculatorUtility.RateUtility;

namespace BorrowerUtility
{
    public class BorrowerRateContract : IRateContract
    {
        public decimal AnnualRate { get; set; }
        public int DurationInMonth { get; set; }
        public decimal AnnualPercentageRate => AnnualRate * 100;
    }
}

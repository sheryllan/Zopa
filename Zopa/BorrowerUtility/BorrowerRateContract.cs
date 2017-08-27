using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorUtility;

namespace BorrowerUtility
{
    public class BorrowerRateContract : IRateContract
    {
        public decimal AnnualRate { get; set; }
        public int ContractDuration { get; set; }
        public decimal AnnualPercentageRate => AnnualRate * 100;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorUtility
{
    public class RateContract : IRateContract
    {
        public decimal AnnualRate { get; set; }
        public int ContractDuration { get; set; }


    }
}

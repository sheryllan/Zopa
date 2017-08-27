using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorUtility;

namespace LenderUtility
{
    public class Offer 
    {
        public string Name { get; set; }
        public decimal AvailabeAmt { get; set; }
        public IRateContract RateContract { get; set; }


        public virtual decimal GetExpectedReturn()
        {
            throw new NotImplementedException();
        }
    }
}

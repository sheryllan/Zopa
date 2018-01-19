using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorUtility;
using CalculatorUtility.PaymentUtility;
using CalculatorUtility.RateUtility;
using System.ComponentModel;

namespace BorrowerUtility
{
    public class Quote
    {
        public decimal Loan { get; set; }
        public Rate RateContract { get; set; }
        public Payment Repayment { get; set; }

    }
}

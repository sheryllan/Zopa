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
    public class QuoteByMonth : IQuote
    {
        public decimal Loan { get; set; }
        public RateContract RateContract { get; set; }
        public PaymentByMonth Repayment { get; set; }
        IRateContract IQuote.RateContract { get; set; }
        IPayment IQuote.RePayment { get; set; }

    }
}

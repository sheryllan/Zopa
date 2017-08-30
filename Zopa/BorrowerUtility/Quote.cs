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
    public class Quote : IQuote
    {
        public decimal Loan { get; set; }
        public IRateContract RateContract { get; set; }
        public IPayment Repayment { get; set; }

        public Quote() { }
        public Quote(IQuote q)
        {
            Loan = q.Loan;
            RateContract = q.RateContract;
            Repayment = q.Repayment;
        }

    }
}

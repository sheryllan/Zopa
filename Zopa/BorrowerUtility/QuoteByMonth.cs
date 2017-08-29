using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorUtility;
using CalculatorUtility.PaymentUtility;
using CalculatorUtility.RateUtility;

namespace BorrowerUtility
{
    public class QuoteByMonth : IQuote
    {
        private PaymentByMonth _rePaymentByMonth;
        private IPayment _rePayment;
        public decimal Loan { get; set; }
        public IRateContract RateContract { get; set; }

        public IPayment RePayment
        {
            get => _rePayment;
            set
            {
                _rePayment = value;
                _rePaymentByMonth = new PaymentByMonth()
                {
                    Instalments = value.Instalments,
                    TotalAmt = value.TotalAmt
                };
            }
        }

        public decimal AnnualPercentageRate => RateContract.AnnualRate * 100;
        public decimal MonthlyPayment => _rePaymentByMonth.MonthlyAmt;
    }
}

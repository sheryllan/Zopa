using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorUtility.PaymentUtility;
using CalculatorUtility.RateUtility;

namespace LenderUtility
{
    public class Offer
    {
        public string Name { get; set; }
        public decimal AvailabeAmt { get; set; }
        public Rate RateContract { get; set; }

        public decimal GetExpectedReturn(IPaymentCalculator calculator)
        {
            var payment = calculator.GetPaymentGivenRate(AvailabeAmt, RateContract);
            return payment.TotalAmt;
        }
    }
}

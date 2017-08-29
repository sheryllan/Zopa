using System;
using CalculatorUtility.MathUtility;
using CalculatorUtility.RateUtility;

namespace CalculatorUtility.PaymentUtility
{
    // Payment calculator that generates equally monthly payment by fixed rate
    public class PaymentCalculatorByMonth : IPaymentCalculator
    {
        private decimal MonthlyPaymentFunc(decimal capital, IRateContract rate)
        {
            var r = 1 + rate.AnnualRate / 12;
            var n = rate.TermsInMonth;
            var rn = Polynomial.Power(r, n);
            return capital * rn * (r - 1) / (rn - 1);
        }
        public IPayment GetPaymentGivenRate(decimal capital, IRateContract rate, int decimals = 2)
        {
            return new PaymentByMonth()
            {
                Instalments = rate.TermsInMonth,
                TotalAmt = Math.Round(rate.TermsInMonth * MonthlyPaymentFunc(capital, rate), decimals)
            };

        }

        public PaymentByMonth GetPaymentByMonthGivenRate(decimal capital, IRateContract rate, int decimals = 2)
        {
            var payment = GetPaymentGivenRate(capital, rate, decimals);
            return new PaymentByMonth()
            {
                Instalments = payment.Instalments,
                TotalAmt = payment.TotalAmt
            };
        }
    }
}

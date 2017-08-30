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
            var n = rate.Months;
            var rn = Polynomial.Power(r, n);
            return capital * rn * (r - 1) / (rn - 1);
        }

        public PaymentByMonth GetPaymentGivenRate(decimal capital, IRateContract rate, int decimals = 2)
        {
            return new PaymentByMonth()
            {
                Instalments = rate.Months,
                TotalAmt = Math.Round(rate.Months * MonthlyPaymentFunc(capital, rate), decimals)
            };
        }

        IPayment IPaymentCalculator.GetPaymentGivenRate(decimal capital, IRateContract rate, int decimals)
        {
            return GetPaymentGivenRate(capital, rate, decimals);
        }
    }
}

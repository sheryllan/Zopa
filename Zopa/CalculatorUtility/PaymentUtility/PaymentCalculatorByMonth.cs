using System;
using CalculatorUtility.MathUtility;
using CalculatorUtility.RateUtility;

namespace CalculatorUtility.PaymentUtility
{
    // Payment calculator that generates equally monthly payment by fixed rate
    public class PaymentCalculatorByMonth : IPaymentCalculator
    {
        private decimal MonthlyPaymentFunc(decimal capital, RateByMonth rate)
        {
            var r = 1 + rate.AnnualRate / 12;
            var n = rate.Months;
            var rn = Polynomial.Power(r, n);
            return capital * rn * (r - 1) / (rn - 1);
        }

        public Payment GetPaymentGivenRate(decimal capital, Rate rate, int decimals = 2)
        {
            var mRate = rate as RateByMonth;
            if (mRate == null) throw new NullReferenceException("Error: Cannot cast Rate to RateByMonth.");
            return new PaymentByMonth()
            {
                Instalments = mRate.Months,
                TotalAmt = Math.Round(mRate.Months * MonthlyPaymentFunc(capital, mRate), decimals)
            };
        }

    }
}

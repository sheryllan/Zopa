using System;
using CalculatorUtility.RateUtility;

namespace CalculatorUtility.PaymentUtility
{
    // Payment calculator that generates equally monthly payment by fixed rate
    public class PaymentCalculatorByMonth : IPaymentCalculator
    {
        public IPayment GetPaymentGivenRate(decimal capital, IRateContract rate, int decimals = 2)
        {
            throw new NotImplementedException();
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

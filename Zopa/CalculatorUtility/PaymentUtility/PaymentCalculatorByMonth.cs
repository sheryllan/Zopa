using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorUtility
{
    // Payment calculator that generates equally monthly payment by fixed rate
    public class PaymentCalculatorByMonth : IPaymentCalculator
    {
        public IPayment GetPaymentGivenRate(decimal capital, IRateContract rate)
        {
            throw new NotImplementedException();
        }

        public PaymentByMonth GetPaymentByMonthGivenRate(decimal capital, IRateContract rate)
        {
            var payment = GetPaymentGivenRate(capital, rate);
            return new PaymentByMonth()
            {
                Instalments = payment.Instalments,
                TotalAmt = payment.TotalAmt
            };
        }
    }
}

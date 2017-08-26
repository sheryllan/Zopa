using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorUtility
{
    // Payment calculator that generates equally monthly payment by fixed rate
    public class MpPaymentCalculator : IPaymentCalculator
    {
        public IPayment GetPaymentByRate(decimal capitals, IRate rate)
        {
            throw new NotImplementedException();
        }
    }
}

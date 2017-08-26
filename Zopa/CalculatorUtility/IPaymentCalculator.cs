using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorUtility
{
    public interface IPaymentCalculator
    {
        IPayment GetPaymentByRate(decimal capitals, IRate rate);
    }
}

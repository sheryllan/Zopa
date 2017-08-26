using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorUtility
{
    // Rate calculator based on monthly payback
    public class MpRateCalculator : IRateCalculator
    {
        public IRate GetRateByPayment(IPayment p)
        {
            throw new NotImplementedException();
        }
    }
}

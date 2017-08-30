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
    public interface IQuote
    {
        decimal Loan { get; set; }
        IRateContract RateContract { get; set; }
        IPayment RePayment { get; set; }
    }
}

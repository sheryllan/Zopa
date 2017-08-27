using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorUtility;

namespace BorrowerUtility
{
    public class QuoteByMonth : IQuote
    {
        public decimal Loan { get; set; }
        public IRateContract RateContract { get; set; }
        public IPayment RePayment { get; set; }

        public BorrowerRateContract RateContractByMonth => new BorrowerRateContract()
        {
            AnnualRate = RateContract.AnnualRate,
            ContractDuration = RateContract.ContractDuration
        };

        public PaymentByMonth RePaymentByMonth => new PaymentByMonth()
        {
            Instalments = RePayment.Instalments,
            TotalAmt = RePayment.TotalAmt
        };
    }
}

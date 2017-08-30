using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BorrowerUtility;
using CalculatorUtility.PaymentUtility;

namespace Zopa
{
    public class QuoteViewModel
    {
        public Quote Model { get; set; }
        public PaymentByMonth Repayment => new PaymentByMonth(Model.Repayment);
        public decimal Loan => Model.Loan;
        public decimal PercentageRate => Math.Round(Model.RateContract.AnnualRate * 100, 1);
        public decimal MonthlyRepayment => Math.Round(Repayment.MonthlyAmt, 2);
        public decimal TotalRepayment => Math.Round(Repayment.TotalAmt, 2);

        public QuoteViewModel(Quote quote)
        {
            Model = quote;
        }
    }
}

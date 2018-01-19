using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BorrowerUtility;
using CalculatorUtility.PaymentUtility;
using CalculatorUtility.RateUtility;

namespace Zopa
{
    public class QuoteByMonthViewModel
    {
        private PaymentByMonth _payment;
        private RateByMonth _rate;
        private Quote _model;

        public Quote Model
        {
            get => _model;
            set
            {
                _model = value; 
                _payment = _model.Repayment as PaymentByMonth;
                _rate = _model.RateContract as RateByMonth;
            }
        }
        public decimal Loan => Model.Loan;
        public decimal PercentageRate => Math.Round(_rate.AnnualRate * 100, 1);
        public decimal MonthlyRepayment => Math.Round(_payment.MonthlyAmt, 2);
        public decimal TotalRepayment => Math.Round(_payment.TotalAmt, 2);

        public QuoteByMonthViewModel(Quote quote)
        {
            Model = quote;
        }
    }
}

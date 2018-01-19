using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using CalculatorUtility.PaymentUtility;
using CalculatorUtility.RateUtility;
using LenderUtility;
using MarketDataAccess;


namespace BorrowerUtility
{
    public class Borrower : IBorrower
    {
        private ILenderPool _pool;
        private IPaymentCalculator _pCalculator;
        private IRateCalculator _rCalculator;
        private readonly decimal _increment;

        public int LoanDuration { get; }
        public int UpperLoanLimit { get; }
        public int LowerLoanLimit { get; }

        public Borrower(ILenderPool pool, IPaymentCalculator pCalculator = null, IRateCalculator rCalculator = null)           
        {
            _pool = pool;
            _pCalculator = pCalculator?? new PaymentCalculatorByMonth();
            _rCalculator = rCalculator?? new RateCalculatorByMonth();
            _increment = 100m;
            LoanDuration = 36;
            UpperLoanLimit = 15000;
            LowerLoanLimit = 1000;
        }

        private bool Validate(decimal amount)
        {
            var isInRange = amount >= LowerLoanLimit && amount <= UpperLoanLimit;
            var isOfIncrement = amount % _increment == LowerLoanLimit % _increment;
            return isInRange && isOfIncrement;
        }

        public Quote GetQuoteWithLowestRate(decimal amount)
        {
            if (!Validate(amount))
                throw new ArgumentOutOfRangeException(null, "Reqest FAILED: Invalid input amount");
            var offers = _pool.FindBestOffersForLoan(amount);
            if (offers == null) return null;
            var last = offers.FindLast(o => o.RateContract.AnnualRate == offers.Max(x => x.RateContract.AnnualRate));
            var extra = (offers.Sum(o => o.AvailabeAmt) - amount) / last.AvailabeAmt * last.GetExpectedReturn(_pCalculator);
            var totalPayment = offers.Sum(o => o.GetExpectedReturn(_pCalculator)) - extra;
            var payment = new Payment { Instalments = LoanDuration, TotalAmt = Math.Round(totalPayment, 2) };
            var rate = _rCalculator.GetRateGivenPayment(payment, amount);
            return new Quote
            {
                Loan = amount,
                RateContract = rate,
                Repayment = payment
            };
        }
    }
}

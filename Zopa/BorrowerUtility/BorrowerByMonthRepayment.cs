using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorUtility.PaymentUtility;
using CalculatorUtility.RateUtility;
using LenderUtility;
using MarketDataAccess;


namespace BorrowerUtility
{
    public class BorrowerByMonthRepayment : Borrower
    {
        private ILenderPool _pool;
        private IPaymentCalculator _pCalculator;
        private IRateCalculator _rCalculator;

        public BorrowerByMonthRepayment(IMarketProvider provider) 
            : base(duration: 36, upper: 15000, lower: 1000)
        {
            _pool = new LenderPool(provider);
            _pCalculator = new PaymentCalculatorByMonth();
            _rCalculator = new RateCalculatorByMonth();
        }

        public BorrowerByMonthRepayment(ILenderPool pool, IPaymentCalculator pCalculator, IRateCalculator rCalculator)
            : base(duration: 36, upper: 15000, lower: 1000)
        {
            _pool = pool;
            _pCalculator = pCalculator;
            _rCalculator = rCalculator;
        }

        public override IQuote GetQuoteWithLowestRate(decimal amount)
        {
            var offers = _pool.FindBestOffersForLoan(amount);
            if (offers == null) return null;
            var last = offers.FindLastIndex(o => o.RateContract.AnnualRate == offers.Max(x => x.RateContract.AnnualRate));
            offers[last].AvailabeAmt -= (amount - offers.Sum(o => o.AvailabeAmt));
            var totalPayment = offers.Sum(o => o.GetExpectedReturn(_pCalculator));
            var paymentByMonth = new PaymentByMonth {Instalments = LoanDuration, TotalAmt = totalPayment};
            var rate = _rCalculator.GetRateGivenPayment(paymentByMonth, amount);
            return new QuoteByMonth
            {
                Loan = amount,
                RateContract = rate,
                RePayment = paymentByMonth
            };
        }

        public QuoteByMonth GetQuoteByMonthWithLowestRate(decimal amount)
        {
            var quote = GetQuoteWithLowestRate(amount);
            return new QuoteByMonth()
            {
                Loan = quote.Loan,
                RateContract = quote.RateContract,
                RePayment = quote.RePayment
            };
        }
    }
}

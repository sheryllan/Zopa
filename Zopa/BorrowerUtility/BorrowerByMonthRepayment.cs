using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LenderUtility;
using MarketDataAccess;


namespace BorrowerUtility
{
    public class BorrowerByMonthRepayment : Borrower
    {
        private LenderPool _pool;

        public BorrowerByMonthRepayment(IMarketProvider provider) 
            : base(duration: 36, upper: 1500, lower: 1000)
        {
            _pool = new LenderPool(provider);
        }

        public override IQuote GetQuoteWithLowestRate(decimal amount)
        {
            throw new NotImplementedException();
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LenderUtility;
using MarketDataAccess;


namespace BorrowerUtility
{
    public class BorrowerLongTerm : Borrower
    {
        
        private LenderPool _pool;

        public BorrowerLongTerm(IMarketProvider provider) 
            : base(duration: 36, upper: 1500, lower: 1000)
        {
            _pool = new LenderPool(provider);
        }

        public override Quote GetQuoteWithLowestRate(int amount)
        {
            throw new NotImplementedException();
        }
    }
}

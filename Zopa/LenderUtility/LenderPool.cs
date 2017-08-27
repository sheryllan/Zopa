using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using MarketDataAccess;

namespace LenderUtility
{
    public class LenderPool
    {
        private readonly IMarketProvider _provider;

        public LenderPool(IMarketProvider provider)
        {
            _provider = provider;
        }

        public List<Offer> AllOffers
        {
            get { return null; }
        }


        public List<Offer> GetBestOffersForALoan(decimal loan)
        {
           throw new NotImplementedException();
        }
    }
}

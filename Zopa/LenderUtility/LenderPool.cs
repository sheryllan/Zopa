using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<Offer> GetAllOffers()
        {
            throw new NotImplementedException();
        }

        public List<Offer> GetInterestedOffers(Predicate<List<Offer>> filter)
        {
           if(filter(GetAllOffers()))
            { }
           throw new NotImplementedException();
        }
    }
}

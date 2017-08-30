using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using CalculatorUtility.RateUtility;
using MarketDataAccess;

namespace LenderUtility
{
    public class LenderPool : ILenderPool
    {
        private readonly IMarketProvider _provider;

        public LenderPool(IMarketProvider provider)
        {
            _provider = provider;
        }

        public List<Offer> AllOffers
        {
            get
            {
                var table = _provider.ReadMarket();
                return table.Select().Select(r => new Offer()
                {
                    Name = r[(int)Columns.Name].ToString(),
                    AvailabeAmt = Convert.ToDecimal(r[(int)Columns.Available]),
                    RateContract = new RateContract
                    {
                        AnnualRate = Convert.ToDecimal(r[(int)Columns.Rate]),
                        Months = _provider.Market.Months
                    }
                }).ToList();
                
            }
        }

        public List<Offer> FindBestOffersForLoan(decimal loan)
        {
            var offers = AllOffers.OrderBy(o => o.RateContract.AnnualRate);
            var condition = new Predicate<decimal>(x => x > loan);
            var total = 0m;
            var result = offers.TakeWhile(o => !condition(total += o.AvailabeAmt)).ToList();
            return condition(total) ? result : null;

        }
    }
}

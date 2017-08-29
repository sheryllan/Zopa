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
                    Name = (string)r[(int)Columns.Name],
                    AvailabeAmt = (decimal)r[(int)Columns.Available],
                    RateContract = new RateContract()
                    {
                        AnnualRate = (decimal)r[(int)Columns.Rate],
                        TermsInMonth = (int)r[(int)Columns.TermsInMonth]
                    }
                }).ToList();
                
            }
        }


        public List<Offer> FindBestOffersForLoan(Predicate<decimal> loan)
        {
            var offers = AllOffers.OrderBy(o => o.RateContract.AnnualRate);
            if (loan == null)
                return new List<Offer> { offers.ToArray()[0] };
            
            var total = 0m;
            var result = offers.TakeWhile(o => !loan(total += o.AvailabeAmt)).ToList();
            return loan(total) ? result : null;

        }
    }
}

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
    public class LenderPool
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
                var table = _provider.ReadLenderPool();
                return table.Select().Select(r => new Offer()
                {
                    Name = (string)r[(int)Columns.Name],
                    AvailabeAmt = (decimal)r[(int)Columns.Available],
                    RateContract = new RateContract()
                    {
                        AnnualRate = (decimal)r[(int)Columns.Rate],
                        DurationInMonth = (int)r[(int)Columns.DurationInMonth]
                    }
                }).ToList();
                
            }
        }


        public List<Offer> FindBestOffersByConditions(Conditions conditions)
        {
            var offers = AllOffers.OrderBy(o => o.RateContract.AnnualRate);
            if (conditions == null)
                return new List<Offer>(){ offers.ToArray()[0] };
            if (conditions.OverallCondition == null)
                conditions.OverallCondition = x => true;
            var totalLoan = 0m;

            return offers.TakeWhile(o => conditions.TotalLoan(totalLoan += o.AvailabeAmt)).ToList();



        }
    }
}

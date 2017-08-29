using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorUtility.RateUtility;
using LenderUtility;
using MarketDataAccess;

namespace UnitTests.Mocks
{
    public class MockLenderPool : ILenderPool
    {
        public MockLenderPool(List<Offer> allOffers)
        {
            AllOffers = allOffers;
        }

        public List<Offer> AllOffers { get; }
        public List<Offer> FindBestOffersForLoan(Predicate<decimal> loan)
        {
            throw new NotImplementedException();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using LenderUtility;
using MarketDataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class LenderUtilityTests
    {
        private MockMarketData _mockMarket = new MockMarketData();


        [TestMethod]
        public void TestGetOffersWhenPoolHasNoSufficientOffer()
        {
            var poolSizeUnder1000 = new LenderPool(new MockCsvMarketProvider(_mockMarket.GetTableWithTotalUnder1000()));
            var poolSizeUnder1500 = new LenderPool(new MockCsvMarketProvider(_mockMarket.GetTableWithTotalUnder1500()));
            var filterPoolAtLeast1000 = new Predicate<List<Offer>>(offers => offers.Sum(o => o.AvailabeAmt) >= 1000);
            var filterPoolAtLeast1500 = new Predicate<List<Offer>>(offers => offers.Sum(o => o.AvailabeAmt) >= 1500);

            Assert.IsNull(poolSizeUnder1000.GetInterestedOffers(filterPoolAtLeast1000));
            Assert.IsNull(poolSizeUnder1500.GetInterestedOffers(filterPoolAtLeast1500));

        }

    }
}

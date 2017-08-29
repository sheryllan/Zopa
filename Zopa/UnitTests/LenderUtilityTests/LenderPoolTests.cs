using LenderUtility;
using MarketDataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTests.Mocks;

namespace UnitTests.LenderUtilityTests
{
    [TestClass]
    public class LenderUtilityTests
    {
        private MockMarketData _mockMarket = new MockMarketData();
        private IMarket _market = new LongTermLoanMarket(MarketType.LongerTerm, 36);
        private MockLenderPool _mockPool = new MockLenderPool();

        [TestMethod]
        public void TestGetAllOffers()
        {
            var lenderPoolSizeOver1500 = new LenderPool(new MockCsvMarketProvider(_mockMarket.GetTableWithTotalOver1500(), _market));
            var allOffersOver1500 = lenderPoolSizeOver1500.AllOffers;
            var allOffersOver1500Expected = _mockPool.GetOffersWithTotalOver1500();
            CollectionAssert.AreEqual(allOffersOver1500Expected, allOffersOver1500);

        }

        [TestMethod]
        public void TestGetOffersWhenPoolHasNoSufficientOffer()
        {
            var poolSizeUnder1000 = new LenderPool(new MockCsvMarketProvider(_mockMarket.GetTableWithTotalUnder1000(), _market));
            var poolSizeUnder1500 = new LenderPool(new MockCsvMarketProvider(_mockMarket.GetTableWithTotalUnder1500(), _market));

            Assert.IsNull(poolSizeUnder1000.FindBestOffersForLoan(null));
            Assert.IsNull(poolSizeUnder1500.FindBestOffersForLoan(null));
        }

        [TestMethod]
        public void TestGetOffersWhenPoolHasSufficientOffer()
        {
            var poolSizeOver1500 = new LenderPool(new MockCsvMarketProvider(_mockMarket.GetTableWithTotalOver1500(), _market));
            Assert.IsNull(poolSizeOver1500.FindBestOffersForLoan(null));
        }

    }
}

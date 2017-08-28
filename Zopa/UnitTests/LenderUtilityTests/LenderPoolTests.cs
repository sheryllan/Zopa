using LenderUtility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTests.Mocks;

namespace UnitTests.LenderUtilityTests
{
    [TestClass]
    public class LenderUtilityTests
    {
        private MockMarketData _mockMarket = new MockMarketData();

        [TestMethod]
        public void TestGetAllOffers()
        {
            var lenderPoolSizeOver1500 = new LenderPool(new MockCsvMarketProvider(_mockMarket.GetTableWithTotalOver1500()));
            var allOffersOver1500 = lenderPoolSizeOver1500.AllOffers;
            var allOffersOver1500Expected = _mockMarket.GetOffersWithTotalOver1500();
            CollectionAssert.AreEqual(allOffersOver1500Expected, allOffersOver1500);

        }

        [TestMethod]
        public void TestGetOffersWhenPoolHasNoSufficientOffer()
        {
            var poolSizeUnder1000 = new LenderPool(new MockCsvMarketProvider(_mockMarket.GetTableWithTotalUnder1000()));
            var poolSizeUnder1500 = new LenderPool(new MockCsvMarketProvider(_mockMarket.GetTableWithTotalUnder1500()));

            Assert.IsNull(poolSizeUnder1000.FindBestOffersByConditions(null));
            Assert.IsNull(poolSizeUnder1500.FindBestOffersByConditions(null));
        }

        [TestMethod]
        public void TestGetOffersWhenPoolHasSufficientOffer()
        {
            var poolSizeOver1500 = new LenderPool(new MockCsvMarketProvider(_mockMarket.GetTableWithTotalOver1500()));
            Assert.IsNull(poolSizeOver1500.FindBestOffersByConditions(null));
        }

    }
}

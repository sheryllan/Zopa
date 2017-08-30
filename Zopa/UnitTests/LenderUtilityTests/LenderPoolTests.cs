using System.Collections.Generic;
using System.Data;
using System.Linq;
using BorrowerUtility;
using CalculatorUtility.PaymentUtility;
using CalculatorUtility.RateUtility;
using LenderUtility;
using MarketDataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ploeh.SemanticComparison;
using Ploeh.SemanticComparison.Fluent;
using UnitTests.Comparers;
using UnitTests.Mocks;

namespace UnitTests.LenderUtilityTests
{
    [TestClass]
    public class LenderUtilityTests
    {
        private Mock<IMarketProvider> _mockProvider;
        private LenderPool _pool;

        [TestInitialize]
        public void Initialize()
        {
            _mockProvider = new IMarketProviderMockGenerator().MockObject;
            _pool = new LenderPool(_mockProvider.Object);
        }

        [TestMethod]
        public void TestGetAllOffers()
        {
            var allOffers = _pool.AllOffers;
            var allOffersExpected = new ILenderPoolMockGenerator().MockOffers;
            var comparer = Semantic.OfferComparer;
            Assert.IsTrue(allOffers.SequenceEqual(allOffersExpected, comparer));
        }

        [TestMethod]
        public void TestFindBestOffersForLoanWhenPoolHasNoSufficientOffer()
        {
            Assert.IsNull(_pool.FindBestOffersForLoan(10000m));
        }

        [TestMethod]
        public void TestFindBestOffersForLoanWhenPoolHasSufficientOffer()
        {
            var offers = _pool.FindBestOffersForLoan(1000m);
            Assert.IsTrue(offers.Sum(o => o.AvailabeAmt) >= 1000m);

            var comparer = Semantic.OfferComparer;
            var rest = _pool.AllOffers.Where(r => !offers.Exists(o => comparer.Equals(o, r)));
            var maxRateInFoundOffers = offers.Max(o => o.RateContract.AnnualRate);
            var minRateInRestOffers = rest.Min(r => r.RateContract.AnnualRate);
            Assert.IsTrue(maxRateInFoundOffers <= minRateInRestOffers);
        }

    }
}

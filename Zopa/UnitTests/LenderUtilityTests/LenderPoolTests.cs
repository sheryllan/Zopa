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
using UnitTests.MockGenerators;

namespace UnitTests.LenderUtilityTests
{
    [TestClass]
    public class LenderUtilityTests
    {
        private Mock<IMarketProvider> _mockProvider;
        private Mock<ILenderPool> _mockPool;
        private LenderPool _pool;

        [TestInitialize]
        public void Initialize()
        {
            var mcMockGen = new IMarketProviderMockGenerator();
            var lpMockGen = new ILenderPoolMockGenerator();
            _mockProvider = mcMockGen.MockObject;
            _mockPool = lpMockGen.MockOject;
            mcMockGen.SetupReadMarket();
            lpMockGen.SetupAllOffers();
            _pool = new LenderPool(_mockProvider.Object);
        }

        [TestMethod]
        public void TestGetAllOffers()
        {
            var allOffers = _pool.AllOffers;
            var allOffersExpected = _mockPool.Object.AllOffers;
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

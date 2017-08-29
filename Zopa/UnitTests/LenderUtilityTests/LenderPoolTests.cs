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
            Assert.IsNull(_pool.FindBestOffersForLoan(x => x > 10000m));
        }

        [TestMethod]
        public void TestFindBestOffersForLoanWhenPoolHasSufficientOffer()
        {
            var offers = _pool.FindBestOffersForLoan(x => x > 1000m);
            Assert.IsTrue(offers.Sum(o => o.AvailabeAmt) >= 1000m);

            var comparer = Semantic.OfferComparer;
            var rest = _pool.AllOffers.Where(r => !offers.Exists(o => comparer.Equals(o, r)));
            var maxRateInFoundOffers = offers.Max(o => o.RateContract.AnnualRate);
            var minRateInRestOffers = rest.Min(r => r.RateContract.AnnualRate);
            Assert.IsTrue(maxRateInFoundOffers <= minRateInRestOffers);
        }

        [TestMethod]
        public void TestLikenessWithNest()
        {
            var o1 = new Offer
            {
                Name = "Samuel",
                AvailabeAmt = 188.9m,
                RateContract = new RateContract()
                {
                    AnnualRate = 0.071m,
                    TermsInMonth = 36
                }
            };

                       
            var o3 = new Offer
            {
                Name = "Samuel",
                AvailabeAmt = 188.9m,
                RateContract = new RateContract()
                {
                    AnnualRate = 0.071m,
                    TermsInMonth = 36
                }
            };

            var r1 = new RateContract(){AnnualRate = 0.0078m, TermsInMonth = 36};
            var r2 = new Likeness<IRateContract>(r1, new SemanticComparer<IRateContract, IRateContract>());
            var r3 = new RateContract(){ AnnualRate = 0.0078m, TermsInMonth = 36 };
            var sut = new SemanticComparer<IRateContract,IRateContract>();
            var suto = new SemanticComparer<Offer>(new MemberComparer(new SemanticComparer<RateContract, RateContract>()));
            var o2 = new Likeness<Offer>(o1, suto);

            var q1 = new QuoteByMonth()
            {
                Loan = 1000m,
                RateContract = r1,
                RePayment = new Payment() { Instalments = 36, TotalAmt = 1007.8m}
            };
            var q3 = new QuoteByMonth()
            {
                Loan = 1000m,
                RateContract = r3,
                RePayment = new Payment() { Instalments = 36, TotalAmt = 1007.8m }
            };
            var suq = new SemanticComparer<IQuote>(new MemberComparer(new SemanticComparer<IRateContract,IRateContract>()), 
                new MemberComparer(new SemanticComparer<IPayment, IPayment>()));

            Assert.IsTrue(sut.Equals(r1,r3));
            Assert.IsTrue(suto.Equals(o1,o3));
            Assert.IsTrue(suq.Equals(q1,q3));
            //Assert.AreEqual(r1, r2);
            //Assert.AreEqual(o1, o2);
        }

    }
}

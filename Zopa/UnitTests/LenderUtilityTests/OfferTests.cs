using System;
using CalculatorUtility.PaymentUtility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using UnitTests.Mocks;
using UnitTests.TestData;

namespace UnitTests.LenderUtilityTests
{
    [TestClass]
    public class OfferTests
    {
        [TestMethod]
        public void TestGetExpectedReturnUsingByMonthCalculator()
        {
            var testCases = GetPaymentGivenRate.Cases;
            var gen = new IPaymentCalculatorMockGenerator();
            gen.SetupGetPaymentGivenRate();
            var calculator = gen.MockObject.Object;
            
            Assert.IsTrue(Math.Abs(testCases[0].Result.TotalAmt - testCases[0].Case.GetExpectedReturn(calculator)) <= 0.01m);
            Assert.IsTrue(Math.Abs(testCases[3].Result.TotalAmt - testCases[3].Case.GetExpectedReturn(calculator)) <= 0.01m);

            //var offers = new ILenderPoolMockGenerator().MockOffers;
            //var offer1 = offers[0];
            //var offer2 = offers[3];

            //var mockCalculator = new Mock<IPaymentCalculator>();

            //mockCalculator.Setup(c => c.GetPaymentGivenRate(offer1.AvailabeAmt, offer1.RateContract, 2))
            //    .Returns(new PaymentByMonth
            //    {
            //        Instalments = offer1.RateContract.TermsInMonth,
            //        TotalAmt = 716.68727m
            //    });
            //mockCalculator.Setup(c => c.GetPaymentGivenRate(offer2.AvailabeAmt, offer2.RateContract, 2))
            //    .Returns(new PaymentByMonth
            //    {
            //        Instalments = offer2.RateContract.TermsInMonth,
            //        TotalAmt = 198.6277m
            //    });
            //Assert.AreEqual(76.69m, Math.Round(offer1.GetExpectedReturn(mockCalculator.Object), 2));
            //Assert.AreEqual(28.63m, Math.Round(offer2.GetExpectedReturn(mockCalculator.Object), 2));
        }
    }
}

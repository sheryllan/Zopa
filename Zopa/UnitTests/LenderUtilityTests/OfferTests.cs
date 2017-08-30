using System;
using CalculatorUtility.PaymentUtility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using UnitTests.MockGenerators;
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
            var mockCalculator = gen.MockObject.Object;
            
            Assert.IsTrue(Math.Abs(testCases[0].Result.TotalAmt - testCases[0].Case.GetExpectedReturn(mockCalculator)) <= 0.01m);
            Assert.IsTrue(Math.Abs(testCases[4].Result.TotalAmt - testCases[4].Case.GetExpectedReturn(mockCalculator)) <= 0.01m);
          
        }
    }
}

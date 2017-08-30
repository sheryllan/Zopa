using CalculatorUtility.RateUtility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTests.Comparers;
using UnitTests.TestData;

namespace UnitTests.CalculatorUtilityTests
{
    [TestClass]
    public class RateCalculatorByMonthTests
    {
        private RateCalculatorByMonth _calculator = new RateCalculatorByMonth();

        [TestMethod]
        public void TestGetRateGivenPayment()
        {
            var testCases = GetRateGivenPayment.Cases;
            var rateContract0 = _calculator.GetRateGivenPayment(testCases[0].Payment, testCases[0].Capital);
            var rateContract0Expected = testCases[0].Rate;
            var rateContract2 = _calculator.GetRateGivenPayment(testCases[2].Payment, testCases[2].Capital);
            var rateContract2Expected = testCases[2].Rate;
            var comparer = Semantic.RateComparer;
            Assert.IsTrue(comparer.Equals(rateContract0Expected, rateContract0));
            Assert.IsTrue(comparer.Equals(rateContract2Expected, rateContract2));            
        }

    }
}

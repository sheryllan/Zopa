using BorrowerUtility;
using CalculatorUtility;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.CalculatorUtilityTests
{
    [TestClass]
    public class RateCalculatorByMonthTests
    {
        private RateCalculatorByMonth _calculator = new RateCalculatorByMonth();

        [TestMethod]
        public void TestGetRateGivenPayment()
        {
            var payment = new PaymentByMonth()
            {
                Instalments = 36,
                TotalAmt = 1108.10m,
            };
            var rateContract = _calculator.GetRateByPayment(payment);
            IRateContract rateContractExpected = new RateContract()
            {
                AnnualRate = 0.07m,
                ContractDuration = 36
            };
            Assert.AreEqual(rateContractExpected, rateContract);
            //Assert.AreEqual(0.07, rateContract.AnnualRate);
            //Assert.AreEqual(36, rateContract.ContractDuration);
        }

    }
}

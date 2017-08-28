using System.Linq;
using BorrowerUtility;
using CalculatorUtility;
using CalculatorUtility.PaymentUtility;
using CalculatorUtility.RateUtility;
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
                TotalAmt = 1111.57m,
            };
            var rateContract1000Loan = _calculator.GetRateByPayment(payment, 1000, 3);
            IRateContract rateContract1000LoanExpected = new RateContract()
            {
                AnnualRate = 0.07m,
                DurationInMonth = 36
            };
            Assert.AreEqual(rateContract1000LoanExpected, rateContract1000Loan);
            //Assert.AreEqual(0.07, rateContract.AnnualRate);
            //Assert.AreEqual(36, rateContract.ContractDuration);
        }

        [TestMethod]
        public void TestBuilPolynomial()
        {
            var coefficients = Enumerable.Range(1, 37).Select(x => -30.78m).ToArray();
            coefficients[0] = 1000;
            var func = _calculator.BuildPolynomial(coefficients);
            Assert.AreEqual(-108.08m, func(1));
        }

    }
}

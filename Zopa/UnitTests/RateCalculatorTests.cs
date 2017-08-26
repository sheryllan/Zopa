using System;
using BorrowerUtility;
using CalculatorUtility;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class RateCalculatorTests
    {
        private MpRateCalculator _calculator = new MpRateCalculator();

        [TestMethod]
        public void TestGetRateByPayment()
        {
            var payment = new PaymentByMonth()
            {
                Instalments = 36,
                TotalAmt = 1108.10m,
                MonthlyAmt = 30.78m
            };
            Assert.AreEqual(0.07, _calculator.GetRateByPayment(payment));
        }
    }
}

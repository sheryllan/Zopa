using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BorrowerUtility;
using CalculatorUtility;
using LenderUtility;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.CalculatorUtilityTests
{
    [TestClass]
    public class PaymentCalculatorByMonthTests
    {
        private PaymentCalculatorByMonth _calculator = new PaymentCalculatorByMonth();

        [TestMethod]
        public void TestGetPaymentGivenRate()
        {
            var rateContract = new RateContract()
            {
                AnnualRate = 0.07m,
                ContractDuration = 36
            };
            var payment = _calculator.GetPaymentGivenRate(1000, rateContract);
            IPayment paymentExpected = new Payment()
            {
                Instalments = 36,
                TotalAmt = 1108.10m
            };
            Assert.AreEqual(paymentExpected, payment);
            //Assert.AreEqual(36, payment.Instalments);
            //Assert.AreEqual(1108.10m, payment.TotalAmt);
        }

        [TestMethod]
        public void TestGetPaymentByMonthGivenRate()
        {
            var rateContract = new RateContract()
            {
                AnnualRate = 0.07m,
                ContractDuration = 36
            };
            var payment = _calculator.GetPaymentByMonthGivenRate(1000, rateContract);
            var paymentExpected = new PaymentByMonth()
            {
                Instalments = 36,
                TotalAmt = 1108.10m
            };
            Assert.AreEqual(paymentExpected, payment);
            Assert.AreEqual(30.78m, payment.MonthlyAmt);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BorrowerUtility;
using CalculatorUtility;
using CalculatorUtility.PaymentUtility;
using CalculatorUtility.RateUtility;
using LenderUtility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.SemanticComparison;

namespace UnitTests.CalculatorUtilityTests
{
    [TestClass]
    public class PaymentCalculatorByMonthTests
    {
        private PaymentCalculatorByMonth _calculator = new PaymentCalculatorByMonth();


        [TestMethod]
        public void TestGetPaymentGivenRate()
        {
            var rateContract1 = new RateContract()
            {
                AnnualRate = 0.07m,
                TermsInMonth = 36
            };
            var payment1With1000Loan = _calculator.GetPaymentGivenRate(1000, rateContract1, 2);
            var payment1With1000LoanExpected = new Likeness<IPayment, IPayment>(new Payment()
            {
                Instalments = 36,
                TotalAmt = 1111.58m
            });
            Assert.AreEqual(payment1With1000LoanExpected, payment1With1000Loan);
        }

        [TestMethod]
        public void TestGetPaymentByMonthGivenRate()
        {
            var rateContract1 = new RateContract()
            {
                AnnualRate = 0.07m,
                TermsInMonth = 36
            };
            var payment1With1000Loan = _calculator.GetPaymentByMonthGivenRate(1000, rateContract1, 2);
            var payment1With1000LoanExpected = new Likeness<PaymentByMonth, PaymentByMonth>(new PaymentByMonth()
            {
                Instalments = 36,
                TotalAmt = 1111.58m
            });
            Assert.AreEqual(payment1With1000LoanExpected, payment1With1000Loan);
        }
    }
}

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
using UnitTests.Comparers;
using UnitTests.TestData;

namespace UnitTests.CalculatorUtilityTests
{
    [TestClass]
    public class PaymentCalculatorByMonthTests
    {
        [TestMethod]
        public void TestGetPaymentGivenRate()
        {
            var testCases = GetPaymentGivenRate.Cases;
            var calculator = new PaymentCalculatorByMonth();
            var payment0 = calculator.GetPaymentGivenRate(testCases[0].Case.AvailabeAmt, testCases[0].Case.RateContract);
            var payment1 = calculator.GetPaymentGivenRate(testCases[1].Case.AvailabeAmt, testCases[1].Case.RateContract);

            var comparer = Semantic.PaymentComparer;
            Assert.IsTrue(comparer.Equals(testCases[0].Result, payment0));
            Assert.IsTrue(comparer.Equals(testCases[1].Result, payment1));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BorrowerUtility;
using CalculatorUtility;
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

namespace UnitTests.BorrowerUtilityTests
{
    [TestClass]
    public class BorrowerByMonthRepaymentTests
    {
        private Mock<ILenderPool> _mockPool;
        private Mock<IPaymentCalculator> _pCalculator;
        private Mock<IRateCalculator> _rCalculator;
        private BorrowerByMonthRepayment _borrower;

        [TestInitialize]
        public void Initialize()
        {
            var lpMockGen = new ILenderPoolMockGenerator();
            var rcMockGen = new IRateCalculatorMockGenerator();
            var pcMockGen = new IPaymentCalculatorMockGenerator();
            lpMockGen.SetupFindBestOffersForLoan();
            pcMockGen.SetupGetPaymentGivenRate();
            rcMockGen.SetupGetRateGivenPayment();

            _mockPool = lpMockGen.MockOject;
            _rCalculator = rcMockGen.MockObject;
            _pCalculator = pcMockGen.MockObject;
            
            _borrower = new BorrowerByMonthRepayment(_mockPool.Object, _pCalculator.Object, _rCalculator.Object);
            
        }

        [TestMethod]
        public void TestGetQuoteWithLowestRateWhenOffersAvailable()
        {
            var quoteFor1000Loan = _borrower.GetQuoteWithLowestRate(1000); 
            var quoteFor1000LoanExpected = new QuoteByMonth
            {
                Loan = 1000,
                RateContract = new RateContract { AnnualRate = 0.070m, TermsInMonth = 36},
                RePayment = new Payment { Instalments = 36, TotalAmt = 1111.65m}
            };

            var quoteFor1500Loan = _borrower.GetQuoteWithLowestRate(1500);
            var quoteFor1500LoanExpected = new QuoteByMonth
            {
                Loan = 1000,
                RateContract = new RateContract { AnnualRate = 0.071m, TermsInMonth = 36 },
                RePayment = new Payment { Instalments = 36, TotalAmt = 1670.93m }
            };

            var comparer = Semantic.QuoteComparer;
            Assert.IsTrue(comparer.Equals(quoteFor1000LoanExpected, quoteFor1000Loan));
            Assert.IsTrue(comparer.Equals(quoteFor1500LoanExpected, quoteFor1500Loan));
        }

        [TestMethod]
        public void TestGetQuoteWithLowestRateWhenOffersNotAvailable()
        {
            var quoteFor10000Loan = _borrower.GetQuoteByMonthWithLowestRate(10000);
            Assert.IsNull(quoteFor10000Loan);
        }

        [TestMethod]
        public void TestGetQuoteByMonthWithLowestRate()
        {
            var pool = _mockPool.Object;
            var pc = _pCalculator.Object;
            var rc = _rCalculator.Object;
            var mockBorrower = new Mock<BorrowerByMonthRepayment>(pool, pc, rc);
            mockBorrower.Setup(b => b.GetQuoteWithLowestRate(1000)).Returns(new QuoteByMonth
            {
                Loan = 1000,
                RateContract = new RateContract {AnnualRate = 0.070m, TermsInMonth = 36},
                RePayment = new Payment {Instalments = 36, TotalAmt = 1111.65m}
            });
            var quoteFor1000Loan = mockBorrower.Object.GetQuoteByMonthWithLowestRate(1000);
            Assert.IsTrue(30.87m - quoteFor1000Loan.MonthlyPayment < 0.02m);
            Assert.IsTrue(7m - quoteFor1000Loan.AnnualPercentageRate < 0.2m);
           
        }
    }
}

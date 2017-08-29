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
using UnitTests.Mocks;

namespace UnitTests.BorrowerUtilityTests
{
    [TestClass]
    public class BorrowerByMonthRepaymentTests
    {
        private Mock<IMarketProvider> _mockProvider;
        private Mock<ILenderPool> _mockPool;

        private BorrowerByMonthRepayment _borrower;
        private Mock<IPaymentCalculator> _pCalculator;
        private Mock<IRateCalculator> _rCalculator;

        private decimal[] _loanCases;

        [TestInitialize]
        public void Initialize()
        {
            var mpMockGen = new IMarketProviderMockGenerator();
            var lpMockGen = new ILenderPoolMockGenerator();
            var rcMockGen = new IRateCalculatorMockGenerator();
            _mockProvider = mpMockGen.MockObject;
            _mockPool = lpMockGen.MockOject;
            _rCalculator = rcMockGen.MockObject;
            lpMockGen.SetupFindBestOffersForLoan();

            _borrower = new BorrowerByMonthRepayment(_mockProvider.Object);
            _pCalculator = new Mock<IPaymentCalculator>();
            _rCalculator = new Mock<IRateCalculator>();

            //_loanCases = new []{1000, 1500}
        }

        [TestMethod]
        public void TestGetQuoteWithLowestRateWhenOffersAvailable()
        {
            var offers = _mockPool.Object.FindBestOffersForLoan(x => x > 1000m);
            var mockOffers = offers.Select(o =>
            {
                var oMockGen = new OfferMockGenerator();
                oMockGen.SetupGetExpectedReturn(o);
                return oMockGen.MockObject;
            }).ToList();

           
            //_mockOffer.Setup(o => o.GetExpectedReturn(_pCalculator.Object)).Returns()

            var quote1For1000Loan = _borrower.GetQuoteWithLowestRate(1000); 
            var quote1RateFor1000Loan = quote1For1000Loan.RateContract;
            var quote1PaymentFor1000Loan = quote1For1000Loan.RePayment;

            var quote1RateFor1000LoanExpected = new Likeness<RateContract, RateContract>(new RateContract()
            {
                AnnualRate = 0.07m,
                TermsInMonth = 36
            });
            var quote1PaymentFor1000LoanExpected =new Likeness<Payment, Payment>(new Payment()
            {
                Instalments = 36,
                TotalAmt = 1000
            });

            Assert.AreEqual(1000, quote1For1000Loan.Loan);
            Assert.AreEqual(quote1RateFor1000LoanExpected, quote1RateFor1000Loan);
            Assert.AreEqual(quote1PaymentFor1000LoanExpected, quote1PaymentFor1000Loan);
        }

        [TestMethod]
        public void TestGetQuoteWithLowestRateWhenOffersNotAvailable()
        {
            
        }

        [TestMethod]
        public void TestGetQuoteByMonthWithLowestRate()
        {
            
            var quote1For1000Loan = _borrower.GetQuoteByMonthWithLowestRate(1000);


            var quote1For1000LoanExpected = new QuoteByMonth()
            {
                Loan = 1000,
                RateContract = new RateContract()
                {
                    AnnualRate = 0.07m,
                    TermsInMonth = 36
                },
                RePayment = new PaymentByMonth()
                {
                    Instalments = 36,
                    TotalAmt = 1000
                }
            }.AsSource().OfLikeness<QuoteByMonth>();

            var quote1RateFor1000Loan = quote1For1000Loan.RateContract;
            var quote1PaymentFor1000Loan = quote1For1000Loan.RePayment;

            var quote1RateFor1000LoanExpected = new Likeness<IRateContract, IRateContract>(new RateContract()
            {
                AnnualRate = 0.07m,
                TermsInMonth = 36
            });
            var quote1PaymentFor1000LoanExpected = new Likeness<IPayment, IPayment>(new PaymentByMonth()
            {
                Instalments = 36,
                TotalAmt = 1000
            });

            Assert.AreEqual(quote1For1000LoanExpected, quote1For1000Loan);
            //Assert.AreEqual(1000, quote1For1000Loan.Loan);
            //Assert.AreEqual(quote1RateFor1000LoanExpected, quote1RateFor1000Loan);
            //Assert.AreEqual(quote1PaymentFor1000LoanExpected, quote1PaymentFor1000Loan);
            //Assert.AreEqual(7m, quote1For1000Loan.AnnualPercentageRate);
            //Assert.AreEqual(30.87, quote1For1000Loan.MonthlyPayment);
        }
    }
}

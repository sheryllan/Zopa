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
using MarketDataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.SemanticComparison;
using Ploeh.SemanticComparison.Fluent;
using UnitTests.Mocks;

namespace UnitTests.BorrowerUtilityTests
{
    [TestClass]
    public class BorrowerByMonthRepaymentTests
    {
        private MockMarketData _marketData = new MockMarketData();
        private IMarket _market = new LongTermLoanMarket(MarketType.LongerTerm, 36);

        private BorrowerByMonthRepayment CreateBorrower(DataTable table, IMarket market)
        {
            var provider = new MockCsvMarketProvider(table, market);
            return new BorrowerByMonthRepayment(provider);
        }

        [TestMethod]
        public void TestGetQuoteWithLowestRate()
        {
            var borrower = CreateBorrower(_marketData.GetTableWithTotalOver1500(), _market);
            var quote1For1000Loan = borrower.GetQuoteWithLowestRate(1000); 
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
        public void TestGetQuoteByMonthWithLowestRate()
        {
            var borrower = CreateBorrower(_marketData.GetTableWithTotalOver1500(), _market);
            var quote1For1000Loan = borrower.GetQuoteByMonthWithLowestRate(1000);


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

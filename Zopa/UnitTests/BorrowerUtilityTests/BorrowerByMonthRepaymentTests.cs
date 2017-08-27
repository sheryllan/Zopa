using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BorrowerUtility;
using CalculatorUtility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTests.Mocks;

namespace UnitTests.BorrowerUtilityTests
{
    [TestClass]
    public class BorrowerByMonthRepaymentTests
    {
        private MockMarketData _market = new MockMarketData();

        private IQuote InitializeQuote(DataTable table, decimal amount)
        {
            var provider = new MockCsvMarketProvider(table);
            var borrower = new BorrowerByMonthRepayment(provider);
            return borrower.GetQuoteWithLowestRate(amount);
        }

        private QuoteByMonth InitializeQuoteByMonth(DataTable table, decimal amount)
        {
            var provider = new MockCsvMarketProvider(table);
            var borrower = new BorrowerByMonthRepayment(provider);
            return borrower.GetQuoteByMonthWithLowestRate(amount);
        }

        [TestMethod]
        public void TestGetQuoteWithLowestRate()
        {
            var quote1For1000Loan = InitializeQuote(_market.GetTableWithTotalOver1500(), 1000);
            var quote1RateFor1000Loan = quote1For1000Loan.RateContract;
            var quote1PaymentFor1000Loan = quote1For1000Loan.RePayment;

            var quote1RateFor1000LoanExpected = new RateContract()
            {
                AnnualRate = 0.07m,
                ContractDuration = 36
            };
            var quote1PaymentFor1000LoanExpected = new Payment()
            {
                Instalments = 36,
                TotalAmt = 1000
            };

            Assert.AreEqual(1000, quote1For1000Loan.Loan);
            Assert.AreEqual(quote1RateFor1000LoanExpected, quote1RateFor1000Loan);
            Assert.AreEqual(quote1PaymentFor1000LoanExpected, quote1PaymentFor1000Loan);
        }

        [TestMethod]
        public void TestGetQuoteByMonthWithLowestRate()
        {
            var quote1For1000Loan = InitializeQuoteByMonth(_market.GetTableWithTotalOver1500(), 1000);
            var quote1RateFor1000Loan = quote1For1000Loan.RateContract;
            var quote1PaymentFor1000Loan = quote1For1000Loan.RePayment;

            var quote1RateFor1000LoanExpected = new RateContract()
            {
                AnnualRate = 0.07m,
                ContractDuration = 36
            };
            var quote1PaymentFor1000LoanExpected = new PaymentByMonth()
            {
                Instalments = 36,
                TotalAmt = 1000
            };

            Assert.AreEqual(1000, quote1For1000Loan.Loan);
            Assert.AreEqual(quote1RateFor1000LoanExpected, quote1RateFor1000Loan);
            Assert.AreEqual(quote1PaymentFor1000LoanExpected, quote1PaymentFor1000Loan);
            Assert.AreEqual(7m, quote1For1000Loan.RateContractByMonth.AnnualPercentageRate);
        }
    }
}

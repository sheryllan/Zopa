using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorUtility.PaymentUtility;
using CalculatorUtility.RateUtility;
using LenderUtility;
using MarketDataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTests.Mocks;

namespace UnitTests.LenderUtilityTests
{
    [TestClass]
    public class OfferTests
    {
        private MockMarketData _mockData = new MockMarketData();

        [TestMethod]
        public void TestGetExpectedReturnUsingByMonthCalculator()
        {
            var pool1 = new MockLenderPool();
            var offersFromPool1 = pool1.GetOffersWithTotalOver1500();
            var offer1 = offersFromPool1[0];
            var offer2 = offersFromPool1[3];

            var calculator = new PaymentCalculatorByMonth();
            Assert.AreEqual(76.69m, Math.Round(offer1.GetExpectedReturn(calculator), 2));
            Assert.AreEqual(28.63m, Math.Round(offer2.GetExpectedReturn(calculator), 2));
                
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorUtility.PaymentUtility;
using LenderUtility;
using Moq;
using UnitTests.Comparers;
using UnitTests.TestData;

namespace UnitTests.Mocks
{
    public class OfferMockGenerator
    {
        public Mock<Offer> MockObject { get; set; }

        public OfferMockGenerator()
        {
            MockObject = new Mock<Offer>();
        }

        public void SetupProperties(Offer offer)
        {
            MockObject.Setup(o => o.Name).Returns(offer.Name);
            MockObject.Setup(o => o.AvailabeAmt).Returns(offer.AvailabeAmt);
            MockObject.Setup(o => o.RateContract).Returns(offer.RateContract);
        }
        public void SetupGetExpectedReturn(Offer offer, IPaymentCalculator calculator)
        {
            var t = GetExpectedReturn.Cases.FirstOrDefault(c => Semantic.OfferComparer.Equals(c.Case, offer));
            SetupProperties(offer);
            MockObject.Setup(o => o.GetExpectedReturn(calculator)).Returns(t.Result);
        }
    }
}

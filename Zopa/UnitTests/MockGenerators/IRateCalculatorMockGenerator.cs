using CalculatorUtility.PaymentUtility;
using CalculatorUtility.RateUtility;
using Moq;
using UnitTests.Comparers;
using UnitTests.TestData;

namespace UnitTests.MockGenerators
{
    public class IRateCalculatorMockGenerator
    {
        public Mock<IRateCalculator> MockObject { get; set; }

        public IRateCalculatorMockGenerator()
        {
            MockObject = new Mock<IRateCalculator>();
        }

        public void SetupGetRateGivenPayment()
        {
            foreach (var t in GetRateGivenPayment.Cases)
            {
                MockObject.Setup(c => c.GetRateGivenPayment(It.Is<Payment>(p => Semantic.PaymentComparer.Equals(p, t.Payment)), t.Capital, 3)).Returns(t.Rate);
            }

        }
    }
}

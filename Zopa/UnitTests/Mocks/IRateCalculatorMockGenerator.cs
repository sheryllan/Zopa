using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorUtility.RateUtility;
using Moq;
using UnitTests.TestData;

namespace UnitTests.Mocks
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
                MockObject.Setup(c => c.GetRateGivenPayment(t.Payment, t.Capital, 3)).Returns(t.Rate);
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorUtility.PaymentUtility;
using CalculatorUtility.RateUtility;
using Moq;
using UnitTests.Comparers;
using UnitTests.TestData;

namespace UnitTests.Mocks
{
    public class IPaymentCalculatorMockGenerator
    {
        public Mock<IPaymentCalculator> MockObject { get; set; }

        public IPaymentCalculatorMockGenerator()
        {
            MockObject = new Mock<IPaymentCalculator>();
        }

        public void SetupGetPaymentGivenRate()
        {
            foreach (var t in GetPaymentGivenRate.Cases)
            {
                MockObject.Setup(c => c.GetPaymentGivenRate(t.Case.AvailabeAmt,
                        It.Is<IRateContract>(x => Semantic.RateComparer.Equals(x, t.Case.RateContract)), 2))
                    .Returns(t.Result);
            }
        }
    }
}

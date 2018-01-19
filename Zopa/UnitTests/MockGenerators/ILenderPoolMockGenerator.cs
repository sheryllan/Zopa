using System.Collections.Generic;
using CalculatorUtility.RateUtility;
using LenderUtility;
using Moq;
using UnitTests.TestData;

namespace UnitTests.MockGenerators
{
    public class ILenderPoolMockGenerator
    {
        public Mock<ILenderPool> MockOject { get; set; }
        private List<Offer> _offers = new List<Offer>
        {
            new Offer
            {
                Name = "Bob",
                AvailabeAmt = 640m,
                RateContract = new RateByMonth()
                {
                    AnnualRate = 0.075m,
                    Months = 36
                }
            },
            new Offer
            {
                Name = "Jane",
                AvailabeAmt = 480m,
                RateContract = new RateByMonth()
                {
                    AnnualRate = 0.069m,
                    Months = 36
                }
            },

            new Offer
            {
                Name = "Fred",
                AvailabeAmt = 520m,
                RateContract = new RateByMonth()
                {
                    AnnualRate = 0.071m,
                    Months = 36
                }
            },

            new Offer
            {
                Name = "Mary",
                AvailabeAmt = 170m,
                RateContract = new RateByMonth()
                {
                    AnnualRate = 0.104m,
                    Months = 36
                }
            },

            new Offer
            {
                Name = "John",
                AvailabeAmt = 320m,
                RateContract = new RateByMonth()
                {
                    AnnualRate = 0.081m,
                    Months = 36
                }
            },

            new Offer
            {
                Name = "Dave",
                AvailabeAmt = 140m,
                RateContract = new RateByMonth()
                {
                    AnnualRate = 0.074m,
                    Months = 36
                }
            },

            new Offer
            {
                Name = "Angela",
                AvailabeAmt = 60m,
                RateContract = new RateByMonth()
                {
                    AnnualRate = 0.071m,
                    Months = 36
                }
            }
        };

        public ILenderPoolMockGenerator()
        {
            MockOject = new Mock<ILenderPool>();
        }

        public void SetupAllOffers()
        {
            MockOject.SetupGet(p => p.AllOffers).Returns(_offers);
        }

        public void SetupFindBestOffersForLoan()
        {
            foreach (var t in FindBestOffersForLoan.Cases)
            {
                MockOject.Setup(p => p.FindBestOffersForLoan(t.Case)).Returns(t.Result);
            }
                
        }
    }
}

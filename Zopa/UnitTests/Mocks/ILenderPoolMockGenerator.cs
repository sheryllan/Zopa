using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CalculatorUtility.RateUtility;
using LenderUtility;
using MarketDataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using UnitTests.TestData;

namespace UnitTests.Mocks
{
    public class ILenderPoolMockGenerator
    {
        public Mock<ILenderPool> MockOject { get; set; }
        public List<Offer> MockOffers => new List<Offer>
        {
            new Offer
            {
                Name = "Bob",
                AvailabeAmt = 640m,
                RateContract = new RateContract()
                {
                    AnnualRate = 0.075m,
                    TermsInMonth = 36
                }
            },
            new Offer
            {
                Name = "Jane",
                AvailabeAmt = 480m,
                RateContract = new RateContract()
                {
                    AnnualRate = 0.069m,
                    TermsInMonth = 36
                }
            },

            new Offer
            {
                Name = "Fred",
                AvailabeAmt = 520m,
                RateContract = new RateContract()
                {
                    AnnualRate = 0.071m,
                    TermsInMonth = 36
                }
            },

            new Offer
            {
                Name = "Mary",
                AvailabeAmt = 170m,
                RateContract = new RateContract()
                {
                    AnnualRate = 0.104m,
                    TermsInMonth = 36
                }
            },

            new Offer
            {
                Name = "John",
                AvailabeAmt = 320m,
                RateContract = new RateContract()
                {
                    AnnualRate = 0.081m,
                    TermsInMonth = 36
                }
            },

            new Offer
            {
                Name = "Dave",
                AvailabeAmt = 140m,
                RateContract = new RateContract()
                {
                    AnnualRate = 0.074m,
                    TermsInMonth = 36
                }
            },

            new Offer
            {
                Name = "Angela",
                AvailabeAmt = 60m,
                RateContract = new RateContract()
                {
                    AnnualRate = 0.071m,
                    TermsInMonth = 36
                }
            }
        };

        public ILenderPoolMockGenerator()
        {
            MockOject = new Mock<ILenderPool>();
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

using System.Collections.Generic;
using CalculatorUtility.RateUtility;
using LenderUtility;

namespace UnitTests.TestData
{
    public class FindBestOffersForLoan
    {
        public class TestCase
        {
            public decimal Case { get; set; }
            public List<Offer> Result { get; set; }

            public TestCase(decimal c, List<Offer> r)
            {
                Case = c;
                Result = r;
            }
        }

        public static TestCase[] Cases => new[]
        {
            new TestCase(1000m, new List<Offer>
            {
                new Offer
                {
                    Name = "Jane",
                    AvailabeAmt = 480m,
                    RateContract = new RateContract()
                    {
                        AnnualRate = 0.069m,
                        Months = 36
                    }
                },
                new Offer
                {
                    Name = "Fred",
                    AvailabeAmt = 520m,
                    RateContract = new RateContract()
                    {
                        AnnualRate = 0.071m,
                        Months = 36
                    }
                }
            }),
            new TestCase(1500m, new List<Offer>
            {
                new Offer
                {
                    Name = "Jane",
                    AvailabeAmt = 480m,
                    RateContract = new RateContract()
                    {
                        AnnualRate = 0.069m,
                        Months = 36
                    }
                },
                new Offer
                {
                    Name = "Fred",
                    AvailabeAmt = 520m,
                    RateContract = new RateContract()
                    {
                        AnnualRate = 0.071m,
                        Months = 36
                    }
                },
                new Offer
                {
                    Name = "Angela",
                    AvailabeAmt = 60m,
                    RateContract = new RateContract()
                    {
                        AnnualRate = 0.071m,
                        Months = 36
                    }
                },
                new Offer
                {
                    Name = "Dave",
                    AvailabeAmt = 140m,
                    RateContract = new RateContract()
                    {
                        AnnualRate = 0.074m,
                        Months = 36
                    }
                },
                new Offer
                {
                    Name = "Bob",
                    AvailabeAmt = 640m,
                    RateContract = new RateContract()
                    {
                        AnnualRate = 0.075m,
                        Months = 36
                    }
                }
            }),
            new TestCase(10000m, null)
        };
       
    }
}

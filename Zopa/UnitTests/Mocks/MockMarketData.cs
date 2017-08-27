using System.Collections.Generic;
using System.Data;
using System.Linq;
using CalculatorUtility;
using LenderUtility;

namespace UnitTests.Mocks
{
    public class MockMarketData
    {
        private string[] _header = new[]
        {
            "Lender",
            "Rate",
            "Available",
        };

        private DataColumn[] NewTableHeader()
        {
            return _header.Select(h => new DataColumn(h)).ToArray();
        }

        public DataTable GetTableWithTotalUnder1500()
        {
            var dt = new DataTable();
            dt.Columns.AddRange(NewTableHeader());
            dt.Rows.Add("Samuel", 0.071m, 188.9m);
            dt.Rows.Add("Emma", 0.084m, 500m);
            dt.Rows.Add("Alice", 0.081m, 250.5m);
            dt.Rows.Add("Mark", 0.077m, 100m);

            return dt;
        }

        public DataTable GetTableWithTotalUnder1000()
        {
            var dt = new DataTable();
            dt.Columns.AddRange(NewTableHeader());
            dt.Rows.Add("Samuel", 0.069m, 199m);
            dt.Rows.Add("Emma", 0.073m, 200m);
            dt.Rows.Add("Alice", 0.102m, 406.6m);
            dt.Rows.Add("Mark", 0.077m, 100m);

            return dt;
        }

        public DataTable GetTableWithTotalOver1500()
        {
            var dt = new DataTable();
            dt.Columns.AddRange(NewTableHeader());
            dt.Rows.Add("Bob", 0.075m, 640m);
            dt.Rows.Add("Jane", 0.069m, 480m);
            dt.Rows.Add("Fred", 0.071m, 520m);
            dt.Rows.Add("Mary", 0.104m, 170m);
            dt.Rows.Add("John", 0.081m, 320m);
            dt.Rows.Add("Dave", 0.074m, 140m);
            dt.Rows.Add("Angela", 0.071m, 60m);

            return dt;
        }

        public List<Offer> GetOffersWithTotalUnder1000()
        {
            var offers = new List<Offer>
            {
                new Offer()
                {
                    Name = "Samuel",
                    AvailabeAmt = 199m,
                    RateContract = new RateContract()
                    {
                        AnnualRate = 0.069m,
                        ContractDuration = 36
                    }
                },

                new Offer()
                {
                    Name = "Emma",
                    AvailabeAmt = 200m,
                    RateContract = new RateContract()
                    {
                        AnnualRate = 0.073m,
                        ContractDuration = 36
                    }
                },

                new Offer()
                {
                    Name = "Alice",
                    AvailabeAmt = 406.6m,
                    RateContract = new RateContract()
                    {
                        AnnualRate = 0.102m,
                        ContractDuration = 36
                    }
                },

                new Offer()
                {
                    Name = "Mark",
                    AvailabeAmt = 100m,
                    RateContract = new RateContract()
                    {
                        AnnualRate = 0.077m,
                        ContractDuration = 36
                    }
                }
            };

            return offers;
        }

        public List<Offer> GetOffersWithTotalUnder1500()
        {
            var offers = new List<Offer>
            {
                new Offer()
                {
                    Name = "Samuel",
                    AvailabeAmt = 188.9m,
                    RateContract = new RateContract()
                    {
                        AnnualRate = 0.071m,
                        ContractDuration = 36
                    }
                },

                new Offer()
                {
                    Name = "Emma",
                    AvailabeAmt = 500m,
                    RateContract = new RateContract()
                    {
                        AnnualRate = 0.084m,
                        ContractDuration = 36
                    }
                },

                new Offer()
                {
                    Name = "Alice",
                    AvailabeAmt = 250.5m,
                    RateContract = new RateContract()
                    {
                        AnnualRate = 0.081m,
                        ContractDuration = 36
                    }
                },

                new Offer()
                {
                    Name = "Mark",
                    AvailabeAmt = 100m,
                    RateContract = new RateContract()
                    {
                        AnnualRate = 0.077m,
                        ContractDuration = 36
                    }
                }
            };

            return offers;
        }

        public List<Offer> GetOffersWithTotalOver1500()
        {
            var offers = new List<Offer>
            {
                new Offer()
                {
                    Name = "Bob",
                    AvailabeAmt = 640m,
                    RateContract = new RateContract()
                    {
                        AnnualRate = 0.075m,
                        ContractDuration = 36
                    }
                },
                new Offer()
                {
                    Name = "Jane",
                    AvailabeAmt = 480m,
                    RateContract = new RateContract()
                    {
                        AnnualRate = 0.069m,
                        ContractDuration = 36
                    }
                },
               
                new Offer()
                {
                    Name = "Fred",
                    AvailabeAmt = 520m,
                    RateContract = new RateContract()
                    {
                        AnnualRate = 0.071m,
                        ContractDuration = 36
                    }
                },

                new Offer()
                {
                    Name = "Mary",
                    AvailabeAmt = 170m,
                    RateContract = new RateContract()
                    {
                        AnnualRate = 0.104m,
                        ContractDuration = 36
                    }
                },

                new Offer()
                {
                    Name = "John",
                    AvailabeAmt = 320m,
                    RateContract = new RateContract()
                    {
                        AnnualRate = 0.081m,
                        ContractDuration = 36
                    }
                },

                new Offer()
                {
                    Name = "Dave",
                    AvailabeAmt = 140m,
                    RateContract = new RateContract()
                    {
                        AnnualRate = 0.074m,
                        ContractDuration = 36
                    }
                },

                new Offer()
                {
                    Name = "Angela",
                    AvailabeAmt = 60m,
                    RateContract = new RateContract()
                    {
                        AnnualRate = 0.071m,
                        ContractDuration = 36
                    }
                }
            };

            return offers;
        }
    }
}
      


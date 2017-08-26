using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LenderUtility;


namespace UnitTests
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
                new Offer("Samuel", 0.069m, 199m, 36),
                new Offer("Emma", 0.073m, 200m, 36),
                new Offer("Alice", 0.102m, 406.6m, 36),
                new Offer("Mark", 0.077m, 100m, 36)
            };

            return offers;
        }

        public List<Offer> GetOffersWithTotalUnder1500()
        {
            var offers = new List<Offer>
            {
                new Offer("Samuel", 0.071m, 188.9m, 36),
                new Offer("Emma", 0.084m, 500m, 36),
                new Offer("Alice", 0.081m, 250.5m, 36),
                new Offer("Mark", 0.077m, 100m, 36)
            };

            return offers;
        }

        public List<Offer> GetOffersWithTotalOver1500()
        {
            var offers = new List<Offer>
            {
                new Offer("Bob", 0.075m, 640m, 36),
                new Offer("Jane", 0.069m, 480m, 36),
                new Offer("Fred", 0.071m, 520m, 36),
                new Offer("Mary", 0.104m, 170m, 36),
                new Offer("John", 0.081m, 320m, 36),
                new Offer("Dave", 0.074m, 140m, 36),
                new Offer("Angela", 0.071m, 60m, 36)
            };

            return offers;
        }
    }
}
      


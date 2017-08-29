using System.Data;
using System.Linq;
using MarketDataAccess;
using Moq;

namespace UnitTests.Mocks
{
    public class IMarketProviderMockGenerator
    {
        public DataTable MockDataTable { get; }
        public Mock<IMarketProvider> MockObject { get; set; }

        public IMarketProviderMockGenerator()
        {
            var columns = new[]
            {
                new DataColumn("Lender", typeof(string)), 
                new DataColumn("Rate", typeof(decimal)),
                new DataColumn("Available", typeof(decimal)), 
                new DataColumn("TermsInMonth", typeof(int))
            };
            var dt = new DataTable();
            dt.Columns.AddRange(columns);

            dt.Rows.Add("Bob", 0.075m, 640m, 36);
            dt.Rows.Add("Jane", 0.069m, 480m, 36);
            dt.Rows.Add("Fred", 0.071m, 520m, 36);
            dt.Rows.Add("Mary", 0.104m, 170m, 36);
            dt.Rows.Add("John", 0.081m, 320m, 36);
            dt.Rows.Add("Dave", 0.074m, 140m, 36);
            dt.Rows.Add("Angela", 0.071m, 60m, 36);

            MockDataTable = dt;
            MockObject = new Mock<IMarketProvider>();
            MockObject.Setup(p => p.ReadMarket()).Returns(MockDataTable);
        }
    }
}

using System.Data;
using MarketDataAccess;
using Moq;

namespace UnitTests.MockGenerators
{
    public class IMarketProviderMockGenerator
    {
        private DataTable _table;
        public Mock<IMarketProvider> MockObject { get; set; }

        public IMarketProviderMockGenerator()
        {
            MockObject = new Mock<IMarketProvider>();
            MockObject.Setup(m => m.Market).Returns(new LongTermLoanMarket(MarketType.LongerTerm, 36));
        }

        public void SetupReadMarket()
        {
            var columns = new[]
            {
                new DataColumn("Lender", typeof(string)),
                new DataColumn("Rate", typeof(decimal)),
                new DataColumn("Available", typeof(decimal)),
                new DataColumn("TermsInMonth", typeof(int))
            };
            _table = new DataTable();
            _table.Columns.AddRange(columns);

            _table.Rows.Add("Bob", 0.075m, 640m, 36);
            _table.Rows.Add("Jane", 0.069m, 480m, 36);
            _table.Rows.Add("Fred", 0.071m, 520m, 36);
            _table.Rows.Add("Mary", 0.104m, 170m, 36);
            _table.Rows.Add("John", 0.081m, 320m, 36);
            _table.Rows.Add("Dave", 0.074m, 140m, 36);
            _table.Rows.Add("Angela", 0.071m, 60m, 36);

            MockObject.Setup(p => p.ReadMarket()).Returns(_table);
        }
    }
}

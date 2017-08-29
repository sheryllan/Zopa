using System.Data;
using System.Linq;
using MarketDataAccess;

namespace UnitTests.Mocks
{
    public class MockCsvMarketProvider : IMarketProvider
    {
        private readonly DataTable _marketData;
        public IMarket Market { get; set; }

        public MockCsvMarketProvider(DataTable mockData, IMarket market)
        {
            mockData.Columns.Add("TermInMonth", typeof(int));
            mockData.Select("TermInMonth = 0").ToList().ForEach(r => r["TermInMonth"] = market.TermInMonth); 
            _marketData = mockData;
            Market = market;
        }

        public DataTable ReadLenderPool()
        {
            return _marketData;
        }
    }
}

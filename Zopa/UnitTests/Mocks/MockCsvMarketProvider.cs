using System.Data;
using MarketDataAccess;

namespace UnitTests.Mocks
{
    public class MockCsvMarketProvider : IMarketProvider
    {
        private readonly DataTable _market;

        public MockCsvMarketProvider(DataTable mockMarket)
        {
            _market = mockMarket;
        }
        public DataTable ReadLenderPool()
        {
            return _market;
        }
    }
}

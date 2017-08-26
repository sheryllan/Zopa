using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketDataAccess;

namespace UnitTests
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

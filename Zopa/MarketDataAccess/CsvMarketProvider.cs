using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketDataAccess
{
    public class CsvMarketProvider : IMarketProvider
    {
        private readonly string _filePath;

        public IMarket Market { get; set; }
        public CsvMarketProvider(string path, IMarket market)
        {
            _filePath = path;
            Market = market;
        }

        public DataTable ReadMarket()
        {
            throw new NotImplementedException();
        }
    }
}

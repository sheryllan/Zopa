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
        public CsvMarketProvider(string path)
        {
            _filePath = path;
        }
        public DataTable ReadLenderPool()
        {
            throw new NotImplementedException();
        }
    }
}

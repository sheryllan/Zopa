using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketDataAccess
{
    public interface IMarketProvider
    {
        IMarket Market { get; set; }
        DataTable ReadMarket();
    }
}

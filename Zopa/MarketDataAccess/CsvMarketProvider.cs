using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
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
            var connStr = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={_filePath};Extended Properties='Excel 12.0;HDR=YES'";
            var dt = new DataTable();
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                conn.Open();
                var schema = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                var table = schema?.Rows[0]["TABLE_NAME"];
                var sql = $@"SELECT * FROM [{table}]";
                var comm = new OleDbCommand(sql, conn);
                var adapter = new OleDbDataAdapter(comm);

                adapter.Fill(dt);
            }
            return dt;
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BorrowerUtility;
using MarketDataAccess;

namespace Zopa
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
                return;

            var mktFile = args[0];
            var loanAmt = args[1];

            mktFile = string.IsNullOrEmpty(Path.GetDirectoryName(mktFile)) ? 
                $@"{Directory.GetCurrentDirectory()}\{mktFile}" 
                : mktFile;

            while (!File.Exists(mktFile))
            {
                Console.Write("File does not exist. Please enter the full path of the file: ");
                mktFile = Console.ReadLine();
                //Console.WriteLine(mktFile);
            }

            var borrower = new BorrowerByMonthRepayment(new CsvMarketProvider(mktFile, new LongTermLoanMarket(MarketType.LongerTerm, 36)));

            var rate = 0.1; // 1 decimal
            var mthRepayment = 10.11; // 2 decimal
            var totRepayment = 1924.32; // 2 decimal

            Console.WriteLine(@"Requested amount: £{0}", loanAmt);
            Console.WriteLine(@"Rate: {0}%", rate);
            Console.WriteLine("Monthly repayment: £{0}", mthRepayment);
            Console.WriteLine("Total repayment: £{0}", totRepayment);


            //Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}

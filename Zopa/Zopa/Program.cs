using System;
using System.IO;
using BorrowerUtility;
using LenderUtility;
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
            

            mktFile = string.IsNullOrEmpty(Path.GetDirectoryName(mktFile)) ? 
                $@"{Directory.GetCurrentDirectory()}\{mktFile}" 
                : mktFile;

            while (!File.Exists(mktFile) )
            {
                Console.Write("File does not exist. Please enter the full path of the file: ");
                mktFile = Console.ReadLine();
            }

            var csv = new CsvMarketProvider(mktFile, new LongTermLoanMarket(MarketType.LongerTerm, 36));
            var borrower = new Borrower(new LenderPool(csv));
            try
            {
                var loanAmt = decimal.Parse(args[1]);
                var quote = borrower.GetQuoteWithLowestRate(loanAmt);
                if(quote == null)
                    throw new NullReferenceException("No available quote at the moment.");
                Console.WriteLine(@"Requested amount: £{0}", loanAmt);
                Console.WriteLine(@"Rate: {0}%", Math.Round(quote.RateContract.AnnualRate * 100, 1));
                Console.WriteLine("Monthly repayment: £{0}", quote.Repayment.MonthlyAmt);
                Console.WriteLine("Total repayment: £{0}", quote.Repayment.TotalAmt);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}

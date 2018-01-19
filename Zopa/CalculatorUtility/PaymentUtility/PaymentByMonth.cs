using System;

namespace CalculatorUtility.PaymentUtility
{
    public class PaymentByMonth : Payment
    {
        protected int Decimals;

        public void SetDecimals(int decimals)
        {
            Decimals = decimals;
        }

        public decimal MonthlyAmt => Math.Round(TotalAmt / Instalments, 2);
        
    }
}
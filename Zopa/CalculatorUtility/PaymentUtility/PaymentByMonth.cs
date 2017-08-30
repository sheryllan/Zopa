﻿using System;

namespace CalculatorUtility.PaymentUtility
{
    public class PaymentByMonth : IPayment
    {
        public int Instalments { get; set; }
        public decimal TotalAmt { get; set; }
        public decimal MonthlyAmt => Math.Round(TotalAmt / Instalments, 2);

        public PaymentByMonth() { }

        public PaymentByMonth(IPayment p)
        {
            Instalments = p.Instalments;
            TotalAmt = p.TotalAmt;
        }
        
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorUtility
{
    public interface IPayment
    {
        int Instalments { get; set; }
        decimal TotalAmt { get; set; }
    }
}

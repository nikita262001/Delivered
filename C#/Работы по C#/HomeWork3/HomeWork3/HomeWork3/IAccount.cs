﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3
{
    interface IAccount
    {
        // Положить деньги на счет
        void Put(decimal sum);
        // Взять со счета
        decimal Withdraw(decimal sum);
    }
}

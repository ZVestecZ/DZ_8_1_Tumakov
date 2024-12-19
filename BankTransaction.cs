using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_8_Tumakov
{
    internal class BankTransaction
    {
        public DateTime TransactionTime { get; }
        public decimal Amount { get; }

        public BankTransaction(decimal amount)
        {
            TransactionTime = DateTime.Now;
            Amount = amount;
        }
    }
}

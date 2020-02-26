using System;
using System.Collections.Generic;
using System.Text;

namespace NpvCalculator.DataAccess.Entities
{
    public class CashFlow
    {
        public int Id { get; set; }
        public int TransactionId { get; set; }
        public decimal Amount { get; set; }
    }
}

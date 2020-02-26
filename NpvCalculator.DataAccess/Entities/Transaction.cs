using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace NpvCalculator.DataAccess.Entities
{
    [Table("Transaction")]
    public class Transaction
    {
        [PrimaryKey]
        public int TransactionId { get; set; }
        public decimal InitialInvestment { get; set; }
        public decimal DiscountRate { get; set; }
        public decimal UpperBound { get; set; }
        public decimal LowerBound { get; set; }
        public decimal IncrementalRateType { get; set; }
        public string DiscountRateType { get; set; }
    }
}

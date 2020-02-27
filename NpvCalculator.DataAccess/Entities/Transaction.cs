using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace NpvCalculator.DataAccess.Entities
{
    [Table("Transaction")]
    public class Transaction
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public decimal InitialInvestment { get; set; }
        public decimal DiscountRate { get; set; }
        public decimal UpperBound { get; set; }
        public decimal LowerBound { get; set; }
        public decimal IncrementalRate { get; set; }
        public string DiscountRateType { get; set; }
    }
}

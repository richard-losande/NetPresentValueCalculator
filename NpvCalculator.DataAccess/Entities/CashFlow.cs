using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace NpvCalculator.DataAccess.Entities
{
    [Table("CashFlow")]
    public class CashFlow
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int TransactionId { get; set; }
        public decimal CashFlowAmount { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace NpvCalculator.DataAccess.Entities
{
    [Table("NetPresentValue")]
    public class NetPresentValue
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int TransactionId { get; set; }
        public decimal Amount { get; set; }
    }
}

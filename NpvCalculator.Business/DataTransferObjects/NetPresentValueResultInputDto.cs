using System;
using System.Collections.Generic;
using System.Text;

namespace NpvCalculator.Business.DataTransferObjects
{
    public class NetPresentValueResultInputDto
    {
        public int Id { get; set; }
        public int TransactionId { get; set; }
        public decimal Amount { get; set; }
    }
}

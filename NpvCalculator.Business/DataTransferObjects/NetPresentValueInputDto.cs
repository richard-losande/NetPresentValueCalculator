using NpvCalculator.Business.Enumerations;
using System.Collections.Generic;

namespace NpvCalculator.Business.DataTransferObjects
{
    public class NetPresentValueInputDto
    {
        public int TransactionId { get; set; }
        public double InitialInvestment { get; set; }
        public double DiscountRate { get; set; }
        public double UpperBound { get; set; }
        public double LowerBound { get; set; }
        public double IncrementalRate { get; set; }
        public List<CashFlowInputDto> CashFlows { get; set; }
        public DiscountRateType DiscountRateType { get; set; }
        public List<NetPresentValueResultInputDto> NetPresentValueResults { get; set; }
    }
}

using NpvCalculator.Business.Enumerations;
using System.Collections.Generic;

namespace NpvCalculator.Business.DataTransferObjects
{
    public class NetPresentValueInputDto
    {
        public double InitialInvestment { get; set; }
        public double DiscountRate { get; set; }
        public double UpperBound { get; set; }
        public double LowerBound { get; set; }
        public double IncrementalRate { get; set; }
        public List<CashFlow> CashFlows { get; set; }
        public DiscountRateType DiscountRateType { get; set; }
    }

    public class CashFlow
    {
        public int Id { get; set; }
        public double CashFlowAmount { get; set; }
    }
}

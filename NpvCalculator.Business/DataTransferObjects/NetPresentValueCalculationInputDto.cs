using System;
using System.Collections.Generic;
using System.Text;

namespace NpvCalculator.Business.DataTransferObjects
{
    public class NetPresentValueCalculationInputDto
    {
        public double InitialInvestment { get; set; }
        public double DiscountRate { get; set; }
        public double UpperBound { get; set; }
        public double LowerBound { get; set; }
        public double IncrementalRate { get; set; }
        public List<CashFlow> CashFlows { get; set; }
    }
}

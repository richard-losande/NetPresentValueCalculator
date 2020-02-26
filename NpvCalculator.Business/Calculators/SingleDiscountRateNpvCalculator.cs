using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NpvCalculator.Business.DataTransferObjects;

namespace NpvCalculator.Business.Calculators
{
    public class SingleDiscountRateNpvCalculator : INetPresentValueCalculator
    {
        public IEnumerable<double> Compute(NetPresentValueCalculationInputDto input)
        {
            var result = new List<double>();
            var netPresentValueAmount = input.CashFlows
                .Sum(cashFlow => cashFlow.CashFlowAmount / Math.Pow((input.DiscountRate / 100) + 1, cashFlow.Id));
            result.Add(netPresentValueAmount - input.InitialInvestment);
            return result;
        }
    }
}

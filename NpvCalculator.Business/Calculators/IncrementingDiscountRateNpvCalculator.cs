using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NpvCalculator.Business.DataTransferObjects;

namespace NpvCalculator.Business.Calculators
{
    public class IncrementingDiscountRateNpvCalculator : IIncrementingDiscountRateNpvCalculator
    {
        public double Compute(NetPresentValueCalculationInputDto input)
        {
            // to do add lower bound , upper bound logic
            var result = input.CashFlows
                .Sum(cashFlow => cashFlow.CashFlowAmount / Math.Pow((input.DiscountRate / 100) + 1, cashFlow.Id));
            return result - input.InitialInvestment;
        }
    }
}

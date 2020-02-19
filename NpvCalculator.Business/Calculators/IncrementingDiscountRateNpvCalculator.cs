using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NpvCalculator.Business.DataTransferObjects;

namespace NpvCalculator.Business.Calculators
{
    public class IncrementingDiscountRateNpvCalculator : IIncrementingDiscountRateNpvCalculator
    {
        public IEnumerable<double> Compute(NetPresentValueCalculationInputDto input)
        {
            var result = new List<double>();
            double netPresentValueAmount = 0;
            double differenceBetweenIncrementalRateAndUpperBound = 0;
            for (double discountRate = input.LowerBound; discountRate <= input.UpperBound;)
            {
                netPresentValueAmount = input.CashFlows
                    .Sum(cashFlow => cashFlow.CashFlowAmount / Math.Pow((discountRate / 100) + 1, cashFlow.Id));
                result.Add(netPresentValueAmount - input.InitialInvestment);
                differenceBetweenIncrementalRateAndUpperBound = input.UpperBound - discountRate;
                discountRate += Math.Min(differenceBetweenIncrementalRateAndUpperBound, input.IncrementalRate);
            }
            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NpvCalculator.Business.DataTransferObjects;

namespace NpvCalculator.Business.Calculators
{
    public class IncrementingDiscountRateNpvCalculator : INetPresentValueCalculator
    {
        public IEnumerable<double> Compute(NetPresentValueCalculationInputDto input)
        {
            var result = new List<double>();
            double differenceBetweenIncrementalRateAndUpperBound = 0;
            for (double discountRate = input.LowerBound; discountRate <= input.UpperBound;)
            {
                double netPresentValueAmount = input.CashFlows
                    .Sum(cashFlow => cashFlow.CashFlowAmount / Math.Pow((discountRate / 100) + 1, cashFlow.Id));
                result.Add(netPresentValueAmount - input.InitialInvestment);
                differenceBetweenIncrementalRateAndUpperBound = input.UpperBound - discountRate;
                if (differenceBetweenIncrementalRateAndUpperBound != 0)
                    discountRate += Math.Min(differenceBetweenIncrementalRateAndUpperBound, input.IncrementalRate);
                else
                    discountRate += 1;
            }
            return result;
        }
    }
}

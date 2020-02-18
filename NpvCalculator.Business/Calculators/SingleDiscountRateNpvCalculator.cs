using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NpvCalculator.Business.DataTransferObjects;

namespace NpvCalculator.Business.Calculators
{
    public class SingleDiscountRateNpvCalculator : ISingleDiscountRateNpvCalculator
    {
        public double Compute(NetPresentValueCalculationInputDto input)
        {
            var result = input.CashFlows
                .Sum(cashFlow => cashFlow.CashFlowAmount / Math.Pow((input.DiscountRate / 100) + 1, cashFlow.Id));
            return result - input.InitialInvestment;
        }
    }
}

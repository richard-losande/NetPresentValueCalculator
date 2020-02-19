using System;
using System.Collections.Generic;
using System.Text;
using NpvCalculator.Business.Calculators;
using NpvCalculator.Business.Enumerations;

namespace NpvCalculator.Business.Factories
{
    public class NpvCalculatorFactory : INpvCalculatorFactory
    {
        public Dictionary<DiscountRateType, INetPresentValueCalculator> discountRateLookup { get; } =
           new Dictionary<DiscountRateType, INetPresentValueCalculator>()
           {
                { DiscountRateType.Fixed, new SingleDiscountRateNpvCalculator() },
                { DiscountRateType.Incremental, new  IncrementingDiscountRateNpvCalculator() }
           };

        public INetPresentValueCalculator Build(DiscountRateType discountRateType)
        {
            return discountRateLookup[discountRateType];
        }
    }

}

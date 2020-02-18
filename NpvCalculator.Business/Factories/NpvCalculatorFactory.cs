using System;
using System.Collections.Generic;
using System.Text;
using NpvCalculator.Business.Calculators;

namespace NpvCalculator.Business.Factories
{
    public class NpvCalculatorFactory : INpvCalculatorFactory
    {
        private readonly ISingleDiscountRateNpvCalculator _singleDiscountRateNpvCalculator;
        private readonly IIncrementingDiscountRateNpvCalculator _incrementingDiscountRateNpvCalculator;
        private readonly  Dictionary<int,INetPresentValueCalculator> dictionary = new Dictionary<int, INetPresentValueCalculator>()
        {
            { 1,  new IncrementingDiscountRateNpvCalculator()},
            { 2, new SingleDiscountRateNpvCalculator()}
        };
        public NpvCalculatorFactory(IIncrementingDiscountRateNpvCalculator incrementingDiscountRateNpvCalculator, ISingleDiscountRateNpvCalculator singleDiscountRateNpvCalculator)
        {
            _incrementingDiscountRateNpvCalculator = incrementingDiscountRateNpvCalculator ?? 
                                                     throw new ArgumentException(nameof(incrementingDiscountRateNpvCalculator));
            _singleDiscountRateNpvCalculator = singleDiscountRateNpvCalculator ?? 
                                               throw  new ArgumentException(nameof(singleDiscountRateNpvCalculator));
        }
        public INetPresentValueCalculator Build(bool isWithIncrementalDiscountRate)
        {
            //todo make enum the discount type
            var discountRateType = isWithIncrementalDiscountRate ? 1 : 2;

            switch (discountRateType)
            {
                case 1: return _incrementingDiscountRateNpvCalculator;
                case 2: return _singleDiscountRateNpvCalculator;
                default:
                    throw new NotSupportedException($"{nameof(discountRateType)} is not supported.");
            }
        }
    }
}

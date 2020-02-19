using System;
using System.Collections.Generic;
using System.Text;
using NpvCalculator.Business.Calculators;
using NpvCalculator.Business.Enumerations;

namespace NpvCalculator.Business.Factories
{
    public interface INpvCalculatorFactory
    {
        INetPresentValueCalculator Build(DiscountRateType discountRateType);

    }
}

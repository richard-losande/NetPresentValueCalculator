using System;
using System.Collections.Generic;
using System.Text;
using NpvCalculator.Business.Calculators;

namespace NpvCalculator.Business.Factories
{
    public interface INpvCalculatorFactory
    {
        INetPresentValueCalculator Build(bool isWithIncrementalDiscountRate);

    }
}

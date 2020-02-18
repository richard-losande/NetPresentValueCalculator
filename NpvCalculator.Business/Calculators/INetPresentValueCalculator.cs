using System.Collections.Generic;
using NpvCalculator.Business.DataTransferObjects;

namespace NpvCalculator.Business.Calculators
{
    public interface INetPresentValueCalculator
    {
        IEnumerable<double> Compute(NetPresentValueCalculationInputDto input);
    }
}

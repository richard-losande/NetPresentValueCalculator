using NpvCalculator.Business.DataTransferObjects;

namespace NpvCalculator.Business.Calculators
{
    public interface INetPresentValueCalculator
    {
        double Compute(NetPresentValueCalculationInputDto input);
    }
}

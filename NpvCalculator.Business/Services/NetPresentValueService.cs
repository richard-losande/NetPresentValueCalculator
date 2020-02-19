using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NpvCalculator.Business.DataTransferObjects;
using NpvCalculator.Business.Factories;

namespace NpvCalculator.Business.Services
{
    public class NetPresentValueService : INetPresentValueService
    {
        private readonly INpvCalculatorFactory _npvCalculatorFactory;
        public NetPresentValueService(INpvCalculatorFactory npvCalculatorFactory)
        {
            _npvCalculatorFactory = npvCalculatorFactory;
        }

        public IEnumerable<double> GetNetPresentValue(NetPresentValueInputDto netPresentValueInputDto)
        {
            var npvCalculator = _npvCalculatorFactory.Build(netPresentValueInputDto.DiscountRateType);
            var result = npvCalculator.Compute(new NetPresentValueCalculationInputDto
            {
                InitialInvestment = netPresentValueInputDto.InitialInvestment,
                DiscountRate = netPresentValueInputDto.DiscountRate,
                IncrementalRate = netPresentValueInputDto.IncrementalRate,
                LowerBound = netPresentValueInputDto.LowerBound,
                UpperBound = netPresentValueInputDto.UpperBound,
                CashFlows = netPresentValueInputDto.CashFlows
            });
            return result;
        }

    }
}

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

        public double GetNetPresentValue(NetPresentValueInputDto netPresentValueInputDto)
        {
            var npvCalculator = _npvCalculatorFactory.Build(netPresentValueInputDto.IsWithIncrementalDiscountRate);
            var result = npvCalculator.Compute(new NetPresentValueCalculationInputDto
            {
                

            });
            return result;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using NpvCalculator.Business.DataTransferObjects;
using NpvCalculator.Business.Factories;

namespace NpvCalculator.Business.Services
{
    public class NetPresentValueService : INetPresentValueService
    {
        private readonly INpvCalculatorFactory _npvCalculatorFactory;
        private readonly IMapper _mapper;
        public NetPresentValueService(INpvCalculatorFactory npvCalculatorFactory, IMapper mapper)
        {
            _npvCalculatorFactory = npvCalculatorFactory;
            _mapper = mapper;
        }

        public IEnumerable<double> GetNetPresentValue(NetPresentValueInputDto netPresentValueInputDto)
        {
            var npvCalculator = _npvCalculatorFactory.Build(netPresentValueInputDto.DiscountRateType);
            var toBeCompute = _mapper.Map<NetPresentValueCalculationInputDto>(netPresentValueInputDto);
            var result = npvCalculator.Compute(toBeCompute);
            return result;
        }

    }
}

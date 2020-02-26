using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using NpvCalculator.Business.DataTransferObjects;
using NpvCalculator.Business.Factories;
using NpvCalculator.DataAccess.Entities;
using NpvCalculator.DataAccess.Repositories;

namespace NpvCalculator.Business.Services
{
    public class NetPresentValueService : INetPresentValueService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly INetPresentValueRepository _netPresentValueRepository;
        private readonly ICashFlowRepository _cashFlowRepository;
        private readonly INpvCalculatorFactory _npvCalculatorFactory;
        private readonly IMapper _mapper;
        public NetPresentValueService(ITransactionRepository transactionRepository, 
                                      INetPresentValueRepository netPresentValueRepository,
                                      ICashFlowRepository cashFlowRepository, 
                                      INpvCalculatorFactory npvCalculatorFactory,
                                      IMapper mapper)
        {
            _transactionRepository = transactionRepository ?? throw new ArgumentException(nameof(transactionRepository));
            _netPresentValueRepository = netPresentValueRepository;
            _cashFlowRepository = cashFlowRepository;
            _npvCalculatorFactory = npvCalculatorFactory ?? throw  new ArgumentException(nameof(npvCalculatorFactory));
            _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
        }

        public IEnumerable<double> GetNetPresentValue(NetPresentValueInputDto netPresentValueInputDto)
        {
            var npvCalculator = _npvCalculatorFactory.Build(netPresentValueInputDto.DiscountRateType);
            var toBeCompute = _mapper.Map<NetPresentValueCalculationInputDto>(netPresentValueInputDto);
            var result = npvCalculator.Compute(toBeCompute);
            return result;
        }

        public IEnumerable<NetPresentValueInputDto> GetAllTransactions()
        {
            var transactions = _transactionRepository.GetAllTransactions();
            var transactionsDto = _mapper.Map<IEnumerable<NetPresentValueInputDto>>(transactions);
            return transactionsDto;
        }

        public NetPresentValueInputDto GetTransactionById(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveTransaction(NetPresentValueInputDto netPresentValueInputDto)
        {
            var transaction = _mapper.Map<Transaction>(netPresentValueInputDto);
            _transactionRepository.InsertTransaction(transaction);

            var cashFlows = _mapper.Map<IEnumerable<CashFlow>>(netPresentValueInputDto.CashFlows);
            cashFlows.ToList().ForEach(c =>
            {
                c.TransactionId = transaction.TransactionId;
                _cashFlowRepository.InsertCashFlow(c);
            });

            var results = _mapper.Map<IEnumerable<NetPresentValue>>(netPresentValueInputDto.NetPresentValueResults);
            results.ToList().ForEach(r =>
            {
                r.TransactionId = transaction.TransactionId;
                _netPresentValueRepository.InsertNetPresentValue(r);
            });
        }
                
    }
}

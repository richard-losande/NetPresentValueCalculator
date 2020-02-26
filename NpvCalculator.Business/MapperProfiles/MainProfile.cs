
using AutoMapper;
using NpvCalculator.Business.DataTransferObjects;
using NpvCalculator.DataAccess.Entities;

namespace NpvCalculator.Business.MapperProfiles
{
    public class MainProfile : Profile
    {
        public MainProfile()
        {
            Profile();
        }

        public void Profile()
        {
            CreateMap<NetPresentValueInputDto, NetPresentValueCalculationInputDto>();
            CreateMap<Transaction, NetPresentValueInputDto>();
            CreateMap<NetPresentValue, NetPresentValueResultInputDto>();
            CreateMap<CashFlow, CashFlowInputDto>();
            CreateMap<NetPresentValueInputDto, Transaction>();
            CreateMap<NetPresentValueResultInputDto, NetPresentValue>();
            CreateMap<CashFlowInputDto, CashFlow>();
        }
    }
}


using AutoMapper;
using NpvCalculator.Business.DataTransferObjects;

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
        }
    }
}

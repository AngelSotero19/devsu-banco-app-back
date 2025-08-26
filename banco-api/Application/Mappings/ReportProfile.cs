using AutoMapper;
using banco_api.Application.UseCases.Reports.Dtos;
using banco_api.Domain.Models;

namespace banco_api.Application.Mappings
{
    public class ReportProfile : Profile
    {
        public ReportProfile()
        {
            CreateMap<Movement, StatementMovementDto>()
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
                .ForMember(dest => dest.MovementType, opt => opt.MapFrom(src => src.MovementType))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value))
                .ForMember(dest => dest.Balance, opt => opt.MapFrom(src => src.Balance))
                .ForMember(dest => dest.AccountNumber, opt => opt.MapFrom(src => src.Account.AccountNumer))
                .ForMember(dest => dest.ClientName, opt => opt.MapFrom(src => src.Account.Client.Person.Name));
        }
    }
}

using AutoMapper;
using banco_api.Application.UseCases.Accounts.Commands.CreateAccount;
using banco_api.Application.UseCases.Accounts.Commands.ToggleStatus;
using banco_api.Application.UseCases.Accounts.Commands.UpdateAccount;
using banco_api.Application.UseCases.Accounts.Dtos;
using banco_api.Domain.Models;

namespace banco_api.Application.Mappings
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<Account, AccountDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.AccountTypeId, opt => opt.MapFrom(src => src.AccountTypeId))
                .ForMember(dest => dest.AccountType, opt => opt.MapFrom(src => src.AccountType.Description))
                .ForMember(dest => dest.ClientId, opt => opt.MapFrom(src => src.ClientId))
                .ForMember(dest => dest.Client, opt => opt.MapFrom(src => src.Client.Person.Name))
                .ForMember(dest => dest.AccountNumer, opt => opt.MapFrom(src => src.AccountNumer))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));

            CreateMap<CreateAccountCommand, Account>()
                .ForMember(dest => dest.Id, opt => Guid.NewGuid().ToString())
                .ForMember(dest => dest.AccountTypeId, opt => opt.MapFrom(src => src.AccountTypeId))
                .ForMember(dest => dest.ClientId, opt => opt.MapFrom(src => src.ClientId))
                .ForMember(dest => dest.AccountNumer, opt => opt.MapFrom(src => src.AccountNumer))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));

            CreateMap<UpdateAccountCommand, Account>()
                .ForMember(dest => dest.AccountTypeId, opt => opt.MapFrom(src => src.AccountTypeId))
                .ForMember(dest => dest.AccountTypeId, opt => opt.MapFrom(src => src.AccountTypeId))
                .ForMember(dest => dest.ClientId, opt => opt.MapFrom(src => src.ClientId))
                .ForMember(dest => dest.AccountNumer, opt => opt.MapFrom(src => src.AccountNumer))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));

            CreateMap<ToggleStatusAccountCommand, AccountToggleRequest>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.NewStatus, opt => opt.MapFrom(src => src.NewStatus));
        }
    }
}

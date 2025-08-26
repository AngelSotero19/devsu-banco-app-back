using AutoMapper;
using banco_api.Application.UseCases.AccountType.Dtos;
using banco_api.Domain.Models;

namespace banco_api.Application.Mappings
{
    public class AccountTypeProfile : Profile
    {
        public AccountTypeProfile()
        {
            CreateMap<AccountType, AccountTypeDto>();

            CreateMap<AccountTypeDto, AccountType>();
        }
    }
}

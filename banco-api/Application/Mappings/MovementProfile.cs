using AutoMapper;
using banco_api.Application.UseCases.Accounts.Commands.CreateAccount;
using banco_api.Application.UseCases.Accounts.Dtos;
using banco_api.Application.UseCases.Movements.Commands.CreateMovement;
using banco_api.Application.UseCases.Movements.Commands.DeleteMovement;
using banco_api.Application.UseCases.Movements.Commands.UpdateMovement;
using banco_api.Application.UseCases.Movements.Dtos;
using banco_api.Domain.Models;

namespace banco_api.Application.Mappings
{
    public class MovementProfile : Profile
    {
        public MovementProfile()
        {
            CreateMap<Movement, MovementDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.AccountId, opt => opt.MapFrom(src => src.AccountId))
                .ForMember(dest => dest.Account, opt => opt.MapFrom(src => src.Account.AccountNumer))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
                .ForMember(dest => dest.MovementType, opt => opt.MapFrom(src => src.MovementType))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value))
                .ForMember(dest => dest.Balance, opt => opt.MapFrom(src => src.Balance));

            CreateMap<CreateMovementCommand, Movement>()
                .ForMember(dest => dest.Id, opt => Guid.NewGuid().ToString())
                .ForMember(dest => dest.AccountId, opt => opt.MapFrom(src => src.AccountId))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
                .ForMember(dest => dest.MovementType, opt => opt.MapFrom(src => src.MovementType))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value))
                .ForMember(dest => dest.Balance, opt => opt.MapFrom(src => src.Balance));

            CreateMap<UpdateMovementCommand, Movement>()
                .ForMember(dest => dest.AccountId, opt => opt.MapFrom(src => src.AccountId))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
                .ForMember(dest => dest.MovementType, opt => opt.MapFrom(src => src.MovementType))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value))
                .ForMember(dest => dest.Balance, opt => opt.MapFrom(src => src.Balance));

            CreateMap<DeleteMovementCommand, Movement>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
        }
    }
}

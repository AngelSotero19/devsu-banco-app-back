using AutoMapper;
using banco_api.Application.UseCases.Clients.Commands.CreateClient;
using banco_api.Application.UseCases.Clients.Commands.ToggleStatus;
using banco_api.Application.UseCases.Clients.Commands.UpdateClient;
using banco_api.Application.UseCases.Clients.Dtos;
using banco_api.Domain.Models;

namespace banco_api.Application.Mappings
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<Client, ClientDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Person.Name))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Person.Gender))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.Person.Age))
                .ForMember(dest => dest.Credential, opt => opt.MapFrom(src => src.Person.Credential))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Person.Address))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Person.Phone));

            CreateMap<CreateClientCommand, Client>()
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));

            CreateMap<UpdateClientCommand, Client>()
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));

            CreateMap<ToggleStatusClientCommand, ClientToggleRequest>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.NewStatus, opt => opt.MapFrom(src => src.NewStatus));

            CreateMap<UpdateClientCommand, ClientDto>()
                .ForMember(dest => dest.PersonId, opt => opt.MapFrom(src => src.PersonId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.Age))
                .ForMember(dest => dest.Credential, opt => opt.MapFrom(src => src.Credential))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone));
        }
    }

}

using AutoMapper;
using MercadoCapitales.API.Clientes.Aplicacion.AccountExecutive.Commands;
using MercadoCapitales.API.Clientes.Models.Dto;
using System;
using Model = MercadoCapitales.API.Clientes.Models;

namespace MercadoCapitales.API.Clientes.Mappings.AccountExecutive
{
    public class AccountExecutiveMappingProfile : Profile
    {
        public AccountExecutiveMappingProfile()
        {
            // Mapear de AccountExecutive a AccountExecutiveDto
            CreateMap<Model.AccountExecutive, AccountExecutiveDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)) // Mapea Guid a Guid?
                .ForMember(dest => dest.Organization, opt => opt.MapFrom(src => src.Organization)) // Mapea Organization
                .ReverseMap(); // De AccountExecutiveDto a AccountExecutive, sin necesidad de especificar los campos si son iguales

            // Si necesitas mapear CreateAccountExecutiveCommand -> AccountExecutive
            CreateMap<CreateAccountExecutiveCommand, Model.AccountExecutive>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.AccountExecutiveDto.Name))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.AccountExecutiveDto.Email))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.AccountExecutiveDto.PhoneNumber))
                .ForMember(dest => dest.Organization, opt => opt.MapFrom(src => src.AccountExecutiveDto.Organization))
                .ForMember(dest => dest.Recommender, opt => opt.MapFrom(src => false)) // Asignación por defecto
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.AccountExecutiveDto.Id ?? Guid.NewGuid())); // Generar nuevo GUID si es null
        }
    }

}

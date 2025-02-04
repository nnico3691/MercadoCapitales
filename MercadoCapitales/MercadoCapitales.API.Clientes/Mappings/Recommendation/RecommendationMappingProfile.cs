using AutoMapper;
using Model = MercadoCapitales.API.Clientes.Models;
using MercadoCapitales.API.Clientes.Models.Dto;
using MercadoCapitales.API.Clientes.Aplicacion.Recommendation.Commands;
using System;
using MercadoCapitales.API.Clientes.Models;

namespace MercadoCapitales.API.Clientes.Mappings.Recommendation
{
    public class RecommendationMappingProfile : Profile
    {
        public RecommendationMappingProfile()
        {
            // Mapeo de CreateRecommendationCommand → Recommendation
            CreateMap<CreateRecommendationCommand, Model.Recommendation>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()) // El ID lo genera la BD
                .ForMember(dest => dest.DateCreated, opt => opt.MapFrom(src => src.RecommendationDto.DateCreated))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.RecommendationDto.Description))
                .ForMember(dest => dest.RiskLevel, opt => opt.MapFrom(src => src.RecommendationDto.RiskLevel))
                .ForMember(dest => dest.AccountExecutiveId, opt => opt.MapFrom(src => src.RecommendationDto.AccountExecutiveId))
                .ForMember(dest => dest.Active, opt => opt.MapFrom(_ => true)) // Por defecto activo
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow))
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore()) // Esto dependerá del contexto
                .ReverseMap();

            // Mapeo de InvestmentRecommendation → InvestmentRecommendationDto
            CreateMap<Model.InvestmentRecommendation, InvestmentRecommendationCommandDto>().ReverseMap();

            CreateMap<InvestmentRecommendation, InvestmentRecommendationQueryDto>()
            .ForMember(dest => dest.InstrumentDto, opt => opt.Ignore()); // Se asigna manualmente

            CreateMap<Model.Recommendation, RecommendationCommandDto>()
            .ForMember(dest => dest.InvestmentRecommendation, opt => opt.MapFrom(src => src.InvestmentRecommendation)).ReverseMap();

            CreateMap<Model.Recommendation, RecommendationQueryDto>()
            .ForMember(dest => dest.InvestmentRecommendation, opt => opt.MapFrom(src => src.InvestmentRecommendation)).ReverseMap();
        }
    }
}

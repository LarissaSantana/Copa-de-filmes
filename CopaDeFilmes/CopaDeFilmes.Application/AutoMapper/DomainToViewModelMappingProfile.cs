using AutoMapper;
using CopaDeFilmes.Application.ViewModels;
using CopaDeFilmes.Domain.Entities;

namespace CopaDeFilmes.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Filme, FilmeViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Ano, opt => opt.MapFrom(src => src.Ano))
                .ForMember(dest => dest.Titulo, opt => opt.MapFrom(src => src.Titulo));
        }
    }
}

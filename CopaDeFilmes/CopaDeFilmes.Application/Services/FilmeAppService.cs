using AutoMapper;
using CopaDeFilmes.Application.Interfaces;
using CopaDeFilmes.Application.ViewModels;
using CopaDeFilmes.Domain.Repositories;
using System.Collections.Generic;

namespace CopaDeFilmes.Application.Services
{
    public class FilmeAppService : IFilmeAppService
    {
        private readonly IFilmeRepository _filmeRepository;
        private readonly IMapper _mapper;

        public FilmeAppService(IFilmeRepository filmeRepository)
        {
            _filmeRepository = filmeRepository;
        }

        public IEnumerable<FilmeViewModel> ObterTodosOsFilmes()
        {
            var filmes = _filmeRepository.ObterTodosOsFilmesAsync();
            return _mapper.Map<IEnumerable<FilmeViewModel>>(filmes);
        }
    }
}

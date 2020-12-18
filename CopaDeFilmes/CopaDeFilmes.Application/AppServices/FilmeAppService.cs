using AutoMapper;
using CopaDeFilmes.Application.Interfaces;
using CopaDeFilmes.Application.ViewModels;
using CopaDeFilmes.Domain.Core.Notifications;
using CopaDeFilmes.Domain.Entities;
using CopaDeFilmes.Domain.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CopaDeFilmes.Application.Services
{
    public class FilmeAppService : IFilmeAppService
    {
        private readonly IFilmeService _filmeService;
        private readonly IMapper _mapper;

        public FilmeAppService(IFilmeService filmeService, IMapper mapper)
        {
            _filmeService = filmeService;
            _mapper = mapper;
        }

        public async Task<List<FilmeViewModel>> ObterTodosOsFilmes()
        {
            var filmes = await _filmeService.ObterTodosOsFilmes();
            var filmesViewModel = _mapper.Map<List<FilmeViewModel>>(filmes);
            return filmesViewModel;
        }

        public CampeonatoViewModel ProcessarCampeonato(List<FilmeViewModel> filmesViewModel)
        {
            var filmes = _mapper.Map<List<Filme>>(filmesViewModel);
            var campeonato = _filmeService.ProcessarCampeonato(filmes);

            return _mapper.Map<CampeonatoViewModel>(campeonato);
        }
    }
}

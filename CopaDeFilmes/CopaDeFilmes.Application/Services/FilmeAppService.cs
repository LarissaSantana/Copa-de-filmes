using AutoMapper;
using CopaDeFilmes.Application.Interfaces;
using CopaDeFilmes.Application.ViewModels;
using CopaDeFilmes.Domain.Core.Notifications;
using CopaDeFilmes.Domain.Entities;
using CopaDeFilmes.Domain.Service;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CopaDeFilmes.Application.Services
{
    public class FilmeAppService : IFilmeAppService
    {
        private readonly IFilmeService _filmeService;
        private readonly INotificationContext<Notification> _notification;
        private readonly IMapper _mapper;

        public FilmeAppService(IFilmeService filmeService, INotificationContext<Notification> notification, IMapper mapper)
        {
            _filmeService = filmeService;
            _notification = notification;
            _mapper = mapper;
        }

        public async Task<List<FilmeViewModel>> ObterTodosOsFilmes()
        {
            var filmes = await _filmeService.ObterTodosOsFilmes();
            var filmesViewModel = _mapper.Map<List<FilmeViewModel>>(filmes);
            return filmesViewModel;
        }

        public VencedoresViewModel ProcessarCampeonato(List<FilmeViewModel> filmesViewModel)
        {
            var filmes = _mapper.Map<List<Filme>>(filmesViewModel);
            var podio = _filmeService.ProcessarCampeonato(filmes);

            if (!podio.Any()) return new VencedoresViewModel();

            var vencedores = new VencedoresViewModel()
            {
                PrimeiroColocado = _mapper.Map<FilmeViewModel>(podio[0]),
                SegundoColocado = _mapper.Map<FilmeViewModel>(podio[1])
            };

            return vencedores;
        }

        //private VencedoresViewModel DefinirVencedoresDoCampeonato(List<Filme> podio)
        //{
        //    //var primeiroColocado = _filmeService.DefinirVencedorDaPartida(podio[0], podio[1]);
        //    //var segundoColocado = podio.Where(filme => filme != primeiroColocado).FirstOrDefault();

        //    var vencedoresViewModel = new VencedoresViewModel()
        //    {
        //        PrimeiroColocado = _mapper.Map<FilmeViewModel>(podio[0]),
        //        SegundoColocado = _mapper.Map<FilmeViewModel>(podio[1])
        //    };

        //    return vencedoresViewModel;
        //}
    }
}

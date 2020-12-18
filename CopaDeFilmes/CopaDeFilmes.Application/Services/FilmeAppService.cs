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
            ValidarCampeonato(filmesViewModel);
            if (_notification.HasNotifications()) return new VencedoresViewModel();

            var filmes = _mapper.Map<List<Filme>>(filmesViewModel);
            var podio = _filmeService.ProcessarCampeonato(filmes);

            var vencedores = new VencedoresViewModel()
            {
                PrimeiroColocado = _mapper.Map<FilmeViewModel>(podio[0]),
                SegundoColocado = _mapper.Map<FilmeViewModel>(podio[1])
            };

            return vencedores;
        }

        private void ValidarCampeonato(List<FilmeViewModel> filmesViewModel)
        {
            if (filmesViewModel != null && !filmesViewModel.Any())
            {
                _notification.AddNotification("Para gerar um campeonato, é necessário ter, pelo menos, dois filmes");
                return;
            }

            if ((filmesViewModel.Count()) % 2 != 0)
            {
                _notification.AddNotification("Para gerar um campeonato, é necessário ter uma quantidade par de filmes");
                return;
            }
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

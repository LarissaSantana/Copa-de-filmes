using AutoMapper;
using CopaDeFilmes.Application.Interfaces;
using CopaDeFilmes.Application.ViewModels;
using CopaDeFilmes.Domain.Core.Notifications;
using CopaDeFilmes.Domain.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CopaDeFilmes.Application.Services
{
    public partial class FilmeAppService : IFilmeAppService
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
    }
}

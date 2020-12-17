using AutoMapper;
using CopaDeFilmes.Application.Interfaces;
using CopaDeFilmes.Application.ViewModels;
using CopaDeFilmes.Domain.Core.Notifications;
using CopaDeFilmes.Domain.Repositories;
using System.Threading.Tasks;

namespace CopaDeFilmes.Application.Services
{
    public partial class FilmeAppService : IFilmeAppService
    {
        private readonly IFilmeRepository _filmeRepository;
        private readonly INotificationContext _notification;
        private readonly IMapper _mapper;

        public FilmeAppService(IFilmeRepository filmeRepository, INotificationContext notification, IMapper mapper)
        {
            _filmeRepository = filmeRepository;
            _notification = notification;
            _mapper = mapper;
        }

        public async Task<FilmeViewModel[]> ObterTodosOsFilmes()
        {
            var filmes = await _filmeRepository.ObterTodosOsFilmesAsync();
            var filmesViewModel = _mapper.Map<FilmeViewModel[]>(filmes);
            return filmesViewModel;
        }
    }
}

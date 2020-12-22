using CopaDeFilmes.Domain.Core.Notifications;
using CopaDeFilmes.Domain.Entities;
using CopaDeFilmes.Domain.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CopaDeFilmes.Domain.Service
{
    public partial class FilmeService : IFilmeService
    {
        private readonly IFilmeRepository _filmeRepository;
        private readonly INotificationContext<Notification> _notification;

        public FilmeService(IFilmeRepository filmeRepository, INotificationContext<Notification> notification)
        {
            _filmeRepository = filmeRepository;
            _notification = notification;
        }

        public async Task<List<Filme>> ObterTodosOsFilmes()
        {
            var filmes = await _filmeRepository.ObterTodosOsFilmesAsync();
            return filmes;
        }
    }
}

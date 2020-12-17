using CopaDeFilmes.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CopaDeFilmes.Domain.Repositories
{
    public interface IFilmeRepository
    {
        Task<List<Filme>> ObterTodosOsFilmesAsync();
    }
}

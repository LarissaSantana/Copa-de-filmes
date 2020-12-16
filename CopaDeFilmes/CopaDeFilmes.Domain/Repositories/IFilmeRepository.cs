using CopaDeFilmes.Domain.Entities;
using System.Threading.Tasks;

namespace CopaDeFilmes.Domain.Repositories
{
    public interface IFilmeRepository
    {
        Task<Filme[]> ObterTodosOsFilmesAsync();
    }
}

using CopaDeFilmes.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CopaDeFilmes.Domain.Service
{
    public interface IFilmeService
    {
        Task<List<Filme>> ObterTodosOsFilmes();
    }
}

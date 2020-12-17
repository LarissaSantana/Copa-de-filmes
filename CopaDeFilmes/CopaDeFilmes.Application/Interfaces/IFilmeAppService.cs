using CopaDeFilmes.Application.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CopaDeFilmes.Application.Interfaces
{
    public interface IFilmeAppService
    {
        Task<FilmeViewModel[]> ObterTodosOsFilmes();
        VencedoresViewModel ProcessarCampeonato(List<FilmeViewModel> filmes);
    }
}

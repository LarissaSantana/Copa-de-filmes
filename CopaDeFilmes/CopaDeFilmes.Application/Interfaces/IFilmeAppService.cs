using CopaDeFilmes.Application.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CopaDeFilmes.Application.Interfaces
{
    public interface IFilmeAppService
    {
        Task<List<FilmeViewModel>> ObterTodosOsFilmes();
        CampeonatoViewModel ProcessarCampeonato(List<FilmeViewModel> filmes);
    }
}

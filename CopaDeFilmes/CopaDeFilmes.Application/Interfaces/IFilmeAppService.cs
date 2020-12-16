using CopaDeFilmes.Application.ViewModels;
using System.Threading.Tasks;

namespace CopaDeFilmes.Application.Interfaces
{
    public interface IFilmeAppService
    {
        Task<FilmeViewModel[]> ObterTodosOsFilmes();
    }
}

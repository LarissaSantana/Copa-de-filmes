using CopaDeFilmes.Application.ViewModels;
using System.Collections.Generic;

namespace CopaDeFilmes.Application.Interfaces
{
    public interface IFilmeAppService
    {
        IEnumerable<FilmeViewModel> ObterTodosOsFilmes();
    }
}

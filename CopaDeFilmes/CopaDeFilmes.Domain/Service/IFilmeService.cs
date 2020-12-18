using CopaDeFilmes.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CopaDeFilmes.Domain.Service
{
    public interface IFilmeService
    {
        Task<List<Filme>> ObterTodosOsFilmes();
        Campeonato ProcessarCampeonato(List<Filme> filmes);
        List<Filme> OrganizarPrimeiraRodada(List<Filme> filmes);
        Filme DefinirVencedorDaPartida(Filme filmeA, Filme filmeB);
    }
}

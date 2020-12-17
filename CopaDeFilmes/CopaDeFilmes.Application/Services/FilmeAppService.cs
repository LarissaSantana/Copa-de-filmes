using AutoMapper;
using CopaDeFilmes.Application.Interfaces;
using CopaDeFilmes.Application.ViewModels;
using CopaDeFilmes.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CopaDeFilmes.Application.Services
{
    public class FilmeAppService : IFilmeAppService
    {
        private readonly IFilmeRepository _filmeRepository;
        private readonly IMapper _mapper;

        public FilmeAppService(IFilmeRepository filmeRepository, IMapper mapper)
        {
            _filmeRepository = filmeRepository;
            _mapper = mapper;
        }

        public async Task<FilmeViewModel[]> ObterTodosOsFilmes()
        {
            var filmes = await _filmeRepository.ObterTodosOsFilmesAsync();
            var filmesViewModel = _mapper.Map<FilmeViewModel[]>(filmes);
            return filmesViewModel;
        }

        public VencedoresViewModel GerarCampeonato(List<FilmeViewModel> filmes)
        {
            if (!filmes.Any()) return new VencedoresViewModel();
            var quantidadeDeFilmes = filmes.Count();
            //if (filmes.Count() % 2 != 0)  
            //TODO: retornar que só é possível gerar um campeonato com uma quantidade par de filmes. Ver como vai tratar e retornar os erros para a controller.

            var filmesOrdenados = filmes.OrderBy(f => f.Titulo).ToList();

            var teste = OrganizarPrimeiraRodada(filmesOrdenados);
            var vencedoresPrimeiraPartida = ProcessarPartida(teste);

            return null;
        }

        private void ProcessarPodio(List<FilmeViewModel> filmes)
        {

        }

        private List<FilmeViewModel> ProcessarPartida(List<FilmeViewModel> filmes)
        {
            var vencedores = new List<FilmeViewModel>();

            for (int i = 0; i < filmes.Count(); i++)
            {
                //pula para a próxima posição par
                if (i % 2 == 1) continue;
                var proximo = filmes[i + 1];
                vencedores.Add(DefinirVencedorDaPartida(filmes[i], proximo));
            }
            return vencedores;
        }

        private List<FilmeViewModel> OrganizarPrimeiraRodada(List<FilmeViewModel> listaOrdenada)
        {
            var metadeDoTamanho = listaOrdenada.Count() / 2;
            var primeiraMetade = listaOrdenada.Take(metadeDoTamanho).ToList();
            var segundaMetade = listaOrdenada.Skip(metadeDoTamanho).Reverse().ToList();

            var primeiraRodada = new List<FilmeViewModel>();

            primeiraMetade.Zip(segundaMetade, (item1, item2) =>
                                {
                                    primeiraRodada.Add(item1);
                                    primeiraRodada.Add(item2);
                                    return primeiraRodada;
                                }).ToList();

            return primeiraRodada;
        }

        private FilmeViewModel DefinirVencedorDaPartida(FilmeViewModel filmeA, FilmeViewModel filmeB)
        {
            //TODO: ver o que fazer caso as notas e os titulos dos filmes sejam iguais
            if (filmeA.Nota == filmeB.Nota)
            {
                if (filmeA.Titulo.CompareTo(filmeB.Titulo) > 0)
                    return filmeA;
                else if (filmeA.Titulo.CompareTo(filmeB.Titulo) < 0)
                    return filmeB;
            }
            else if (filmeA.Nota > filmeB.Nota)
                return filmeA;

            return filmeB;
        }
    }
}

using CopaDeFilmes.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CopaDeFilmes.Application.Services
{
    public partial class FilmeAppService
    {
        public VencedoresViewModel GerarCampeonato(List<FilmeViewModel> filmes)
        {
            if (!filmes.Any()) return new VencedoresViewModel();
            var quantidadeDeFilmes = filmes.Count();
            //if (filmes.Count() % 2 != 0)  
            //TODO: retornar que só é possível gerar um campeonato com uma quantidade par de filmes. Ver como vai tratar e retornar os erros para a controller.

            var filmesOrdenados = filmes.OrderBy(f => f.Titulo).ToList();

            var teste = OrganizarPrimeiraRodada(filmesOrdenados);
            var podio = ProcessarPodio(teste);
            var vencedores = DefinirVencedoresDoCampeonato(podio);

            return vencedores;
        }

        private VencedoresViewModel DefinirVencedoresDoCampeonato(List<FilmeViewModel> filmesVencedores)
        {
            var primeiroColocado = DefinirVencedorDaPartida(filmesVencedores[0], filmesVencedores[1]);
            var segundoColocado = filmesVencedores.Where(filme => filme != primeiroColocado).FirstOrDefault();

            var vencedoresViewModel = new VencedoresViewModel()
            {
                PrimeiroColocado = primeiroColocado,
                SegundoColocado = segundoColocado
            };

            return vencedoresViewModel;
        }

        private List<FilmeViewModel> ProcessarPodio(List<FilmeViewModel> filmes)
        {
            return filmes.Count() == 2 ? filmes : ProcessarPodio(ProcessarPartida(filmes));
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
                if (filmeA.Titulo.CompareTo(filmeB.Titulo) < 0)
                    return filmeA;
                else if (filmeA.Titulo.CompareTo(filmeB.Titulo) > 0)
                    return filmeB;
            }
            else if (filmeA.Nota > filmeB.Nota)
                return filmeA;

            return filmeB;
        }
    }
}

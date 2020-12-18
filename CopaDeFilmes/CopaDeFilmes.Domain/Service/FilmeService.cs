using CopaDeFilmes.Domain.Core.Notifications;
using CopaDeFilmes.Domain.Entities;
using CopaDeFilmes.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CopaDeFilmes.Domain.Service
{
    public class FilmeService : IFilmeService
    {
        private readonly IFilmeRepository _filmeRepository;
        private readonly INotificationContext<Notification> _notification;

        public FilmeService(IFilmeRepository filmeRepository, INotificationContext<Notification> notification)
        {
            _filmeRepository = filmeRepository;
            _notification = notification;
        }

        public async Task<List<Filme>> ObterTodosOsFilmes()
        {
            var filmes = await _filmeRepository.ObterTodosOsFilmesAsync();
            return filmes;
        }

        public List<Filme> ProcessarCampeonato(List<Filme> filmes)
        {
            var primeiraRodada = OrganizarPrimeiraRodada(filmes);
            var podio = ProcessarPodio(primeiraRodada);

            return podio;
        }

        private List<Filme> OrganizarPrimeiraRodada(List<Filme> filmes)
        {
            var filmesOrdenados = filmes.OrderBy(f => f.Titulo).ToList();
            var metadeDoTamanho = filmesOrdenados.Count() / 2;
            var primeiraMetadeDosFilmes = filmesOrdenados.Take(metadeDoTamanho).ToList();
            var segundaMetadeDosFilmes = filmesOrdenados.Skip(metadeDoTamanho).Reverse().ToList();

            var primeiraRodada = new List<Filme>();

            primeiraMetadeDosFilmes.Zip(segundaMetadeDosFilmes, (item1, item2) =>
            {
                primeiraRodada.Add(item1);
                primeiraRodada.Add(item2);
                return primeiraRodada;
            }).ToList();

            return primeiraRodada;
        }

        private List<Filme> ProcessarPartida(List<Filme> filmes)
        {
            var vencedores = new List<Filme>();

            for (int i = 0; i < filmes.Count(); i++)
            {
                //pula para a próxima posição par
                if (i % 2 == 1) continue;
                var proximoFilme = filmes[i + 1];
                vencedores.Add(DefinirVencedorDaPartida(filmes[i], proximoFilme));
            }
            return vencedores;
        }

        private List<Filme> ProcessarPodio(List<Filme> filmes)
        {
            return filmes.Count() == 2 ? filmes : ProcessarPodio(ProcessarPartida(filmes));
        }

        public Filme DefinirVencedorDaPartida(Filme filmeA, Filme filmeB)
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

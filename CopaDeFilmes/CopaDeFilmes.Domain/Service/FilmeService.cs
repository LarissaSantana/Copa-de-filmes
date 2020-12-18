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
            ValidarCampeonato(filmes);
            if (_notification.HasNotifications()) return new List<Filme>();

            var primeiraRodada = OrganizarPrimeiraRodada(filmes);
            var podio = ProcessarPodio(primeiraRodada);
            podio = podio.OrderBy(filme => filme.Nota)
                         .ThenBy(filme => filme.Titulo)
                         .ToList();

            return podio;
        }

        private void ValidarCampeonato(List<Filme> filmesViewModel)
        {
            if (filmesViewModel != null && !filmesViewModel.Any())
            {
                _notification.AddNotification("Para gerar um campeonato, é necessário ter, pelo menos, dois filmes");
                return;
            }

            if ((filmesViewModel.Count()) % 2 != 0)
            {
                _notification.AddNotification("Para gerar um campeonato, é necessário ter uma quantidade par de filmes");
                return;
            }
        }

        public List<Filme> OrganizarPrimeiraRodada(List<Filme> filmes)
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

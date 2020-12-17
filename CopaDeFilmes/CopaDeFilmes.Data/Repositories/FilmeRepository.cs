using CopaDeFilmes.Domain.Entities;
using CopaDeFilmes.Domain.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using static CopaDeFilmes.Domain.Entities.Filme;

namespace CopaDeFilmes.Data.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        //TODO: configurar a injeção de dependência
        private readonly HttpClient _client;

        public HttpResponseMessage HttpResponseMessage { get; private set; }

        public FilmeRepository(HttpClient client)
        {
            _client = client;
        }

        public FilmeRepository()
        {
            //TODO: configurar a DI
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://copafilmes.azurewebsites.net/");
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<Filme>> ObterTodosOsFilmesAsync()
        {
            var response = await _client.GetAsync("api/filmes");

            if (response.IsSuccessStatusCode)
            {
                var filmes = await response.Content.ReadAsStringAsync();
                var listaDeFilmesDTO = JsonConvert.DeserializeObject<FilmeDTO[]>(filmes).ToList();

                var listaDeFilmes = new List<Filme>();
                listaDeFilmesDTO.ForEach(filme => listaDeFilmes.Add(FilmeFactory.Create(filme.Id, filme.Titulo, filme.Ano, filme.Nota)));
                return listaDeFilmes.ToList();
            }

            return new List<Filme>();
        }
    }
}

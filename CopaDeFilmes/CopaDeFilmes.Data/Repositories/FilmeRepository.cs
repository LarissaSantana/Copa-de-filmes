using CopaDeFilmes.Domain.Entities;
using CopaDeFilmes.Domain.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

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
            _client.BaseAddress = new Uri("http://copafilmes.azurewebsites.net/");
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<Filme>> ObterTodosOsFilmesAsync()
        {
            HttpResponseMessage response = await _client.GetAsync("api/filmes");
            if (response.IsSuccessStatusCode)
            {
                var dados = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<Filme>>(dados);
            }

            return new List<Filme>();
        }
    }
}
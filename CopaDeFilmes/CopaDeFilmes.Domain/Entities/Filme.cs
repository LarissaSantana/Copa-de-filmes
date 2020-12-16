using Newtonsoft.Json;

namespace CopaDeFilmes.Domain.Entities
{
    public class Filme
    {
        [JsonProperty("id")]
        public string Id { get; private set; }

        [JsonProperty("titulo")]
        public string Titulo { get; private set; }

        [JsonProperty("ano")]
        public int Ano { get; private set; }

        [JsonProperty("nota")]
        public float Nota { get; private set; }
    }
}

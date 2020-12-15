namespace CopaDeFilmes.Domain.Entities
{
    public class Filme
    {
        public string Id { get; private set; }
        public string Titulo { get; private set; }
        public int Ano { get; private set; }
        public float Nota { get; private set; }
    }
}

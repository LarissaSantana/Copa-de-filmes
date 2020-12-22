namespace CopaDeFilmes.Application.ViewModels
{
    public class FilmeViewModel
    {
        public string Id { get; set; }
        public string Titulo { get; set; }
        public int Ano { get; set; }
        public float Nota { get; set; }

        public FilmeViewModel(string id, string titulo, int ano, float nota)
        {
            Id = id;
            Titulo = titulo;
            Ano = ano;
            Nota = nota;
        }
    }
}

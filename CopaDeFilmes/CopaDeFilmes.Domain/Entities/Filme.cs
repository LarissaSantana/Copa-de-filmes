using CopaDeFilmes.Domain.Core;

namespace CopaDeFilmes.Domain.Entities
{
    public class Filme : BaseEntity<Filme>
    {
        public string Titulo { get; private set; }
        public int Ano { get; private set; }
        public float Nota { get; private set; }

        public Filme(string id, string titulo, int ano, float nota)
        {
            Id = id;
            Titulo = titulo;
            Ano = ano;
            Nota = nota;
        }

        public override bool IsValid()
        {
            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }

        public static class FilmeFactory
        {
            public static Filme Create(string id, string titulo, int ano, float nota)
            {
                return new Filme(id, titulo, ano, nota);
            }
        }
    }
}

namespace CopaDeFilmes.Domain.Entities
{
    public class Filme : BaseEntity<Filme>
    {
        public string Id { get; private set; }
        public string Titulo { get; private set; }
        public int Ano { get; private set; }
        public float Nota { get; private set; }

        public override bool IsValid()
        {
            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }
    }
}

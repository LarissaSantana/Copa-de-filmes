using FluentValidation;
using FluentValidation.Results;

namespace CopaDeFilmes.Domain.Core
{
    public abstract class BaseEntity<T> : AbstractValidator<T> where T : BaseEntity<T>
    {
        public string Id { get; protected set; }

        public ValidationResult ValidationResult { get; protected set; }

        protected BaseEntity()
        {
            ValidationResult = new ValidationResult();
        }

        public abstract bool IsValid();
    }
}

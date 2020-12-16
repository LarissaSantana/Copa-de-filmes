using FluentValidation;
using FluentValidation.Results;

namespace CopaDeFilmes.Domain.Core
{
    //TODO: ver se vai ser necessário
    public abstract class BaseEntity<T> : AbstractValidator<T> where T : BaseEntity<T>
    {
        public ValidationResult ValidationResult { get; protected set; }
        protected BaseEntity()
        {
            ValidationResult = new ValidationResult();
        }

        public abstract bool IsValid();
    }
}

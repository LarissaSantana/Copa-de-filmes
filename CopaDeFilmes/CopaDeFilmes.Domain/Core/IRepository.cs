namespace CopaDeFilmes.Domain.Core
{
    public interface IRepository<TEntity> where TEntity : BaseEntity<TEntity>
    {
        TEntity ObterTodosOsFilmes();
    }
}

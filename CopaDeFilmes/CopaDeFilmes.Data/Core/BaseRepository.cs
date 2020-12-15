using CopaDeFilmes.Domain.Core;

namespace CopaDeFilmes.Data.Core
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity<TEntity>
    {
        public BaseRepository() { }
    }
}

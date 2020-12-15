using CopaDeFilmes.Data.Core;
using CopaDeFilmes.Domain.Entities;
using CopaDeFilmes.Domain.Repositories;
using System;

namespace CopaDeFilmes.Data.Repositories
{
    public class FilmeRepository : BaseRepository<Filme>, IFilmeRepository
    {
        public FilmeRepository() { }

        public Filme ObterTodosOsFilmes()
        {
            throw new NotImplementedException();
        }
    }
}

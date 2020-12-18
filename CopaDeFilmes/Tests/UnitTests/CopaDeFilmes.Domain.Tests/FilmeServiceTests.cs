using CopaDeFilmes.Domain.Service;
using Xunit;

namespace CopaDeFilmes.Domain.Tests
{
    [Collection(nameof(FilmeServiceCollection))]
    public class FilmeServiceTests
    {
        private readonly FilmeService _filmeService;
        private readonly FilmeServiceFixture _filmeServiceFixture;

        public FilmeServiceTests(FilmeServiceFixture filmeServiceFixture)
        {
            _filmeServiceFixture = filmeServiceFixture;
            _filmeService = _filmeServiceFixture.GetFilmeService();
        }


    }
}

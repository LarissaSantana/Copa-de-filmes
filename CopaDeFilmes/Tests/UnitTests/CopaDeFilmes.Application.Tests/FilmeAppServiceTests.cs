using CopaDeFilmes.Application.Services;
using Xunit;

namespace CopaDeFilmes.Application.Tests
{
    [Collection(nameof(FilmeAppServiceCollection))]
    public class FilmeAppServiceTests
    {
        private readonly FilmeAppService _filmeAppService;
        private readonly FilmeAppServiceFixture _filmeAppServiceFixture;

        public FilmeAppServiceTests(FilmeAppServiceFixture filmeAppServiceFixture)
        {
            _filmeAppServiceFixture = filmeAppServiceFixture;
            _filmeAppService = _filmeAppServiceFixture.GetFilmeAppService();
        }
    }
}

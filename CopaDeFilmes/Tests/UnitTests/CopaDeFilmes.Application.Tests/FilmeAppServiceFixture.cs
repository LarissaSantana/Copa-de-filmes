using CopaDeFilmes.Application.Services;
using Moq.AutoMock;
using Xunit;

namespace CopaDeFilmes.Application.Tests
{
    [CollectionDefinition(nameof(FilmeAppServiceCollection))]
    public class FilmeAppServiceCollection : ICollectionFixture<FilmeAppServiceFixture> { }
    public class FilmeAppServiceFixture
    {
        public FilmeAppService FilmeAppService;
        public AutoMocker Mocker;

        public FilmeAppService GetFilmeAppService()
        {
            Mocker = new AutoMocker();
            return Mocker.CreateInstance<FilmeAppService>();
        }
    }
}

using CopaDeFilmes.Domain.Service;
using Moq.AutoMock;
using Xunit;

namespace CopaDeFilmes.Domain.Tests
{
    [CollectionDefinition(nameof(FilmeServiceCollection))]
    public class FilmeServiceCollection : ICollectionFixture<FilmeServiceFixture> { }
    public class FilmeServiceFixture
    {
        public FilmeService FilmeService;
        public AutoMocker Mocker;

        public FilmeService GetFilmeService()
        {
            Mocker = new AutoMocker();
            return Mocker.CreateInstance<FilmeService>();
        }
    }
}

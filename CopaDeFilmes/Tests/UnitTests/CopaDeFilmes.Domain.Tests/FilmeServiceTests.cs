using CopaDeFilmes.Domain.Entities;
using CopaDeFilmes.Domain.Service;
using Moq;
using System.Collections.Generic;
using System.Linq;
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

        // TODO: Processar campeonato 
        //[Trait("Filme", "FilmeService")]
        //[Fact(DisplayName = "Deve executar com sucesso ")]
        //public void ProcessarCampeonato_DeveExecutarComSucesso()
        //{
        //    //Arrange
        //    var filmesMock = new List<Filme>()
        //    {
        //        FilmesMock.OsIncriveis2,
        //        FilmesMock.JurassicWorld,
        //        FilmesMock.OitoMulheresEUmSegredo,
        //        FilmesMock.Hereditario,
        //        FilmesMock.Vingadores,
        //        FilmesMock.Deadpool2,
        //        FilmesMock.HanSolo,
        //        FilmesMock.ThorRagnarok
        //    };

        //    //Act
        //    var podio = _filmeService.ProcessarCampeonato(filmesMock);

        //    //Assert

        //    _filmeServiceFixture.Mocker.GetMock<IFilmeService>()
        //        .Verify(x => x.OrganizarPrimeiraRodada(It.IsAny<List<Filme>>()), Times.Once);

        //    _filmeServiceFixture.Mocker.GetMock<IFilmeService>()
        //        .Verify(x => x.OrganizarPrimeiraRodada(It.Is<List<Filme>>(filmes => filmes.Equals(filmesMock))),
        //        Times.Once);

        //}

        // TODO: Processar campeonato 
        [Trait("Filme", "FilmeService")]
        [Fact(DisplayName = "Deve executar com sucesso quando organizar primeira partida com o parâmetro correto")]
        public void OrganizarPrimeiraRodada_DeveExecutarComSucesso()
        {
            //Arrange
            var filmesMock = new List<Filme>()
            {
                FilmesMock.OsIncriveis2,
                FilmesMock.JurassicWorld,
                FilmesMock.OitoMulheresEUmSegredo,
                FilmesMock.Hereditario,
                FilmesMock.Vingadores,
                FilmesMock.Deadpool2,
                FilmesMock.HanSolo,
                FilmesMock.ThorRagnarok
            };

            //Act
            var primeiraRodada = _filmeService.OrganizarPrimeiraRodada(filmesMock);

            //Assert
            var resultadoEsperado = new List<Filme>()
            {
                FilmesMock.Deadpool2,
                FilmesMock.Vingadores,
                FilmesMock.HanSolo,
                FilmesMock.ThorRagnarok,
                FilmesMock.Hereditario,
                FilmesMock.OsIncriveis2,
                FilmesMock.JurassicWorld,
                FilmesMock.OitoMulheresEUmSegredo
            };

            Assert.True(resultadoEsperado.SequenceEqual(primeiraRodada));
        }
    }
}

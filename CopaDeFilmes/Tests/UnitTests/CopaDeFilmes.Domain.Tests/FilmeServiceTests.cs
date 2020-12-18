using CopaDeFilmes.Domain.Entities;
using CopaDeFilmes.Domain.Service;
using Moq;
using System;
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


        //TODO: PROCESSAR CAMPEONATO PASSANDO UMA LISTA VAZIA
        //TODO: PROCESSAR CAMPEONATO PASSANDO UM NÚMERO IMPAR DE ITENS
        //TODO: PROCESSAR CAMPEONATO PASSANDO UMA LISTA VAZIA
        //TODO: Processar campeonato 

        //[Trait("Filme", "FilmeService")]
        //[Fact(DisplayName = "Ao processar campeonato com o parâmetro correto deve executar com sucesso")]
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
        //        .Verify(x => x.OrganizarPrimeiraRodada(It.Is<List<Filme>>(filmes => filmes.SequenceEqual(filmesMock))),
        //        Times.Once);
        //}



        [Trait("Filme", "FilmeService")]
        [Fact(DisplayName = "Ao organizar primeira partida com o parâmetro correto deve executar com sucesso")]
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

        [Trait("Filme", "FilmeService Campeonato")]
        [Fact(DisplayName = "Ao definir vencedor da partida com notas diferentes deve executar com sucesso")]
        public void DefinirVencedorDaPartida_ComNotasDiferentes_DeveRetornarOFilmeDeMaiorNota()
        {
            //Arrange
            var filmeA = FilmesMock.OitoMulheresEUmSegredo;
            var filmeB = FilmesMock.OsIncriveis2;

            //Act
            var vencedor = _filmeService.DefinirVencedorDaPartida(filmeA, filmeB);

            //Assert
            Assert.Equal(filmeB, vencedor);
        }

        [Trait("Filme", "FilmeService Campeonato")]
        [Fact(DisplayName = "Ao definir vencedor da partida com notas iguais deve executar com sucesso")]
        public void DefinirVencedorDaPartida_ComNotasIguais_DeveRetornarOPrimeiroEmOrdemAlfabetica()
        {
            //Arrange
            var filmeA = FilmesMock.AViagemDeChihiro;
            var filmeB = FilmesMock.Vingadores;

            //Act
            var vencedor = _filmeService.DefinirVencedorDaPartida(filmeA, filmeB);

            //Assert
            Assert.Equal(filmeA, vencedor);
        }
    }
}

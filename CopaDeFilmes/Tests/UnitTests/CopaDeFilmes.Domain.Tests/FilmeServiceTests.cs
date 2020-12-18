using CopaDeFilmes.Domain.Core.Notifications;
using CopaDeFilmes.Domain.Entities;
using CopaDeFilmes.Domain.Service;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using static CopaDeFilmes.Domain.Entities.Campeonato;

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

        [Trait("Filme", "FilmeService Campeonato")]
        [Fact(DisplayName = "Ao executar campeonato passando o parâmetro correto, deve execuitar com sucesso")]
        public void ProcessarCampeonato_DeveExecutarComSucesso()
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
            var campeonato = _filmeService.ProcessarCampeonato(filmesMock);

            //Assert
            _filmeServiceFixture.Mocker.GetMock<INotificationContext<Notification>>()
                 .Verify(x => x.AddNotification(It.IsAny<string>()), Times.Never);

            var resultadoEsperado = CampeonatoFactory.Create
                (
                    campeao: FilmesMock.Vingadores,
                    viceCampeao: FilmesMock.OsIncriveis2
                );

            Assert.Equal(resultadoEsperado, campeonato);
        }

        [Trait("Filme", "FilmeService Campeonato")]
        [Fact(DisplayName = "Ao executar campeonato passando uma lista vazia, deve executar com falha")]
        public void ProcessarCampeonato_PassandoUmaListaVazia_DeveRetornarMsgDeErro()
        {
            //Arrange
            var filmesMock = new List<Filme>() { };
            _filmeServiceFixture.SetupHasNotifications(true);

            //Act
            var campeonato = _filmeService.ProcessarCampeonato(filmesMock);

            //Assert
            var mensagemDeErroEsperada = "Para gerar um campeonato, é necessário ter, pelo menos, dois filmes";
            _filmeServiceFixture.Mocker.GetMock<INotificationContext<Notification>>()
                 .Verify(x => x.AddNotification(It.Is<string>(n => n.Equals(mensagemDeErroEsperada))), Times.Once);

            Assert.Equal(campeonato, new Campeonato());
        }

        [Trait("Filme", "FilmeService Campeonato")]
        [Fact(DisplayName = "Ao executar campeonato passando uma lista impar, deve executar com falha")]
        public void ProcessarCampeonato_PassandoUmaListaImpar_DeveRetornarMsgDeErro()
        {
            //Arrange
            var filmesMock = new List<Filme>()
            {
                FilmesMock.OsIncriveis2,
                FilmesMock.JurassicWorld,
                FilmesMock.OitoMulheresEUmSegredo
            };

            _filmeServiceFixture.SetupHasNotifications(true);

            //Act
            var campeonato = _filmeService.ProcessarCampeonato(filmesMock);

            //Assert
            var mensagemDeErroEsperada = "Para gerar um campeonato, é necessário ter uma quantidade par de filmes";
            _filmeServiceFixture.Mocker.GetMock<INotificationContext<Notification>>()
                 .Verify(x => x.AddNotification(It.Is<string>(n => n.Equals(mensagemDeErroEsperada))), Times.Once);

            Assert.Equal(campeonato, new Campeonato());
        }


        [Trait("Filme", "FilmeService Campeonato")]
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

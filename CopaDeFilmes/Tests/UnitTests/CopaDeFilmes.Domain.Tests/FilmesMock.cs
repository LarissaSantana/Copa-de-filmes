using CopaDeFilmes.Domain.Entities;
using System.Collections.Generic;
using static CopaDeFilmes.Domain.Entities.Filme;

namespace CopaDeFilmes.Domain.Tests
{
    public static class FilmesMock
    {
        public static Filme OsIncriveis2 = FilmeFactory.Create
            (
                id: "tt3606756",
                titulo: "Os Incríveis 2",
                ano: 2018,
                nota: 8.5f
            );

        public static Filme JurassicWorld = FilmeFactory.Create
            (
                id: "tt4881806",
                titulo: "Jurassic World: Reino Ameaçado",
                ano: 2018,
                nota: 6.7f
            );

        public static Filme OitoMulheresEUmSegredo = FilmeFactory.Create
            (
                id: "tt5164214",
                titulo: "Oito Mulheres e um Segredo",
                ano: 2018,
                nota: 6.3f
            );

        public static Filme Hereditario = FilmeFactory.Create
            (
                id: "tt7784604",
                titulo: "Hereditário",
                ano: 2018,
                nota: 7.8f
            );

        public static Filme Vingadores = FilmeFactory.Create
            (
                id: "tt4154756",
                titulo: "Vingadores: Guerra Infinita",
                ano: 2018,
                nota: 8.8f
            );

        public static Filme Deadpool2 = FilmeFactory.Create
            (
                id: "tt5463162",
                titulo: "Deadpool 2",
                ano: 2018,
                nota: 8.1f
            );

        public static Filme HanSolo = FilmeFactory.Create
            (
                id: "tt3778644",
                titulo: "Han Solo: Uma História Star Wars",
                ano: 2018,
                nota: 7.2f
            );

        public static Filme ThorRagnarok = FilmeFactory.Create
           (
               id: "tt3501632",
               titulo: "Thor: Ragnarok",
               ano: 2017,
               nota: 7.9f
           );

        public static Filme AViagemDeChihiro = FilmeFactory.Create
          (
              id: "tt3208644",
              titulo: "A viagem de Chihiro",
              ano: 2001,
              nota: 8.8f
          );

        public static List<Filme> GerarListaDeFilmesDinamicaParaCasoDeFalha(int quantidade)
        {
            var filmes = new List<Filme>();
            for (int i = 0; i < quantidade; i++)
            {
                filmes.Add(FilmeFactory.Create("1", "Titulo Teste", 2020, 10f));
            }

            return filmes;
        }
    }

}

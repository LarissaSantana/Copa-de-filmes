namespace CopaDeFilmes.Domain.Entities
{
    public class Campeonato
    {
        public Filme Campeao { get; private set; }
        public Filme ViceCampeao { get; private set; }

        public Campeonato() { }

        private Campeonato(Filme campeao, Filme viceCampeao)
        {
            Campeao = campeao;
            ViceCampeao = viceCampeao;
        }

        public static class CampeonatoFactory
        {
            public static Campeonato Create(Filme campeao, Filme viceCampeao)
            {
                return new Campeonato(campeao, viceCampeao);
            }
        }
    }
}

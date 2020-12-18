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

        public override bool Equals(object o)
        {
            if (o is Campeonato)
            {
                var campeonato = (Campeonato)o;
                return Campeao.Equals(campeonato.Campeao) &&
                       ViceCampeao.Equals(campeonato.ViceCampeao);
            }

            return false;
        }

        public static class CampeonatoFactory
        {
            public static Campeonato Create(Filme campeao, Filme viceCampeao)
            {
                return new Campeonato(campeao, viceCampeao);
            }

            public static Campeonato Create(Campeonato campeonato)
            {
                return new Campeonato(campeonato.Campeao, campeonato.ViceCampeao);
            }
        }
    }
}

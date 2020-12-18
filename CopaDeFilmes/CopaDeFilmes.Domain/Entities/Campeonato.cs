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

                var campeaoEhIgual =
                    Campeao?.Id == campeonato?.Campeao?.Id &&
                    Campeao?.Nota == campeonato?.Campeao?.Nota &&
                    Campeao?.Ano == campeonato?.Campeao?.Ano &&
                    Campeao?.Titulo == campeonato?.Campeao?.Titulo;

                var viceCampeaoEhIgual =
                    ViceCampeao?.Id == campeonato?.Campeao?.Id &&
                    ViceCampeao?.Nota == campeonato?.Campeao?.Nota &&
                    ViceCampeao?.Ano == campeonato?.Campeao?.Ano &&
                    ViceCampeao?.Titulo == campeonato?.Campeao?.Titulo;

                return campeaoEhIgual && viceCampeaoEhIgual;
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

using core.Types;
using System;

namespace GestaoBolsaSangue.Domain.Models
{
    public class Localizacao: Entity
    {
        public Localizacao(Guid id, string nome, string longitude, string latitude)
        {
            Id = id;
            Longitude = longitude;
            Latitude = latitude;
            Nome = Nome;
        }

        protected Localizacao()
        {

        }

        public string Nome { get; private set; }
        public string Longitude { get; private set; }
        public string Latitude { get; private set; }
    }
}

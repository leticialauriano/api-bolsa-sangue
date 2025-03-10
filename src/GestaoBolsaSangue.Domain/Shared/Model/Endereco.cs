using System;

namespace GestaoBolsaSangue.Domain.Shared.Model
{
    [Serializable]
    public class Endereco
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
    }
}

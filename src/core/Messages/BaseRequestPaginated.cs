using System;
using System.Runtime.Serialization;

namespace core.Messages
{
    [DataContract]
    [Serializable]
    public class BaseRequestPaginated
    {
        [DataMember(Name = "quantidadeRegistros")]
        public int QuantidadeRegistrosPagina { get; set; } = 10;

        [DataMember(Name = "pagina")]
        public int Pagina { get; set; } = 1;

        [DataMember(Name = "skip")]
        public int? Skip { get; set; }

        public int ObterSkipPaginacao()
        {
            if (Skip.HasValue)
                return Skip.Value;

            if (Pagina > 1)
                return (Pagina - 1) * QuantidadeRegistrosPagina;

            return default(int);
        }
    }
}
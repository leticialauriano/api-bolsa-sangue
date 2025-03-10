using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace core.Messages
{
    [DataContract]
    [Serializable]
    public class BaseResponsePaginated<T> : BaseResponse<T>
    {
        [DataMember(Name = "pagina")]
        public int Pagina { get; set; }

        [DataMember(Name = "totalPaginas")]
        public int TotalPaginas { get; set; }

        [DataMember(Name = "quantidadeRegistrosPagina")]
        public int QuantidadeRegistrosPagina { get; set; }

        [DataMember(Name = "totalRegistros")]
        public int TotalRegistros { get; set; }
    }
}
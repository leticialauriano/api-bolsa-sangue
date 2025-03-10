using core.Messages;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace core.Types
{
    [DataContract]
    public class PaginatedList<T> : List<T>
    {
        public PaginatedList() { }
        public PaginatedList(List<T> lista, int totalRegistros, int totalRegistrosFiltrados, int pagina, int quantidadeRegistrosPagina)
        {
            QuantidadeRegistrosPagina = quantidadeRegistrosPagina;
            Pagina = pagina;
            TotalPaginas = (int)Math.Ceiling(totalRegistros / (double)QuantidadeRegistrosPagina);
            TotalRegistros = totalRegistros;

            this.AddRange(lista);
        }

        public static PaginatedList<T> Create(List<T> listaFiltrada, int totalRegistros, int totalRegistrosFiltrados, BaseRequestPaginated filtroRequest)
        {
            return new PaginatedList<T>(listaFiltrada, totalRegistros, totalRegistrosFiltrados, filtroRequest.Pagina, filtroRequest.QuantidadeRegistrosPagina);
        }

        public int QuantidadeRegistrosPagina { get; private set; }
        public int Pagina { get; private set; }
        public int TotalPaginas { get; private set; }
        public int TotalRegistros { get; private set; }
    }
}
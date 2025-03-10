using GestaoBolsaSangue.Application.DTOs.TipoBolsaSangue;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoBolsaSangue.Application.Interfaces
{
    public interface ITipoBolsaSangueService
    {
        Task<IList<TipoBolsaSangueDTO>> Listar();
        Task<TipoBolsaSangueDTO> Obter(Guid id);
    }
}

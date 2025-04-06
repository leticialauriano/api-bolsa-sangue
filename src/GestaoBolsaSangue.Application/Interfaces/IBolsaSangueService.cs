using FluentValidation.Results;
using GestaoBolsaSangue.Application.DTOs.Alterar;
using GestaoBolsaSangue.Application.DTOs.Salvar;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Listar = GestaoBolsaSangue.Application.DTOs.Listar;

namespace GestaoBolsaSangue.Application.Interfaces
{
    public interface IBolsaSangueService : IDisposable
    {
        Task<IList<Listar.ListarBolsaSangueDTO>> Listar();
        Task<ValidationResult> Alterar(AlterarBolsaSangueDTO request);
        Task<ValidationResult> Salvar(SalvarBolsaSangueDTO request);
    }
}

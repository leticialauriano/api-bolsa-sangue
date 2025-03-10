using core.Messages;
using GestaoBolsaSangue.Domain.Shared.Model;
using System;
using System.Threading.Tasks;

namespace GestaoBolsaSangue.Domain.Interfaces
{
    public interface IProprietarioRepository
    {
        Task<Proprietario> GetById(Guid id);
    }
}

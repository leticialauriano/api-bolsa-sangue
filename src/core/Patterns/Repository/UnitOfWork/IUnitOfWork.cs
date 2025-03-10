using System;
using System.Threading.Tasks;

namespace core.Repository.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
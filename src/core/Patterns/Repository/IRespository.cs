using core.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace core.Repository
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        IUnitOfWork UnitOfWork { get; }
        void Add(TEntity obj);
        Task<TEntity> GetById(Guid id);
        Task<IEnumerable<TEntity>> GetAll();
        void Update(TEntity obj);
        void Remove(Guid id);        
    }
}
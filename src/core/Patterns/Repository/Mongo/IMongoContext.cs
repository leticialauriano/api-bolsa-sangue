using System.Threading.Tasks;
using System;
using core.Repository.UnitOfWork;

namespace core.Repository.Mongo
{
    public interface IMongoContext : IDisposable, IUnitOfWork
    {
        void AddCommand(Func<Task> func);
        Task<int> SaveChanges();
        MongoDB.Driver.IMongoCollection<T> GetCollection<T>(string name);
    }
}
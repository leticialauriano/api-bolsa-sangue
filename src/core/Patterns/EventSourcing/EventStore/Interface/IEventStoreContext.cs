using System;
using System.Threading.Tasks;

namespace core.Patterns.EventSourcing.EventStore.Repository
{
    public interface IEventStoreContext : IDisposable
    {
        void AddCommand(Func<Task> func);
        Task<int> SaveChanges();
        MongoDB.Driver.IMongoCollection<T> GetCollection<T>(string name);
    }
}
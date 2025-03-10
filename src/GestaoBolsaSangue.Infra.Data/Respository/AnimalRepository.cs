using core.Repository;
using core.Repository.Mongo;
using core.Repository.UnitOfWork;
using GestaoBolsaSangue.Domain.Interfaces;

namespace GestaoBolsaSangue.Infra.Data.Respository
{
    public class AnimalRepository : BaseRepository<Domain.Models.Animal>, IAnimalRepository
    {
        protected readonly IMongoContext Db;
        public AnimalRepository(IMongoContext context) : base(context)
        {
            Db = context;
        }

        public override IUnitOfWork UnitOfWork => Db;
    }
}
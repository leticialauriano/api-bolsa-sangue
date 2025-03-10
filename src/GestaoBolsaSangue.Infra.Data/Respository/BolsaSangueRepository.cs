using core.Repository;
using core.Repository.Mongo;
using core.Repository.UnitOfWork;
using GestaoBolsaSangue.Domain.Interfaces;

namespace GestaoBolsaSangue.Infra.Data.Respository
{
    public class BolsaSangueRepository : BaseRepository<Domain.Models.BolsaSangue>, IBolsaSangueRepository
    {
        protected readonly IMongoContext Db;
        public BolsaSangueRepository(IMongoContext context) : base(context)
        {
            Db = context;
        }

        public override IUnitOfWork UnitOfWork => Db;
    }
}
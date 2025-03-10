using core.Repository;
using core.Repository.Mongo;
using core.Repository.UnitOfWork;
using GestaoBolsaSangue.Domain.Interfaces;

namespace GestaoBolsaSangue.Infra.Data.Respository
{
    public class TipoBolsaSangueRepository : BaseRepository<Domain.Models.TipoBolsaSangue>, ITipoBolsaSangueRepository
    {
        protected readonly IMongoContext Db;
        public TipoBolsaSangueRepository(IMongoContext context) : base(context)
        {
            Db = context;
        }

        public override IUnitOfWork UnitOfWork => Db;
    }
}
using NetCoders.Madrugada.DataAccess.Context;
using NetCoders.Madrugada.Domain.Entities;
using NetCoders.Madrugada.Domain.Repositories;

namespace NetCoders.Madrugada.DataAccess.Repositories
{
    public sealed class FicanteRepository : RepositoryBase<Ficante>, IFicanteRepository
    {
        public FicanteRepository(SisTinderContext context_)
            : base(context_)
        {

        }
    }
}

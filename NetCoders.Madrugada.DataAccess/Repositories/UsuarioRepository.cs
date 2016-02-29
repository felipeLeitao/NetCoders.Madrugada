using NetCoders.Madrugada.DataAccess.Context;
using NetCoders.Madrugada.Domain.Entities;
using NetCoders.Madrugada.Domain.Repositories;

namespace NetCoders.Madrugada.DataAccess.Repositories
{
    public sealed class UsuarioRepository : RepositoryBase<Usuario> , IUsuarioRepository
    {
        public UsuarioRepository(SisTinderContext context_)
            : base(context_)
        {

        }
    }
}

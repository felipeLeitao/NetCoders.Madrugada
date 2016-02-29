using NetCoders.Madrugada.Domain.Entities;
using NetCoders.Madrugada.Domain.Repositories;
using NetCoders.Madrugada.Service.Interface;

namespace NetCoders.Madrugada.Service
{
    public class UsuarioService : ServiceBase<Usuario>, IUsuarioService
    {
                private readonly IUsuarioRepository _usuarioRepository;

                public UsuarioService(IUsuarioRepository usuarioRepository_)
            : base(usuarioRepository_)
        {
            _usuarioRepository = usuarioRepository_;
        }
    }
}

using NetCoders.Madrugada.Domain.Entities;
using NetCoders.Madrugada.Domain.Repositories;
using NetCoders.Madrugada.Service.Interface;

namespace NetCoders.Madrugada.Service
{
    public sealed class TelefoneService : ServiceBase<Telefone>, ITelefoneService
    {
        private readonly ITelefoneRepository _telefoneRepository;

        public TelefoneService(ITelefoneRepository telefoneRepository_)
            : base(telefoneRepository_)
        {
            _telefoneRepository = telefoneRepository_;
        }
    }
}

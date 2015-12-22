using NetCoders.Madrugada.DataAccess.Repositories;
using NetCoders.Madrugada.Domain.Entities;
using NetCoders.Madrugada.Domain.Repositories;
using NetCoders.Madrugada.Service.Interface;

namespace NetCoders.Madrugada.Service
{
    public class FicanteService : ServiceBase<Ficante> , IFicanteService
    {
        private readonly IFicanteRepository _ficanteRepository;
        public FicanteService(IFicanteRepository ficanteRepository_)
            : base(ficanteRepository_)
        {
            _ficanteRepository = ficanteRepository_;
        }
    }
}

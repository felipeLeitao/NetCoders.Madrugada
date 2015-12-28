using NetCoders.Madrugada.DataAccess.Repositories;
using NetCoders.Madrugada.Domain.Entities;
using NetCoders.Madrugada.Domain.Repositories;
using NetCoders.Madrugada.Service.Interface;

namespace NetCoders.Madrugada.Service
{
    public class FicanteService : ServiceBase<Ficante> , IFicanteService
    {
        private readonly IFicanteRepository _ficanteRepository;
        private readonly ITelefoneRepository _telefoneRepository;


        public FicanteService(IFicanteRepository ficanteRepository_, ITelefoneRepository telefoneRepository_)
            : base(ficanteRepository_)
        {
            _ficanteRepository = ficanteRepository_;
            _telefoneRepository = telefoneRepository_;
        }


        public override void Create(Ficante obj)
        {
            base.Begin();

            _ficanteRepository.Create(obj);

            base.SaveChanges();
        }

        public override void Remove(Ficante obj)
        {
            base.Begin();

            _ficanteRepository.Remove(obj);

            _telefoneRepository.RemoveRange(obj.Telefones);

            base.SaveChanges();

        }
    }
}

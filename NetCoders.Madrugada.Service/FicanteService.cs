using NetCoders.Madrugada.DataAccess.Repositories;
using NetCoders.Madrugada.Domain.Entities;
using NetCoders.Madrugada.Domain.Repositories;
using NetCoders.Madrugada.Service.Interface;
using System.Linq;

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

        public override void Update(Ficante obj)
        {
            base.Begin();

            foreach (var item in obj.Telefones.Where(x => x.idFicante != 0))
            {
                _telefoneRepository.Update(item);
            }

            foreach (var item in obj.Telefones.Where(x => x.idFicante == 0))
            {
                item.idFicante = obj.Codigo;
                _telefoneRepository.Create(item);
            }

            _ficanteRepository.Update(obj);

            base.SaveChanges();
        }
    }
}

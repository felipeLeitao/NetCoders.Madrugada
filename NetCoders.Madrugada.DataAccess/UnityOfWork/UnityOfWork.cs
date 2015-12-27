using Microsoft.Practices.ServiceLocation;
using NetCoders.Madrugada.DataAccess.Context;
using NetCoders.Madrugada.Domain.Contracts.UnityOfWork;

namespace NetCoders.Madrugada.DataAccess.UnityOfWork
{
    public class UnityOfWork : IUnityOfWork
    {
        private SisTinderContext _context;

        public UnityOfWork(SisTinderContext context_)
        {
            _context = context_;
        }

        public void Begin()
        {
            _context = ServiceLocator.Current.GetInstance<SisTinderContext>();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}

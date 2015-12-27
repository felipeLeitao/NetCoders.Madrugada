using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoders.Madrugada.Domain.Contracts.UnityOfWork
{
    public interface IUnityOfWork
    {
        void Begin();

        void SaveChanges();
    }
}

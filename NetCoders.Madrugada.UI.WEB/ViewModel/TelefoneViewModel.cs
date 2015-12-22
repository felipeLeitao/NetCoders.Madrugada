using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoders.Madrugada.UI.WEB.ViewModel
{
    public class TelefoneViewModel
    {
        public int idTelefone { get; set; }
        public int idFicante { get; set; }
        public int nrTelefone { get; set; }
        public virtual FicanteViewModel Ficante { get; set; }
    }
}

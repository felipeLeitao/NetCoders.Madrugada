using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoders.Madrugada.UI.WEB.ViewModel
{
    public class FicanteViewModel
    {

        public FicanteViewModel()
        {
            this.TelefonesViewModel = new List<TelefoneViewModel>();
        }

        public int idFicante { get; set; }

        [Required]
        public string nmFicante { get; set; }

        public string dsObs { get; set; }

        public virtual ICollection<TelefoneViewModel> TelefonesViewModel { get; set; }
    }
}

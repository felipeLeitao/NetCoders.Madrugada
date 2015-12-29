using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoders.Madrugada.UI.WEB.ViewModel
{
    public class FicanteViewModel : Core.ViewModel
    {

        public FicanteViewModel()
        {
            this.TelefonesViewModel = new List<TelefoneViewModel>();
        }

        [Required]
        [Display(Name = "Ficante")]
        public string nmFicante { get; set; }

        [Display(Name = "Obs")]
        public string dsObs { get; set; }

        public virtual ICollection<TelefoneViewModel> TelefonesViewModel { get; set; }
    }
}

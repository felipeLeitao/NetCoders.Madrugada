using System;
using System.Collections.Generic;

namespace NetCoders.Madrugada.Domain.Entities
{
    public class Ficante : Core.Entity
    {
        public Ficante()
        {
            this.Telefones = new List<Telefone>();
        }

        public string nmFicante { get; set; }
        public string dsObs { get; set; }
        public virtual ICollection<Telefone> Telefones { get; set; }
    }
}

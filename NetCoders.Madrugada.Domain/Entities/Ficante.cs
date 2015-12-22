using System;
using System.Collections.Generic;

namespace NetCoders.Madrugada.Domain.Entities
{
    public class Ficante
    {
        public Ficante()
        {
            this.Telefones = new List<Telefone>();
        }

        public int idFicante { get; set; }
        public string nmFicante { get; set; }
        public string dsObs { get; set; }
        public virtual ICollection<Telefone> Telefones { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace NetCoders.Madrugada.Domain.Entities
{
    public class Telefone
    {
        public int idTelefone { get; set; }
        public int idFicante { get; set; }
        public int nrTelefone { get; set; }
        public virtual Ficante Ficante { get; set; }
    }
}

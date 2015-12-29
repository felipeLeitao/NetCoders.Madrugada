namespace NetCoders.Madrugada.Domain.Entities
{
    public class Telefone : Core.Entity
    {
        public int idFicante { get; set; }
        public int nrTelefone { get; set; }
        public virtual Ficante Ficante { get; set; }
    }
}

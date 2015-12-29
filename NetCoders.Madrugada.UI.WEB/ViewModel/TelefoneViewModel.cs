namespace NetCoders.Madrugada.UI.WEB.ViewModel
{
    public class TelefoneViewModel : Core.ViewModel
    {
        public int idFicante { get; set; }
        public int nrTelefone { get; set; }
        public virtual FicanteViewModel Ficante { get; set; }
    }
}

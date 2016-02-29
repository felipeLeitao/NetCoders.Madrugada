using System.ComponentModel.DataAnnotations;

namespace NetCoders.Madrugada.UI.WEB.ViewModel
{
    public sealed class UsuarioViewModel
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        public string Senha { get; set; }

        public string ConfirmaSenha { get; set; }
    }
}
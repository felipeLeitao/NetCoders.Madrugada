namespace NetCoders.Madrugada.Domain.Entities
{
    public sealed class Usuario : Core.Entity
    {
        public string Nome { get; set; }

        public string Senha { get; set; }

        public string Role { get; set; }
    }
}

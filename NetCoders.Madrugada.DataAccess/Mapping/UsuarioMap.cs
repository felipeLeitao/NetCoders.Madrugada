using NetCoders.Madrugada.Domain.Entities;

namespace NetCoders.Madrugada.DataAccess.Mapping
{
    public sealed class UsuarioMap : Core.BaseMap<Usuario>
    {
        public UsuarioMap()
        {
            // Properties
            this.Property(t => t.Nome)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Senha)
                .IsRequired()
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("Usuario");
            this.Property(t => t.Codigo).HasColumnName("idUsuario");
            this.Property(t => t.Nome).HasColumnName("nmUsuario");
            this.Property(t => t.Senha).HasColumnName("dsSenha");
            this.Property(t => t.Role).HasColumnName("dsRole");
        }
    }
}

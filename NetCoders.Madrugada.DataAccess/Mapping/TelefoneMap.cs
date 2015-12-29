using NetCoders.Madrugada.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace NetCoders.Madrugada.DataAccess.Mapping
{
    public class TelefoneMap : EntityTypeConfiguration<Telefone>
    {
        public TelefoneMap()
        {
            // Primary Key
            this.HasKey(t => t.Codigo);

            // Properties
            // Table & Column Mappings
            this.ToTable("Telefone");
            this.Property(t => t.Codigo).HasColumnName("idTelefone");
            this.Property(t => t.idFicante).HasColumnName("idFicante");
            this.Property(t => t.nrTelefone).HasColumnName("nrTelefone");

            // Relationships
            this.HasRequired(t => t.Ficante)
                .WithMany(t => t.Telefones)
                .HasForeignKey(d => d.idFicante);

        }
    }
}

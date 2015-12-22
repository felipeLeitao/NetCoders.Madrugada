using NetCoders.Madrugada.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace NetCoders.Madrugada.DataAccess.Mapping
{
    public class FicanteMap : EntityTypeConfiguration<Ficante>
    {
        public FicanteMap()
        {
            // Primary Key
            this.HasKey(t => t.idFicante);

            // Properties
            this.Property(t => t.nmFicante)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.dsObs)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("Ficante");
            this.Property(t => t.idFicante).HasColumnName("idFicante");
            this.Property(t => t.nmFicante).HasColumnName("nmFicante");
            this.Property(t => t.dsObs).HasColumnName("dsObs");
        }
    }
}

using NetCoders.Madrugada.Domain.Entities.Core;
using System.Data.Entity.ModelConfiguration;

namespace NetCoders.Madrugada.DataAccess.Mapping.Core
{
    public abstract class BaseMap<T> : EntityTypeConfiguration<T> where T : Entity
    {
        public BaseMap()
        {
            // Primary Key
            this.HasKey(t => t.Codigo);
        }
    }
}

using System.Data.Entity;
using NetCoders.Madrugada.Domain.Entities;
using NetCoders.Madrugada.DataAccess.Mapping;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace NetCoders.Madrugada.DataAccess.Context
{
    public partial class SisTinderContext : DbContext
    {
        static SisTinderContext()
        {
            Database.SetInitializer<SisTinderContext>(null);
        }

        public SisTinderContext()
            : base("Name=SisTinderContext")
        {

        }

        public DbSet<Ficante> Ficantes { get; set; }
        public DbSet<Telefone> Telefones { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new FicanteMap());
            modelBuilder.Configurations.Add(new TelefoneMap());
            modelBuilder.Configurations.Add(new UsuarioMap());
        }

        public class SisTinderContextCustomInitializer : IDatabaseInitializer<SisTinderContext>
        {
            public void InitializeDatabase(SisTinderContext context)
            {
                //verifica se o banco existe
                if (!context.Database.Exists())
                {
                    context.Database.Create();
                }
            }

        }
    }
}

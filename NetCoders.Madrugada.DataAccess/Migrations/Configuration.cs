namespace NetCoders.Madrugada.DataAccess.Migrations
{
    using NetCoders.Madrugada.Domain.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<NetCoders.Madrugada.DataAccess.Context.SisTinderContext>
    {
        //Tomar cuidado com o Enable-Migrations, ele refaz esse arquivo. Imagina se eu montar um seed monstrão e depois ele apagar
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(NetCoders.Madrugada.DataAccess.Context.SisTinderContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Usuarios.AddOrUpdate(
              new Usuario { Nome = "Andrew Peters", Role = "Admin", Senha = "123456" }
            );
            
        }
    }
}

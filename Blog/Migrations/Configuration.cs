namespace Blog.Migrations
{
    using Blog.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Blog.Infra.BlogContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Blog.Infra.BlogContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            Usuario adm = new Usuario { Id = 1, Nome = "admin", Email = "adm@caelum.com", Senha = "1234" };
            context.Usuarios.AddOrUpdate(adm);
        }
    }
}

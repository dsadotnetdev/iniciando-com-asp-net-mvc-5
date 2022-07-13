using AppMvc.Models;
using System.Data.Entity.Migrations;

namespace AppMvc.Migrations
{

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(AppMvc.Models.ApplicationDbContext context)
        {

        }
    }
}

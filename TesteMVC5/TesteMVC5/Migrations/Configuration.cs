using System.Data.Entity.Migrations;
using TesteMVC5.Data;

namespace TesteMVC5.Migrations
{

    internal sealed class Configuration : DbMigrationsConfiguration<AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(TesteMVC5.Data.AppDbContext context)
        {

        }
    }
}

using ip2DonemOdev.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ip2DonemOdev.DAL.Context
{
    public class MyContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-LGO92CF; initial Catalog=MySenegalDB; integrated Security=true;TrustServerCertificate=True;");
        }

        public DbSet<City> Cities{ get; set; }
        public DbSet<Country> Countries{ get; set; }
        public DbSet<Place> Places{ get; set; }
        public DbSet<Population> Populations{ get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<User> Users { get; set; }
    }
}



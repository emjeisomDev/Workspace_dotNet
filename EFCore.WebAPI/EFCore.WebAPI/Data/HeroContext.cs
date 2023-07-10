using EFCore.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCore.WebAPI.Data
{
    public class HeroContext : DbContext
    {
        public DbSet<Hero> Heros { get; set; }
        public DbSet<Battle> Battles { get; set; }
        public DbSet<Weapon> Weapons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(@"Server=DESKTOP-MN8G6NB\\SQLEXPRESS,1433;
                                        Database=HeroApp;
                                        User Id=sa;
                                        Password=1q2w3e4r@#$;
                                        Encrypt=false;
                                        TrustServerCertificate=True;
                                        MultiSubnetFailover=True;");
    }
}

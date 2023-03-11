using Microsoft.EntityFrameworkCore;
using todo.Models;

namespace todo.Data
{
    public class DataContext : DbContext
    {

        public DbSet<TodoModel> Todos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(@"Server=localhost,1433;
                                    Database=todo;
                                    User ID=sa;
                                    Password=1q2w3e4r@#$;
                                    Encrypt=false;
                                    TrustServerCertificate=True;
                                    MultiSubnetFailover=True;");

    }
}

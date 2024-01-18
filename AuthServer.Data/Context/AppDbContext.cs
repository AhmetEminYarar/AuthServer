using AuthServer.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace AuthServer.Data.Context
{
    public class AppDbContext : DbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AuthServer;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"); }
        public AppDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Person> people { get; set; }

    }
}

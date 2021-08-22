using Microsoft.EntityFrameworkCore;

namespace PlanAPI.Models
{
    public class PlanContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Server=PlanServer;Host=localhost;Port=5433;Database=PlanDB;Username=planuser;Password=user123");
        
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
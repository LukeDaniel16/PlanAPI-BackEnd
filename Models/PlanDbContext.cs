using Microsoft.EntityFrameworkCore;

namespace PlanAPI.Models
{
    public class PlanDbContext : DbContext
    {
        public PlanDbContext(DbContextOptions<PlanDbContext> options) : base(options){}
        
        public DbSet<Usuario> Usuarios { get; set; }
        
        public DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .HasAlternateKey(c => c.Email);
            
            modelBuilder.Entity<Usuario>()
                .Property(b => b.DataCriacaoConta)
                .HasDefaultValueSql("CURRENT_DATE");
        }
    }
}
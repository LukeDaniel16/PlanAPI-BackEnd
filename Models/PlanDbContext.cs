using System;
using Microsoft.EntityFrameworkCore;
using PlanAPI.Models.Enumeradores;

namespace PlanAPI.Models
{
    public class PlanDbContext : DbContext
    {
        public PlanDbContext(DbContextOptions<PlanDbContext> options) : base(options){}
        
        public DbSet<Usuario> Usuarios { get; set; }
        
        public DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>()
                .HasOne(t => t.UsuarioOrigem)
                .WithMany(u => u.TasksCriadas);
            
            modelBuilder.Entity<Task>()
                .HasOne(t => t.UsuarioAssociado)
                .WithMany(u => u.TasksAssociadas);

            modelBuilder.Entity<Task>()
                .Property(task => task.Status)
                .HasConversion(status => status.ToString(),
                    status => (EStatusTask)Enum.Parse(typeof(EStatusTask), status));
            
            modelBuilder.Entity<Task>()
                .Property(task => task.Status)
                .HasDefaultValue(EStatusTask.Pendente);
        }
    }
}
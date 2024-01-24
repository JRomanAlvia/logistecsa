using Logistecsa.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Logistecsa.Infrastructure
{
    public class LogistecsaDbContext : DbContext
    {
        public LogistecsaDbContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Tarea> Tareas { get; set; }
        public DbSet<Project> Projects { get; set; }
    }
}

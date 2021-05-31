using System.Data.Entity;

namespace ItViteaTaskPlanner.Data.Services.Infrastructure.Sql
{
    public class TaskPlannerDbContext : DbContext
    {
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Task> Tasks { get; set; }
    }
}

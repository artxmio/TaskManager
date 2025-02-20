using Microsoft.EntityFrameworkCore;
using TaskManager.Model.TaskModel;
using TaskManager.Model.ProjectModel;
using TaskManager.Model.UserModel;

namespace TaskManager.ViewModel.ApplicationContext
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Project> Projects { get; set; } = null!;
        public DbSet<Model.TaskModel.Task> Tasks { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var sourcePathDB = "D:\\C#\\TaskManager\\database.db";
            optionsBuilder.UseSqlite($"Data Source={sourcePathDB}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Model.TaskModel.Task>()
                 .HasOne(t => t.Project)
                 .WithMany(p => p.Tasks)
                 .HasForeignKey(t => t.ProjectId)
                 .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Model.TaskModel.Task>()
                .HasOne(t => t.User)
                .WithMany(u => u.Tasks)
                .HasForeignKey(t => t.UserId);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using TaskManager.Model.ProjectModel;

namespace TaskManager.ViewModel.ApplicationContext;

public class ApplicationContext : DbContext
{
    public DbSet<Project> Projects { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var sourcePathDB = "D:\\C#\\TaskManager\\database.db"; 

        optionsBuilder.UseSqlite($"Data Source={sourcePathDB}");
    }
}

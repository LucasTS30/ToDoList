using Microsoft.EntityFrameworkCore;
using ToDoList.EntityConfigs;
using ToDoList.Models;

namespace ToDoList.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<ToDo> ToDos => Set<ToDo>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=Localhost;Database=ToDoList;Trusted_Connection=True;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ToDoEntityConfig());
    }

}
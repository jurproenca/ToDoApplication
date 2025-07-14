using Microsoft.EntityFrameworkCore;

namespace TodoApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<ToDoTask> Tasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ToDoTask>()
            .Property(t => t.Status)
            .HasConversion(
                v => ((int)v).ToString(),
                v => (int)(StatusTarefa)int.Parse(v)
            )
            .HasColumnType("varchar(1)");

        modelBuilder.Entity<ToDoTask>()
            .Property(t => t.DataVencimento)
            .IsRequired();
    }
}
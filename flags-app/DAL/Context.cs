using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DAL;

public class Context : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var dbPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Yourfile.txt");

        optionsBuilder.UseSqlite("");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}

using DAL.Models;
using DAL.Models.Flags;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DAL;

public class Context : DbContext
{
    public DbSet<PlainFlag> PlainFlags { get; set; } = null!;
    public DbSet<StripedFlag> StripedFlags { get; set; } = null!;
    public DbSet<CatalogItem> Catalogs { get; set; } = null!;
    public DbSet<Country> Countries { get; set; } = null!;
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var dbPath = "C:\\Users\\i.truhin\\Documents\\C# projects\\flags-app\\DAL\\db\\db.sql";
        optionsBuilder.UseSqlite(dbPath);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
    public async Task<int> CreateEntityAsync<T>(T entity) where T : BaseEntity
    {
        var dbSet = Set<T>();
        dbSet.Add(entity);
        await SaveChangesAsync();
        return entity.Id;
    }
    public async Task<int> UpdateEntityAsync<T>(T entity) where T : BaseEntity
    {
        var dbSet = Set<T>();
        dbSet.Update(entity);        
        return await SaveChangesAsync();
    }
    public async Task<List<T>> GetRangeAsync<T>(bool asNoTracking = true) where T : BaseEntity
    {
        var dbSet = Set<T>().AsQueryable();
        if (asNoTracking) dbSet = dbSet.AsNoTracking();
        return await dbSet.ToListAsync();
    }
    public async Task<List<T>> GetRangeAsync<T>(Expression<Func<T, bool>> predicate, bool asNoTracking = true) where T : BaseEntity
    {
        var dbSet = Set<T>().Where(predicate);
        if (asNoTracking) dbSet = dbSet.AsNoTracking();
        return await dbSet.ToListAsync();
    }
    public async Task<int> DeleteEntityAsync<T>(int id) where T : BaseEntity, new()
    {
        var dbSet = Set<T>();
        dbSet.Remove(new T { Id = id });
        return await SaveChangesAsync();
    }
}

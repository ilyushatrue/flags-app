using DAL.Models;
using DAL.Models.Base;
using DAL.Models.Flags;
using DAL.Models.Flags.Attributes;
using DAL.RelationConfig;
using DAL.Relations.Flags;
using DAL.Relations.Flags.Attributes;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DAL;

internal class Context : DbContext
{
    internal static Context? _context = null;
    public Context()
    {
        _context?.Database.EnsureDeleted();
        _context?.Database.EnsureCreated();
    }
    public static Context Initialize()
    {
        _context ??= new Context();
        return _context;
    }

    public DbSet<Flag> Flags { get; set; } = null!;
    public DbSet<PlainFlag> PlainFlags { get; set; } = null!;
    public DbSet<StripedFlag> StripedFlags { get; set; } = null!;
    public DbSet<FlagArea> FlagAreas { get; set; } = null!;
    public DbSet<FlagPattern> FlagPatterns { get; set; } = null!;
    public DbSet<CatalogItem> Catalog { get; set; } = null!;
    public DbSet<Country> Countries { get; set; } = null!;


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var dbPath = "C:\\Users\\i.truhin\\Documents\\C# projects\\flags-app\\DAL\\db\\db.sql";
        optionsBuilder.UseSqlite($"Data Source={dbPath}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new FlagConfiguration());
        modelBuilder.ApplyConfiguration(new FlagAreaConfiguration());
        modelBuilder.ApplyConfiguration(new FlagPatternConfiguration());
        modelBuilder.ApplyConfiguration(new CountryConfiguration());
    }


    public async Task<int> CreateEntityAsync<T>(T entity) where T : class, IBaseEntity
    {
        var dbSet = Set<T>();
        dbSet.Add(entity);
        await SaveChangesAsync();
        return entity.Id;
    }

    public async Task<int> UpdateEntityAsync<T>(T entity) where T : class, IBaseEntity
    {
        var dbSet = Set<T>();
        dbSet.Update(entity);
        return await SaveChangesAsync();
    }

    public async Task<List<T>> GetRangeAsync<T>(bool asNoTracking = true) where T : class, IBaseEntity
    {
        var dbSet = Set<T>().AsQueryable();
        if (asNoTracking) dbSet = dbSet.AsNoTracking();
        return await dbSet.ToListAsync();
    }

    public async Task<List<T>> GetRangeAsync<T>(Expression<Func<T, bool>> predicate, bool asNoTracking = true) where T : class, IBaseEntity
    {
        var dbSet = Set<T>().Where(predicate);
        if (asNoTracking) dbSet = dbSet.AsNoTracking();
        return await dbSet.ToListAsync();
    }

    public async Task<int> DeleteEntityAsync<T>(int id) where T : class, IBaseEntity, new()
    {
        var dbSet = Set<T>();
        dbSet.Remove(new T { Id = id });
        return await SaveChangesAsync();
    }
}

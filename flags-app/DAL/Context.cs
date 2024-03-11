using DAL.Models;
using DAL.Models.Base;
using DAL.Models.Flags;
using DAL.Models.Flags.Attributes;
using DAL.RelationConfig;
using DAL.Relations.Flags;
using DAL.Relations.Flags.Attributes;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;

namespace DAL;

internal class Context : DbContext
{
    private static Context? _context = null;
    internal Context()
    {
        _context = this;
    }
    internal static Context Initialize()
    {
        _context ??= new Context();
        return _context;
    }

    internal DbSet<Flag> Flags { get; set; } = null!;
    internal DbSet<PlainFlag> PlainFlags { get; set; } = null!;
    internal DbSet<StripedFlag> StripedFlags { get; set; } = null!;
    internal DbSet<FlagArea> FlagAreas { get; set; } = null!;
    internal DbSet<FlagPattern> FlagPatterns { get; set; } = null!;
    internal DbSet<CatalogItem> Catalog { get; set; } = null!;
    internal DbSet<Country> Countries { get; set; } = null!;


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var dbPath = Directory.GetCurrentDirectory()+ "\\db\\db.sql";
        optionsBuilder.UseSqlite($"Data Source={dbPath}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new FlagConfiguration());
        modelBuilder.ApplyConfiguration(new FlagAreaConfiguration());
        modelBuilder.ApplyConfiguration(new FlagPatternConfiguration());
        modelBuilder.ApplyConfiguration(new CountryConfiguration());
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity"></param>
    /// <returns>Inserted entity Id</returns>
    internal async Task<int> InsertEntityAsync<T>(T entity) where T : class, IBaseEntity
    {
        var dbSet = Set<T>();
        dbSet.Add(entity);
        await SaveChangesAsync();
        return entity.Id;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity"></param>
    /// <returns>Number of affected rows</returns>
    internal async Task<int> UpdateEntityAsync<T>(T entity) where T : class, IBaseEntity
    {
        var dbSet = Set<T>();
        dbSet.Update(entity);
        return await SaveChangesAsync();
    }

    internal async Task<List<T>> GetRangeAsync<T>(bool asNoTracking = true) where T : class, IBaseEntity
    {
        var dbSet = Set<T>().AsQueryable();
        if (asNoTracking) dbSet = dbSet.AsNoTracking();
        return await dbSet.ToListAsync();
    }

    internal async Task<List<T>> GetRangeAsync<T>(Expression<Func<T, bool>> predicate, bool asNoTracking = true) where T : class, IBaseEntity
    {
        var dbSet = Set<T>().Where(predicate);
        if (asNoTracking) dbSet = dbSet.AsNoTracking();
        return await dbSet.ToListAsync();
    }

    internal async Task<T?> GetEntityAsync<T>(Expression<Func<T, bool>> predicate, bool asNoTracking = true) where T : class, IBaseEntity
    {
        var dbSet = Set<T>();
        T? dbSetItem;
        if (asNoTracking)
            dbSetItem = await dbSet.AsNoTracking().FirstOrDefaultAsync(predicate);
        else
            dbSetItem = await dbSet.FirstOrDefaultAsync(predicate);

        return dbSetItem;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="id"></param>
    /// <returns>Number of affected rows</returns>
    internal async Task<int> DeleteEntityAsync<T>(int id) where T : class, IBaseEntity, new()
    {
        var dbSet = Set<T>();
        dbSet.Remove(new T { Id = id });
        return await SaveChangesAsync();
    }
}

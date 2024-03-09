using DAL.Models.Flags;
using DAL.Repositories.Base;

namespace DAL.Repositories;

public class FlagRepository : BaseRepository
{
    public async Task<IEnumerable<Flag>> GetAllFlagsAsync()
    {
        IEnumerable<Flag> plainFlags = await Context.GetRangeAsync<PlainFlag>();
        IEnumerable<Flag> stripedFlags = await Context.GetRangeAsync<StripedFlag>();
        var allFlags = plainFlags.Concat(stripedFlags);
        return allFlags;
    }
    public async Task<IEnumerable<Flag>> GetAllFlagsAsync<T>() where T : Flag
    {
        var flags = await Context.GetRangeAsync<T>();
        return flags;
    }
}

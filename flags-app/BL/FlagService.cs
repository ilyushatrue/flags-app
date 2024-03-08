using DAL;
using DAL.Models.Flags;

namespace BL;

public class FlagService
{
    public async Task<IEnumerable<Flag>> GetAllFlags()
    {
        using var db = new Context();
        IEnumerable<Flag> plainFlags = await db.GetRangeAsync<PlainFlag>();
        IEnumerable<Flag> stripedFlags = await db.GetRangeAsync<StripedFlag>();
        var allFlags = plainFlags.Concat(stripedFlags);
        return allFlags;
    }
}

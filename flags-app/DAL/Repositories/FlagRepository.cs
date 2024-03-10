using DAL.DTOs.Flags;
using DAL.Models.Flags;
using DAL.Repositories.Base;

namespace DAL.Repositories;

public class FlagRepository : BaseRepository
{
    public async Task<IEnumerable<FlagDto>> GetAllFlagsAsync()
    {
        IEnumerable<Flag> plainFlags = await Context.GetRangeAsync<PlainFlag>();
        IEnumerable<Flag> stripedFlags = await Context.GetRangeAsync<StripedFlag>();
        var allFlags = plainFlags.Concat(stripedFlags);
        var dtos = Mapper.Map<IEnumerable<FlagDto>>(allFlags);
        return dtos;
    }

    public async Task<int> CreateFlagAsync(FlagDto dto)
    {
        var entity = Mapper.Map<Flag>(dto);
        return await Context.InsertEntityAsync(entity);
    }
}

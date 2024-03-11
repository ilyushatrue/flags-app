using DAL.Models.Flags.Attributes;
using DAL.DTOs.Flags.Attributes;
using DAL.Repositories.Base;

namespace DAL.Repositories;

public class FlagPatternRepository : BaseRepository
{
    public async Task<int> CreatePattern(FlagPatternCreateDto dto)
    {
        var model = Mapper.Map<FlagPatternCreateDto, FlagPattern>(dto);
        var id = await Context.InsertEntityAsync(model);
        return id;
    }
}

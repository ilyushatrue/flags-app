using DAL.DTOs.Flags.Attributes;
using DAL.Models.Flags.Attributes;
using DAL.Repositories.Base;

namespace DAL.Repositories;

public class FlagAreaRepository : BaseRepository
{
    public async Task<int> CreateFlagArea(FlagAreaDto dto)
    {
        var entity = Mapper.Map<FlagAreaDto, FlagArea>(dto);
        var id = await Context.InsertEntityAsync(entity);
        return id;
    }
    public async Task<int> UpdateFlagArea(FlagAreaDto dto)
    {
        var entity = Mapper.Map<FlagAreaDto, FlagArea>(dto);
        var id = await Context.UpdateEntityAsync(entity);
        return id;
    }
    public async Task<int> DeleteFlagArea(int id)
    {
        var id = await Context.DeleteEntityAsync<FlagArea>(id);
        return id;
    }
}

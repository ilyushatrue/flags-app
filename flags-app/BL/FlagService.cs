using DAL.DTOs.Flags;
using DAL.Repositories;

namespace BL;

public class FlagService
{
    private readonly FlagRepository _repository;
    public FlagService()
    {
        _repository = new FlagRepository();
    }
    public async Task<IEnumerable<FlagDto>> GetAllFlagsAsync()
    {
        return await _repository.GetAllFlagsAsync();
    }

    public async Task<int> CreateFlagAsync(FlagDto entity)
    {
        return await _repository.CreateFlagAsync(entity);
    }
}

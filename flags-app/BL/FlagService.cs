using DAL.Models.Flags;
using DAL.Repositories;

namespace BL;

public class FlagService
{
    private readonly FlagRepository _repository;
    public FlagService()
    {
        _repository = new FlagRepository();
    }
    public async Task<IEnumerable<Flag>> GetAllFlagsAsync()
    {
        return await _repository.GetAllFlagsAsync();
    }
}

using DAL.DTOs.Flags.Attributes;
using DAL.Repositories;

namespace BL.Services;

public class FlagAreaService
{
    private readonly FlagAreaRepository _repository;
    public FlagAreaService()
    {
        _repository = new FlagAreaRepository();
    }

    public async Task<int> CreateFlagAreaAsync(FlagAreaDto dto)
    {
        var id = await _repository.CreateFlagAreaAsync(dto);
        return id;
    }
}

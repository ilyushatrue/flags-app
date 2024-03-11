using DAL.DTOs.Flags.Attributes;
using DAL.Repositories;

namespace BL.Services;

public class FlagPatternService
{
    private readonly FlagPatternRepository _repository;
    public FlagPatternService()
    {
        _repository = new FlagPatternRepository();  
    }

    public async Task<int> CreatePattern(FlagPatternCreateDto dto)
    {
        var id = await _repository.CreatePattern(dto);
        return id;
    }
}

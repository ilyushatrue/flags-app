using DAL.DTOs;
using DAL.Repositories;

namespace BL;

public class CountryService
{
    private readonly CountryRepository _repository;
    public CountryService()
    {
        _repository = new CountryRepository();
    }
    public async Task<int> CreateCountryAsync(CountryDto dto)
    {
        return await _repository.CreateCountryAsync(dto);
    }
}

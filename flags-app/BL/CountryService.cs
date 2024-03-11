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

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dto"></param>
    /// <returns>Inserted entity Id</returns>
    public async Task<int> CreateCountryAsync(CountryDto dto)
    {
        return await _repository.CreateCountryAsync(dto);
    }
}

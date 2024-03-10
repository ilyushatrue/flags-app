using DAL.DTOs;
using DAL.Repositories;

namespace BL;

public class CatalogService
{
    private readonly CatalogRepository _repository;
    public CatalogService()
    {
        _repository = new CatalogRepository();
    }

    public async Task<int> CreateItemAsync(CatalogItemDto item)
    {
        return await _repository.CreateItemAsync(item);
    }

    public async Task<List<CatalogItemDto>> GetAllColorsAsync()
    {
        var dtos = await _repository.GetAllItemsAsync("color");
        return dtos;
    }
    public async Task<CatalogItemDto?> GetColorAsync(string color)
    {
        var dto = await _repository.GetColorAsync(color);
        return dto;
    }
}

using DAL.DTOs;
using DAL.Models;
using DAL.Repositories.Base;

namespace DAL.Repositories;

public class CatalogRepository : BaseRepository
{
    public async Task<int> CreateItemAsync(CatalogItemDto dto)
    {
        var entity = Mapper.Map<CatalogItem>(dto);
        return await Context.InsertEntityAsync(entity);
    }

    public async Task<List<CatalogItemDto>> GetAllItemsAsync(string context)
    {
        var entities = await Context.GetRangeAsync<CatalogItem>(x => x.Context == context);
        if (entities.Count == 0) return [];
        var dtos = Mapper.Map<List<CatalogItemDto>>(entities);
        return dtos;
    }

    public async Task<CatalogItemDto?> GetColorAsync(string color)
    {
        var entity = await Context.GetEntityAsync<CatalogItem>(x => x.Context == "color" && x.Name == color);
        var dto = Mapper.Map<CatalogItemDto>(entity);
        return dto;
    }
}

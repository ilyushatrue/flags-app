using DAL.DTOs;
using DAL.Models;
using DAL.Repositories.Base;

namespace DAL.Repositories;

public class CatalogRepository : BaseRepository
{
    public async Task<int> CreateCatalogItem(CatalogItemDto dto)
    {
        var entity = Mapper.Map<CatalogItem>(dto);
        return await Context.InsertEntityAsync(entity);
    }
}

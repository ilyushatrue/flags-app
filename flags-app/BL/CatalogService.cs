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

    public async Task<int> CreateCatalogItem(CatalogItemDto item)
    {
        return await _repository.CreateCatalogItem(item);
    }
}

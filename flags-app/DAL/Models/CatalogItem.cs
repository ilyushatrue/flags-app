namespace DAL.Models;

public class CatalogItem : BaseEntity
{
    public string Context { get; set; } = null!;
    public string Name { get; set; } = null!;
}

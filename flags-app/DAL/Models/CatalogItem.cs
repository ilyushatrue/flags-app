namespace DAL.Models;

internal class CatalogItem
{
    public int Id { get; set; }
    public string Context { get; set; } = null!;
    public string Name { get; set; } = null!;
}

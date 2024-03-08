namespace DAL.Models.Flags.Attributes;

public class FlagPattern
{
    public int Id { get; set; }
    public CatalogItem Name { get; set; } = null!;
    public int Count { get; set; }
    public CatalogItem Color { get; set; } = null!;
}

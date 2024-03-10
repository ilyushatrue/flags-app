namespace DAL.Models.Flags.Attributes;

public class FlagPattern : BaseEntity
{
    public int Count { get; set; }
    public int NameId { get; set; }
    public int ColorId { get; set; }
    public int AreaId { get; set; }

    public CatalogItem Name { get; set; } = null!;
    public CatalogItem Color { get; set; } = null!;
    public FlagArea Area { get; set; } = null!;
}

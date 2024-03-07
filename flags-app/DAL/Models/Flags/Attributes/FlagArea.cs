namespace DAL.Models.Flags.Attributes;

internal class FlagArea
{
    public int Id { get; set; }
    public CatalogItem Color { get; set; } = null!;
    public FlagArea? Area { get; set; }
    public ICollection<FlagPattern>? Patterns { get; set; }
}

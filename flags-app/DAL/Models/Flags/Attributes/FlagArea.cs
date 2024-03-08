namespace DAL.Models.Flags.Attributes;

public class FlagArea
{
    public int Id { get; set; }
    public int FlagId { get; set; }

    public CatalogItem Color { get; set; } = null!;
    public Flag Flag { get; set; } = null!;
    public FlagArea? Area { get; set; }
    public ICollection<FlagPattern>? Patterns { get; set; }
}

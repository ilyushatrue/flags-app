namespace DAL.Models.Flags.Attributes;

public class FlagArea : BaseEntity
{
    public int FlagId { get; set; }
    public int? ParentId { get; set; }
    public int ColorId { get; set; } 

    public CatalogItem Color { get; set; } = null!;
    public Flag Flag { get; set; } = null!;
    public FlagArea? Parent { get; set; }
    public ICollection<FlagArea> Children { get; set; } = [];
    public ICollection<FlagPattern> Patterns { get; set; } = [];
}

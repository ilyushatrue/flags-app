using DAL.Models.Base;

namespace DAL.Models.Flags;

public class StripedFlag : Flag, IBaseEntity
{
    public int Id { get; set; }
    public CatalogItem StripDirection { get; set; } = null!;
    public CatalogItem StripColor { get; set; } = null!;
}

namespace DAL.Models.Flags;

public class StripedFlag : Flag
{
    public CatalogItem StripDirection { get; set; } = null!;
    public CatalogItem StripColor { get; set; } = null!;
}

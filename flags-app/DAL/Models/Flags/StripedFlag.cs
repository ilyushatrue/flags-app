namespace DAL.Models.Flags;

internal class StripedFlag : Flag
{
    public CatalogItem StripDirection { get; set; } = null!;
    public CatalogItem StripColor { get; set; } = null!;
}

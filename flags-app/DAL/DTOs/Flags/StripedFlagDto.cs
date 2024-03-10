namespace DAL.DTOs.Flags;

public class StripedFlagDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int CountryId { get; set; }
    public CatalogItemDto StripDirection { get; set; } = null!;
    public CatalogItemDto StripColor { get; set; } = null!;
}

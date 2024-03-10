namespace DAL.DTOs;

public class CatalogItemDto
{
    public int Id { get; set; }
    public string Context { get; set; } = null!;
    public string Name { get; set; } = null!;
}

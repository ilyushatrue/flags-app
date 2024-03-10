using DAL.DTOs.Flags;

namespace DAL.DTOs;

public class CountryDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string CapitalName { get; set; } = null!;
    public string? Description { get; set; }

    public FlagDto Flag { get; set; } = null!;
}

using DAL.DTOs.Flags.Attributes;

namespace DAL.DTOs.Flags;

public class FlagDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int CountryId { get; set; }
    public FlagAreaDto Area { get; set; } = null!;
}

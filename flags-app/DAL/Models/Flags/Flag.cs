using DAL.Models.Flags.Attributes;

namespace DAL.Models.Flags;

internal class Flag
{
    public int Id { get; set; }
    public int CountryId { get; set; }

    public FlagArea Area { get; set; } = null!;
    public Country Country { get; set; } = null!;
}

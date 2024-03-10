using DAL.Models.Flags.Attributes;

namespace DAL.Models.Flags;

internal class Flag : BaseEntity
{
    public int CountryId { get; set; }
    public string Name { get; set; } = null!;

    public FlagArea Area { get; set; } = null!;
    public Country Country { get; set; } = null!;
}

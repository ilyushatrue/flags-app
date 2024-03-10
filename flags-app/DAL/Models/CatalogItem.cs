using DAL.Models.Flags.Attributes;

namespace DAL.Models;

internal class CatalogItem : BaseEntity
{
    public string Context { get; set; } = null!;
    public string Name { get; set; } = null!;

    public ICollection<FlagArea> FlagAreaColors { get; set; } = [];
    public ICollection<FlagPattern> FlagPatternColors { get; set; } = [];
    public ICollection<FlagPattern> FlagPatternNames { get; set; } = [];
}

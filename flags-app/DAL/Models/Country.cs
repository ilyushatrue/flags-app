namespace DAL.Models;

public class Country : BaseEntity
{
    public string Name { get; set; } = null!;
    public string CapitalName { get; set; } = null!;
    public string? Description { get; set; }
}

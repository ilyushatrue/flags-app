namespace DAL.Models;

internal class Country
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string CapitalName { get; set; } = null!;
    public string? Description { get; set; }
}

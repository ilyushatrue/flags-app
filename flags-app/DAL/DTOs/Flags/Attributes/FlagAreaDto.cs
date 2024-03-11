namespace DAL.DTOs.Flags.Attributes;

public class FlagAreaDto
{
    public int FlagId { get; set; }
    public int? ParentId { get; set; }
    public int ColorId { get; set; }

    public FlagPatternCreateDto MyProperty { get; set; }
}

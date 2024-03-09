using DAL.Models.Base;

namespace DAL.Models.Flags;

public class PlainFlag : Flag, IBaseEntity
{
    public int Id { get; set; }
}

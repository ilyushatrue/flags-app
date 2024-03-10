using DAL.Models.Base;

namespace DAL.Models;

public class BaseEntity : IBaseEntity
{
    public int Id { get; set; }
    public bool IsDeleted { get; set; }
}

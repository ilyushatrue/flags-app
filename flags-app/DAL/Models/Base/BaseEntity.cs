using DAL.Models.Base;

namespace DAL.Models;

internal class BaseEntity : IBaseEntity
{
    public int Id { get; set; }
    public bool IsDeleted { get; set; }
}

namespace DAL.Models.Base;

public interface IBaseEntity
{
    public int Id { get; set; }
    public bool IsDeleted { get; set; }
}

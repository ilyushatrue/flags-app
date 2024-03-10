namespace DAL.Models.Base;

internal interface IBaseEntity
{
    public int Id { get; set; }
    public bool IsDeleted { get; set; }
}

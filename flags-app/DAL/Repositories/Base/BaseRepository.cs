namespace DAL.Repositories.Base;

public class BaseRepository
{
    internal Context Context { get; } 
    public BaseRepository()
    {
        Context = Context.Initialize();
    }
}
